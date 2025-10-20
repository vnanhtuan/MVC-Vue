using System.Security.Cryptography.X509Certificates;

namespace MVC_Vue.Databases
{
    public static class MenuDatabase
    {
        public static List<MenuData> GetMenus()
        {
            var menuData = new List<MenuData>()
            {
                new()
                {
                    Id = 1,
                    Name = "Home",
                    Url = "/"
                },
                new()
                {
                    Id = 2,
                    Name = "Shop",
                    Url = "/Home/Index"
                },
                new()
                {
                    Id = 2,
                    Name = "About us",
                    Url = "/Home/About"
                }
            };
            return menuData;
        }
    }

    public static class ProductDatabase
    {
        public static Product? GetProductById(int id)
        {
            List<Product> _products = GetProducts();
            return _products.FirstOrDefault(p => p.Id == id);
        }
        public static List<Product> GetProducts()
        {
            List<Product> _products = [];

            _products.Add(new Product
            {
                Id = 1,
                Name = "Quần Jean",
                Price = 199000,
                Discount = 20,
                Images = new List<Image>
                {
                    new Image
                    {
                        Id = 1,
                        Name = "Quần Jean 1",
                        Url = "https://cdn-images.farfetch-contents.com/32/15/61/31/32156131_62192583_1000.jpg"
                    },
                    new Image
                    {
                        Id = 2,
                        Name = "Quần Jean 1",
                        Url = "https://cdn-images.farfetch-contents.com/32/15/61/31/32156131_62325278_1000.jpg"
                    },
                }
            });
            _products.Add(new Product
            {
                Id = 2,
                Name = "OUR LEGACY",
                Price = 1250000,
                Images = new List<Image>
                {
                    new Image
                    {
                        Id = 3,
                        Name = "OUR LEGACY",
                        Url = "https://cdn-images.farfetch-contents.com/32/16/21/56/32162156_62388280_1000.jpg"
                    },
                    new Image
                    {
                        Id = 4,
                        Name = "OUR LEGACY",
                        Url = "https://cdn-images.farfetch-contents.com/32/16/21/56/32162156_62324822_1000.jpg"
                    },
                    new Image
                    {
                        Id = 5,
                        Name = "OUR LEGACY",
                        Url = "https://cdn-images.farfetch-contents.com/32/16/21/56/32162156_62324825_1000.jpg"
                    },
                    new Image
                    {
                        Id = 6,
                        Name = "OUR LEGACY",
                        Url = "https://cdn-images.farfetch-contents.com/32/16/21/56/32162156_62324826_1000.jpg"
                    }
                }
            });
            _products.Add(new Product
            {
                Id = 3,
                Name = "Jil Sander",
                Price = 2790000,
                Images = new List<Image>
                {
                    new Image
                    {
                        Id = 7,
                        Name = "Jil Sander",
                        Url = "https://cdn-images.farfetch-contents.com/30/01/15/00/30011500_59550711_1000.jpg"
                    },
                    new Image
                    {
                        Id = 8,
                        Name = "Jil Sander",
                        Url = "https://cdn-images.farfetch-contents.com/30/01/15/00/30011500_59550669_1000.jpg"
                    },
                    new Image
                    {
                        Id = 9,
                        Name = "Jil Sander",
                        Url = "https://cdn-images.farfetch-contents.com/30/01/15/00/30011500_59550710_1000.jpg"
                    },
                    new Image
                    {
                        Id = 10,
                        Name = "Jil Sander",
                        Url = "https://cdn-images.farfetch-contents.com/30/01/15/00/30011500_59550684_1000.jpg"
                    }
                }
            });
            _products.Add(new Product
            {
                Id = 4,
                Name = "Skall Studio",
                Price = 1790000,
                Images = new List<Image>
                {
                    new Image
                    {
                        Id = 11,
                        Name = "Skall Studio",
                        Url = "https://cdn-images.farfetch-contents.com/31/71/70/41/31717041_62367117_1000.jpg"
                    },
                    new Image
                    {
                        Id = 12,
                        Name = "Skall Studio",
                        Url = "https://cdn-images.farfetch-contents.com/31/71/70/41/31717041_62367148_1000.jpg"
                    },
                    new Image
                    {
                        Id = 13,
                        Name = "Skall Studio",
                        Url = "https://cdn-images.farfetch-contents.com/31/71/70/41/31717041_62367135_1000.jpg"
                    },
                    new Image
                    {
                        Id = 14,
                        Name = "Skall Studio",
                        Url = "https://cdn-images.farfetch-contents.com/31/71/70/41/31717041_62367184_1000.jpg"
                    }
                }
            });
            
            return _products;
        }
    }

    public class MenuData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; } = string.Empty;
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; } =[];
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<Image> Images { get; set; } = [];
        public float Discount { get; set; } = 0;
    }

    public class Image
    {   
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string UserName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
    }

    public static class UserDatabase
    {
        public static User? GetUserById(int id)
        {
            List<User> _users = GetUsers();
            return _users.FirstOrDefault(p => p.Id == id);
        }

        public static User? LoginUser(string username, string password)
        {
            List<User> _users = GetUsers();
            return _users.FirstOrDefault(p => p.UserName == username && p.Password == password);
        }
        public static List<User> GetUsers()
        {
            var _users = new List<User>();

            _users.Add(new User
            {
                Id = 1,
                Name = "Admin",
                UserName = "admin@test.com",
                Email = "admin@test.com",
                Password = "123456",
            });

            _users.Add(new User
            {
                Id = 2,
                Name = "Jack",
                UserName = "jack@test.com",
                Email = "jack@test.com",
                Password = "123456",
            });

            return _users;
        }
    }
}
