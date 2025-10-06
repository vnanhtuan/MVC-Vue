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
                },
                new()
                {
                    Id = 2,
                    Name = "Shop"
                },
                new()
                {
                    Id = 2,
                    Name = "About us"
                }
            };
            return menuData;
        }
    }
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; } = string.Empty;
    }
}
