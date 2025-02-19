namespace OpenableProject.Services;
using OpenableProject.Model;

public class MenuService : IMenuService
{
    private static readonly List<Menu?> Menu = new List<Menu?>
    {
        new Menu
        { 
            RestaurantId = 0,
            MenuId = 001, 
            Name = "麻油雞鍋",
            Price = 450
        },
        new Menu
        { 
            RestaurantId = 0,
            MenuId = 002, 
            Name = "石頭鍋",
            Price = 350
        },
        new Menu
        { 
            RestaurantId = 1,
            MenuId = 001, 
            Name = "雞腿便當",
            Price = 110
        },
    };

    public IEnumerable<Menu> GetMenuByRestaurantId(int id)
    {
        var menus = Menu.Where(r => r != null && r.RestaurantId == id);
        return menus;
    }
}