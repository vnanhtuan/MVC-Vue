

namespace MVC_Vue.Databases
{
    public static class MenuDatabase
    {
        public static List<Menu> GetMenus()
        {
            var menuData = new List<Menu>()
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
                    Url = "/shop/index"
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

    public static class CategoryDatabase
    {
        public static List<Category> GetCategories()
        {
            List<Category> _categories = [];

            _categories.Add(new Category
            {
                Id = 1,
                Name = "Sản phẩm mới",
                IsHome = true,
            });
            _categories.Add(new Category
            {
                Id = 2,
                Name = "Sản phẩm Mùa Đông",
                IsHome = true,
            });
            _categories.Add(new Category
            {
                Id = 3,
                Name = "Sản phẩm HOT TREND",
                IsHome = false,
            });
            _categories.Add(new Category
            {
                Id = 4,
                Name = "Sản phẩm giảm giá",
                IsHome = true,
            });

            return _categories;
        }
    }

    public static class ProductDatabase
    {
        public static Product? GetProductById(int id)
        {
            List<Product> _products = GetProducts();
            return _products.FirstOrDefault(p => p.Id == id);
        }
        public static Product? GetProductBySlug(string slug)
        {
            List<Product> _products = GetProducts();
            return _products.FirstOrDefault(p => p.Slug == slug);
        }
        public static List<Product> GetProducts()
        {
            List<Product> _products = [];

            _products.Add(new Product
            {
                Id = 1,
                CategoryId = 1,
                Slug = "quan-jean",
                Sku = "JB2995844",
                Name = "Quần Jean",
                Description = "One delivery fee to most locations (check our Orders & Delivery page)",
                Price = 199000,
                Discount = 0,
                Quantity = 3,
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
                CategoryId = 1,
                Sku = "JB3572888",
                Slug = "our-legacy",
                Name = "OUR LEGACY",
                Description = "Free returns within 30 days (excludes final sale and made-to-order items)",
                Price = 1250000,
                Quantity = 1,
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
                CategoryId = 1,
                Sku = "JB35735444",
                Slug = "jil-sander",
                Name = "Jil Sander",
                Description = "Delivery duties are included in the item price when shipping to all EU countries",
                Price = 2790000,
                Quantity = 2,
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
                CategoryId = 2,
                Sku = "JB57338111",
                Slug = "skall-studio",
                Name = "Skall Studio",
                Description = "Let us handle the legwork.\r\n\r\nDelivery duties are included in the item price when shipping to all EU countries (excluding the Canary Islands), plus The United Kingdom, USA, Canada, China Mainland, Australia, New Zealand, Puerto Rico, Switzerland, Singapore, Republic Of Korea, Kuwait, Mexico, Qatar, India, Norway, Saudi Arabia, Taiwan Region, Thailand, U.A.E., Japan, Brazil, Isle of Man, San Marino, Colombia, Chile, Argentina, Egypt, Lebanon, Hong Kong SAR, and Bahrain. All import duties are included in your order – the price you see is the price you pay.",
                Price = 1790000,
                Quantity = 1,
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
            _products.Add(new Product
            {
                Id = 5,
                CategoryId = 2,
                Sku = "JB5434111",
                Slug = "polo-ralph-lauren",
                Name = "Polo Ralph Lauren",
                Description = "Let us handle the legwork.\r\n\r\nDelivery duties are included in the item price when shipping to all EU countries (excluding the Canary Islands), plus The United Kingdom, USA, Canada, China Mainland, Australia, New Zealand, Puerto Rico, Switzerland, Singapore, Republic Of Korea, Kuwait, Mexico, Qatar, India, Norway, Saudi Arabia, Taiwan Region, Thailand, U.A.E., Japan, Brazil, Isle of Man, San Marino, Colombia, Chile, Argentina, Egypt, Lebanon, Hong Kong SAR, and Bahrain. All import duties are included in your order – the price you see is the price you pay.",
                Price = 1790000,
                Quantity = 1,
                Images = new List<Image>
                {
                    new Image
                    {
                        Id = 15,
                        Name = "Polo Ralph Lauren",
                        Url = "https://cdn-images.farfetch-contents.com/30/62/65/29/30626529_59473259_1000.jpg"
                    },
                    new Image
                    {
                        Id = 16,
                        Name = "Polo Ralph Lauren",
                        Url = "https://cdn-images.farfetch-contents.com/30/62/65/29/30626529_59473276_1000.jpg"
                    },
                    new Image
                    {
                        Id = 17,
                        Name = "Polo Ralph Lauren",
                        Url = "https://cdn-images.farfetch-contents.com/30/62/65/29/30626529_59473356_1000.jpg"
                    },
                    new Image
                    {
                        Id = 18,
                        Name = "Polo Ralph Lauren",
                        Url = "https://cdn-images.farfetch-contents.com/30/62/65/29/30626529_59473296_1000.jpg"
                    }
                }
            });
            _products.Add(new Product
            {
                Id = 6,
                CategoryId = 2,
                Sku = "JB573721111",
                Slug = "sandro",
                Name = "SANDRO",
                Description = "Let us handle the legwork.\r\n\r\nDelivery duties are included in the item price when shipping to all EU countries (excluding the Canary Islands), plus The United Kingdom, USA, Canada, China Mainland, Australia, New Zealand, Puerto Rico, Switzerland, Singapore, Republic Of Korea, Kuwait, Mexico, Qatar, India, Norway, Saudi Arabia, Taiwan Region, Thailand, U.A.E., Japan, Brazil, Isle of Man, San Marino, Colombia, Chile, Argentina, Egypt, Lebanon, Hong Kong SAR, and Bahrain. All import duties are included in your order – the price you see is the price you pay.",
                Price = 600000,
                Quantity = 1,
                Images = new List<Image>
                {
                    new Image
                    {
                        Id = 19,
                        Name = "SANDRO",
                        Url = "https://cdn-images.farfetch-contents.com/29/91/43/49/29914349_61764113_1000.jpg"
                    },
                    new Image
                    {
                        Id = 20,
                        Name = "SANDRO",
                        Url = "https://cdn-images.farfetch-contents.com/29/91/43/49/29914349_61764100_1000.jpg"
                    },
                    new Image
                    {
                        Id = 21,
                        Name = "Polo Ralph Lauren",
                        Url = "https://cdn-images.farfetch-contents.com/29/91/43/49/29914349_61764058_1000.jpg"
                    },
                    new Image
                    {
                        Id = 22,
                        Name = "Polo Ralph Lauren",
                        Url = "https://cdn-images.farfetch-contents.com/29/91/43/49/29914349_61764131_1000.jpg"
                    }
                }
            });

            _products.Add(new Product
            {
                Id = 7,
                CategoryId = 3,
                Sku = "JB512321111",
                Slug = "alexander-wang",
                Name = "Alexander Wang",
                Description = "Let us handle the legwork.\r\n\r\nDelivery duties are included in the item price when shipping to all EU countries (excluding the Canary Islands), plus The United Kingdom, USA, Canada, China Mainland, Australia, New Zealand, Puerto Rico, Switzerland, Singapore, Republic Of Korea, Kuwait, Mexico, Qatar, India, Norway, Saudi Arabia, Taiwan Region, Thailand, U.A.E., Japan, Brazil, Isle of Man, San Marino, Colombia, Chile, Argentina, Egypt, Lebanon, Hong Kong SAR, and Bahrain. All import duties are included in your order – the price you see is the price you pay.",
                Price = 600000,
                Quantity = 1,
                Images = new List<Image>
                {
                    new Image
                    {
                        Id = 23,
                        Name = "Alexander Wang",
                        Url = "https://cdn-images.farfetch-contents.com/30/71/24/40/30712440_60019082_1000.jpg"
                    },
                    new Image
                    {
                        Id = 24,
                        Name = "Alexander Wang",
                        Url = "https://cdn-images.farfetch-contents.com/30/71/24/40/30712440_60028477_1000.jpg"
                    },
                    new Image
                    {
                        Id = 25,
                        Name = "Alexander Wang",
                        Url = "https://cdn-images.farfetch-contents.com/30/71/24/40/30712440_60028510_1000.jpg"
                    },
                    new Image
                    {
                        Id = 26,
                        Name = "Alexander Wang",
                        Url = "https://cdn-images.farfetch-contents.com/30/71/24/40/30712440_60028492_1000.jpg"
                    }
                }
            });
            _products.Add(new Product
            {
                Id = 8,
                CategoryId = 3,
                Sku = "JB53211111",
                Slug = "jw-anderson",
                Name = "JW Anderson",
                Description = "Let us handle the legwork.\r\n\r\nDelivery duties are included in the item price when shipping to all EU countries (excluding the Canary Islands), plus The United Kingdom, USA, Canada, China Mainland, Australia, New Zealand, Puerto Rico, Switzerland, Singapore, Republic Of Korea, Kuwait, Mexico, Qatar, India, Norway, Saudi Arabia, Taiwan Region, Thailand, U.A.E., Japan, Brazil, Isle of Man, San Marino, Colombia, Chile, Argentina, Egypt, Lebanon, Hong Kong SAR, and Bahrain. All import duties are included in your order – the price you see is the price you pay.",
                Price = 900000,
                Quantity = 1,
                Images = new List<Image>
                {
                    new Image
                    {
                        Id = 27,
                        Name = "JW Anderson",
                        Url = "https://cdn-images.farfetch-contents.com/30/95/97/84/30959784_59865272_1000.jpg"
                    },
                    new Image
                    {
                        Id = 28,
                        Name = "JW Anderson",
                        Url = "https://cdn-images.farfetch-contents.com/30/95/97/84/30959784_59939402_1000.jpg"
                    },
                    new Image
                    {
                        Id = 29,
                        Name = "JW Anderson",
                        Url = "https://cdn-images.farfetch-contents.com/30/95/97/84/30959784_59939426_1000.jpg"
                    },
                    new Image
                    {
                        Id = 30,
                        Name = "JW Anderson",
                        Url = "https://cdn-images.farfetch-contents.com/30/95/97/84/30959784_59865291_1000.jpg"
                    }
                }
            });
            _products.Add(new Product
            {
                Id = 9,
                CategoryId = 3,
                Sku = "JB572021111",
                Slug = "victoria-beckham",
                Name = "Victoria Beckham",
                Description = "Let us handle the legwork.\r\n\r\nDelivery duties are included in the item price when shipping to all EU countries (excluding the Canary Islands), plus The United Kingdom, USA, Canada, China Mainland, Australia, New Zealand, Puerto Rico, Switzerland, Singapore, Republic Of Korea, Kuwait, Mexico, Qatar, India, Norway, Saudi Arabia, Taiwan Region, Thailand, U.A.E., Japan, Brazil, Isle of Man, San Marino, Colombia, Chile, Argentina, Egypt, Lebanon, Hong Kong SAR, and Bahrain. All import duties are included in your order – the price you see is the price you pay.",
                Price = 2600000,
                Quantity = 1,
                Images = new List<Image>
                {
                    new Image
                    {
                        Id = 31,
                        Name = "Victoria Beckham",
                        Url = "https://cdn-images.farfetch-contents.com/30/43/97/81/30439781_59366962_1000.jpg"
                    },
                    new Image
                    {
                        Id = 32,
                        Name = "Victoria Beckham",
                        Url = "https://cdn-images.farfetch-contents.com/30/43/97/81/30439781_59366960_1000.jpg"
                    }
                }
            });

            _products.Add(new Product
            {
                Id = 10,
                CategoryId = 4,
                Sku = "JB5749111",
                Slug = "toteme",
                Name = "TOTEME",
                Description = "Let us handle the legwork.\r\n\r\nDelivery duties are included in the item price when shipping to all EU countries (excluding the Canary Islands), plus The United Kingdom, USA, Canada, China Mainland, Australia, New Zealand, Puerto Rico, Switzerland, Singapore, Republic Of Korea, Kuwait, Mexico, Qatar, India, Norway, Saudi Arabia, Taiwan Region, Thailand, U.A.E., Japan, Brazil, Isle of Man, San Marino, Colombia, Chile, Argentina, Egypt, Lebanon, Hong Kong SAR, and Bahrain. All import duties are included in your order – the price you see is the price you pay.",
                Price = 1950000,
                Discount = 20,
                Quantity = 1,
                Images = new List<Image>
                {
                    new Image
                    {
                        Id = 32,
                        Name = "TOTEME",
                        Url = "https://cdn-images.farfetch-contents.com/30/92/60/03/30926003_61541498_1000.jpg"
                    },
                    new Image
                    {
                        Id = 33,
                        Name = "TOTEME",
                        Url = "https://cdn-images.farfetch-contents.com/30/92/60/03/30926003_61634814_1000.jpg"
                    },
                    new Image
                    {
                        Id = 34,
                        Name = "TOTEME",
                        Url = "https://cdn-images.farfetch-contents.com/30/92/60/03/30926003_61541518_1000.jpg"
                    },
                    new Image
                    {
                        Id = 35,
                        Name = "TOTEME",
                        Url = "https://cdn-images.farfetch-contents.com/30/92/60/03/30926003_61541536_1000.jpg"
                    }
                }
            });
            _products.Add(new Product
            {
                Id = 11,
                CategoryId = 4,
                Sku = "JB572351111",
                Slug = "mother",
                Name = "MOTHER",
                Description = "Let us handle the legwork.\r\n\r\nDelivery duties are included in the item price when shipping to all EU countries (excluding the Canary Islands), plus The United Kingdom, USA, Canada, China Mainland, Australia, New Zealand, Puerto Rico, Switzerland, Singapore, Republic Of Korea, Kuwait, Mexico, Qatar, India, Norway, Saudi Arabia, Taiwan Region, Thailand, U.A.E., Japan, Brazil, Isle of Man, San Marino, Colombia, Chile, Argentina, Egypt, Lebanon, Hong Kong SAR, and Bahrain. All import duties are included in your order – the price you see is the price you pay.",
                Price = 1650000,
                Quantity = 1,
                Discount = 10,
                Images = new List<Image>
                {
                    new Image
                    {
                        Id = 36,
                        Name = "MOTHER",
                        Url = "https://cdn-images.farfetch-contents.com/31/94/52/36/31945236_61584145_1000.jpg"
                    },
                    new Image
                    {
                        Id = 37,
                        Name = "MOTHER",
                        Url = "https://cdn-images.farfetch-contents.com/31/94/52/36/31945236_61583729_1000.jpg"
                    },
                    new Image
                    {
                        Id = 38,
                        Name = "MOTHER",
                        Url = "https://cdn-images.farfetch-contents.com/31/94/52/36/31945236_61584005_1000.jpg"
                    },
                    new Image
                    {
                        Id = 39,
                        Name = "MOTHER",
                        Url = "https://cdn-images.farfetch-contents.com/31/94/52/36/31945236_61584291_1000.jpg"
                    }
                }
            });
            _products.Add(new Product
            {
                Id = 12,
                CategoryId = 4,
                Sku = "JB572211145",
                Slug = "agolde",
                Name = "AGOLDE",
                Description = "Let us handle the legwork.\r\n\r\nDelivery duties are included in the item price when shipping to all EU countries (excluding the Canary Islands), plus The United Kingdom, USA, Canada, China Mainland, Australia, New Zealand, Puerto Rico, Switzerland, Singapore, Republic Of Korea, Kuwait, Mexico, Qatar, India, Norway, Saudi Arabia, Taiwan Region, Thailand, U.A.E., Japan, Brazil, Isle of Man, San Marino, Colombia, Chile, Argentina, Egypt, Lebanon, Hong Kong SAR, and Bahrain. All import duties are included in your order – the price you see is the price you pay.",
                Price = 1980000,
                Quantity = 1,
                Discount = 15,
                Images = new List<Image>
                {
                    new Image
                    {
                        Id = 40,
                        Name = "AGOLDE",
                        Url = "https://cdn-images.farfetch-contents.com/22/67/71/27/22677127_52785222_1000.jpg"
                    },
                    new Image
                    {
                        Id = 41,
                        Name = "AGOLDE",
                        Url = "https://cdn-images.farfetch-contents.com/22/67/71/27/22677127_52785197_1000.jpg"
                    },
                    new Image
                    {
                        Id = 40,
                        Name = "AGOLDE",
                        Url = "https://cdn-images.farfetch-contents.com/22/67/71/27/22677127_52785195_1000.jpg"
                    },
                    new Image
                    {
                        Id = 41,
                        Name = "AGOLDE",
                        Url = "https://cdn-images.farfetch-contents.com/22/67/71/27/22677127_52785198_1000.jpg"
                    }
                }
            });

            return _products;
        }
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

    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; } = string.Empty;
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsHome { get; set; } = false;
        public List<Product> Products { get; set; } =[];
    }

    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Sku { get; set; } = "";
        public string Name { get; set; } = "";
        public string Slug { get; set; } = "";
        public decimal Price { get; set; }
        public string Description { get; set; } = "";
        public List<Image> Images { get; set; } = [];
        public float Discount { get; set; } = 0;
        public int Quantity { get; set; } = 0;
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

    
    public class ShopViewModel
    {
        public List<Category> Categories { get; set; } = [];
        public List<Product> Products { get; set; } = [];
    }
}
