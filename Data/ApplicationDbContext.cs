using AromaCoffee.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AromaCoffee.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>().HasData(
     new Product
     {
         Id = 1,
         Name = "Еспресо",
         Description = "Міцна класична кава",
         Price = 45,
         ImageUrl = "/images/espresso.jpg",
         Category = "Кава",
         IsAvailable = true
     },
     new Product
     {
         Id = 2,
         Name = "Американо",
         Description = "Ароматна чорна кава",
         Price = 50,
         ImageUrl = "/images/americano.jpg",
         Category = "Кава",
         IsAvailable = true
     },
     new Product
     {
         Id = 3,
         Name = "Капучино",
         Description = "Кава з ніжною молочною пінкою",
         Price = 65,
         ImageUrl = "/images/cappuccino.jpg",
         Category = "Кава",
         IsAvailable = true
     },
     new Product
     {
         Id = 4,
         Name = "Лате",
         Description = "М’яка кава з молоком",
         Price = 70,
         ImageUrl = "/images/latte.jpg",
         Category = "Кава",
         IsAvailable = true
     },
     new Product
     {
         Id = 5,
         Name = "Мокачино",
         Description = "Кава із шоколадним смаком",
         Price = 75,
         ImageUrl = "/images/mocha.jpg",
         Category = "Кава",
         IsAvailable = true
     },
     new Product
     {
         Id = 6,
         Name = "Раф",
         Description = "Ніжна кава з вершковим смаком",
         Price = 85,
         ImageUrl = "/images/raf.jpg",
         Category = "Кава",
         IsAvailable = true
     },
     new Product
     {
         Id = 7,
         Name = "Гарячий шоколад",
         Description = "Солодкий гарячий напій",
         Price = 80,
         ImageUrl = "/images/hotchocolate.jpg",
         Category = "Кава",
         IsAvailable = true
     },
     new Product
     {
         Id = 8,
         Name = "Чай",
         Description = "Ароматний чай на вибір",
         Price = 40,
         ImageUrl = "/images/tea.jpg",
         Category = "Кава",
         IsAvailable = true
     },

     new Product
     {
         Id = 9,
         Name = "Айс Американо",
         Description = "Холодна чорна кава",
         Price = 70,
         ImageUrl = "/images/iceamericano.jpg",
         Category = "Холодні напої",
         IsAvailable = true
     },
     new Product
     {
         Id = 10,
         Name = "Айс Лате",
         Description = "Холодна кава з молоком",
         Price = 80,
         ImageUrl = "/images/icelatte.jpg",
         Category = "Холодні напої",
         IsAvailable = true
     },
     new Product
     {
         Id = 11,
         Name = "Фрапе",
         Description = "Прохолодний кавовий напій",
         Price = 90,
         ImageUrl = "/images/frappe.jpg",
         Category = "Холодні напої",
         IsAvailable = true
     },
     new Product
     {
         Id = 12,
         Name = "Лимонад",
         Description = "Освіжаючий напій",
         Price = 60,
         ImageUrl = "/images/lemonade.jpg",
         Category = "Холодні напої",
         IsAvailable = true
     },
     new Product
     {
         Id = 13,
         Name = "Молочний коктейль",
         Description = "Солодкий прохолодний коктейль",
         Price = 85,
         ImageUrl = "/images/milkshake.jpg",
         Category = "Холодні напої",
         IsAvailable = true
     },
     new Product
     {
         Id = 14,
         Name = "Апельсиновий фреш",
         Description = "Свіжовичавлений сік",
         Price = 95,
         ImageUrl = "/images/orangefresh.jpg",
         Category = "Холодні напої",
         IsAvailable = true
     },

     new Product
     {
         Id = 15,
         Name = "Чізкейк",
         Description = "Ніжний вершковий десерт",
         Price = 95,
         ImageUrl = "/images/cheesecake.jpg",
         Category = "Десерти",
         IsAvailable = true
     },
     new Product
     {
         Id = 16,
         Name = "Тірамісу",
         Description = "Класичний італійський десерт",
         Price = 100,
         ImageUrl = "/images/tiramisu.jpg",
         Category = "Десерти",
         IsAvailable = true
     },
     new Product
     {
         Id = 17,
         Name = "Круасан",
         Description = "Хрусткий круасан із ніжною начинкою",
         Price = 55,
         ImageUrl = "/images/croissant.jpg",
         Category = "Десерти",
         IsAvailable = true
     },
     new Product
     {
         Id = 18,
         Name = "Шоколадний торт",
         Description = "Насичений шоколадний десерт",
         Price = 110,
         ImageUrl = "/images/cake.jpg",
         Category = "Десерти",
         IsAvailable = true
     },
     new Product
     {
         Id = 19,
         Name = "Пончик",
         Description = "Солодкий пончик з глазур’ю",
         Price = 55,
         ImageUrl = "/images/donut.jpg",
         Category = "Десерти",
         IsAvailable = true
     },
     new Product
     {
         Id = 20,
         Name = "Макарон",
         Description = "Легкий французький десерт",
         Price = 35,
         ImageUrl = "/images/macaron.jpg",
         Category = "Десерти",
         IsAvailable = true
     },
     new Product
     {
         Id = 21,
         Name = "Брауні",
         Description = "Шоколадний вологий десерт",
         Price = 65,
         ImageUrl = "/images/brownie.jpg",
         Category = "Десерти",
         IsAvailable = true
     },
     new Product
     {
         Id = 22,
         Name = "Маффін",
         Description = "М’який кекс до кави",
         Price = 50,
         ImageUrl = "/images/muffin.jpg",
         Category = "Десерти",
         IsAvailable = true
     },
     new Product
     {
         Id = 23,
         Name = "Еклер",
         Description = "Заварне тістечко з кремом",
         Price = 60,
         ImageUrl = "/images/eclair.jpg",
         Category = "Десерти",
         IsAvailable = true
     },
     new Product
     {
         Id = 24,
         Name = "Панкейки",
         Description = "Пишні панкейки з топінгом",
         Price = 90,
         ImageUrl = "/images/pancakes.jpg",
         Category = "Десерти",
         IsAvailable = true
     }
            );
        }
    }
}