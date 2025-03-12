using System.Collections.Concurrent;
using OpenableProject.Controllers;
using OpenableProject.Models;

namespace OpenableProject.Storage;

public static class MenuStorage
{
    private static int _menuId;

    private static readonly ConcurrentDictionary<int, Menu> CurrentMenus = new();

    static MenuStorage()
    {
        // 在构造函数中初始化字典
        CurrentMenus.TryAdd(1, new Menu()
        {
            RestaurantId = 1,
            Meals = new List<Meal>()
            {
                new Meal { Id = 1, Name = "雞腿便當" },
                new Meal { Id = 2, Name = "排骨便當" },
            }
        });
        CurrentMenus.TryAdd(2, new Menu()
        {
            RestaurantId = 2,
            Meals = new List<Meal>()
            {
                new Meal { Id = 3, Name = "漢堡" },
                new Meal { Id = 4, Name = "炸雞" }
            }
        });
    }

    public static Menu Add(Menu menu)
    {
        throw new NotImplementedException();
    }

    public static Menu AddByOperator(Menu menu)
    {
        throw new NotImplementedException();
    }

    public static List<Menu> GetAll()
    {
        return CurrentMenus.Values.ToList();
    }

    public static List<Menu> GetByRestaurantId(int restaurantId)
    {
        return CurrentMenus.Values.Where(x => x.RestaurantId == restaurantId).ToList();
    }

    public static bool Delete(int menuId)
    {
        throw new NotImplementedException();
    }
}