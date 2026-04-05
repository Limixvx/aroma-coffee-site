using AromaCoffee.Extensions;
using AromaCoffee.Data;
using AromaCoffee.Models;
using AromaCoffee.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text.Json;

namespace AromaCoffee.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(
      ILogger<HomeController> logger,
      ApplicationDbContext context,
      UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Menu()
        {
            var products = _context.Products
                .Where(p => p.IsAvailable)
                .OrderBy(p => p.Category)
                .ThenBy(p => p.Name)
                .ToList();

            return View(products);
        }

        public IActionResult AddToCart(string name, int price, string image)
        {
            List<CartItem> cart;

            var sessionData = HttpContext.Session.GetString("cart");

            if (sessionData != null)
            {
                cart = JsonSerializer.Deserialize<List<CartItem>>(sessionData) ?? new List<CartItem>();
            }
            else
            {
                cart = new List<CartItem>();
            }

            var item = cart.FirstOrDefault(x => x.Name == name);

            if (item != null)
            {
                item.Quantity++;
            }
            else
            {
                cart.Add(new CartItem
                {
                    Name = name,
                    Price = price,
                    Quantity = 1,
                    Image = image
                });
            }

            HttpContext.Session.SetString("cart", JsonSerializer.Serialize(cart));

            TempData["Message"] = "✔ Товар додано в кошик";
            return RedirectToAction("Menu");
        }

        public IActionResult Cart()
        {
            var sessionData = HttpContext.Session.GetString("cart");

            if (sessionData != null)
            {
                var cart = JsonSerializer.Deserialize<List<CartItem>>(sessionData) ?? new List<CartItem>();
                return View(cart);
            }

            return View(new List<CartItem>());
        }

        public IActionResult IncreaseQuantity(int id)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("cart") ?? new List<CartItem>();

            var item = cart.FirstOrDefault(x => x.ProductId == id);

            if (item != null)
            {
                item.Quantity++;
            }

            HttpContext.Session.SetObjectAsJson("cart", cart);

            return RedirectToAction("cart");
        }

        public IActionResult DecreaseQuantity(int id)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("cart") ?? new List<CartItem>();

            var item = cart.FirstOrDefault(x => x.ProductId == id);

            if (item != null)
            {
                item.Quantity--;

                if (item.Quantity <= 0)
                {
                    cart.Remove(item);
                }
            }

            HttpContext.Session.SetObjectAsJson("cart", cart);

            return RedirectToAction("cart");
        }

        public IActionResult RemoveFromCart(int id)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("cart") ?? new List<CartItem>();

            var item = cart.FirstOrDefault(x => x.ProductId == id);

            if (item != null)
            {
                cart.Remove(item);
            }

            HttpContext.Session.SetObjectAsJson("cart", cart);

            return RedirectToAction("cart");
        }

        [HttpPost]
        public IActionResult AddToCartAjax(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id && p.IsAvailable);

            if (product == null)
            {
                return Json(new { success = false, message = "Товар не знайдено" });
            }

            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("cart") ?? new List<CartItem>();

            // 🔥 ТЕПЕР шукаємо по ProductId
            var existingItem = cart.FirstOrDefault(x => x.ProductId == id);

            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                cart.Add(new CartItem
                {
                    ProductId = product.Id,   // 👈 ДОДАЛИ
                    Name = product.Name,
                    Price = product.Price,
                    Image = product.ImageUrl ?? "",
                    Quantity = 1
                });
            }

            HttpContext.Session.SetObjectAsJson("cart", cart);

            return Json(new
            {
                success = true,
                message = $"Товар \"{product.Name}\" додано в кошик",
                cartCount = cart.Sum(x => x.Quantity)
            });
        }

        [HttpGet]
        [Authorize]
        public IActionResult Checkout()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("cart") ?? new List<CartItem>();

            if (cart.Count == 0)
            {
                return RedirectToAction("cart");
            }

            return View(new CheckoutViewModel());
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Checkout(CheckoutViewModel model)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("cart") ?? new List<CartItem>();

            if (cart.Count == 0)
            {
                return RedirectToAction("cart");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);

            var order = new Order
            {
                UserId = user?.Id,
                CustomerName = model.CustomerName,
                Phone = model.Phone,
                Address = model.Address,
                Comment = model.Comment,
                PaymentMethod = model.PaymentMethod,
                OrderDate = DateTime.Now,
                Status = "Нове",
                TotalAmount = cart.Sum(x => x.Price * x.Quantity),
                OrderItems = cart.Select(x => new OrderItem
                {
                    ProductId = null,
                    ProductName = x.Name,
                    ProductImage = x.Image,
                    Price = x.Price,
                    Quantity = x.Quantity
                }).ToList()
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            HttpContext.Session.Remove("cart");

            return RedirectToAction("OrderSuccess");
        }

        [Authorize]
        public async Task<IActionResult> MyOrders()
        {
            var user = await _userManager.GetUserAsync(User);

            var orders = await _context.Orders
                .Include(o => o.OrderItems)
                .Where(o => o.UserId == user!.Id)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();

            return View(orders);
        }

        public IActionResult OrderSuccess()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CancelOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
                return NotFound();

            order.Status = "Скасовано";

            await _context.SaveChangesAsync();

            return RedirectToAction("MyOrders");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
