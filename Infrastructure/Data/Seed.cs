using Domain;
using System.Collections.Generic;


namespace Infrastructure.Data
{
    /// <summary>
    /// Load pre-defined static data to memory
    /// </summary>
    public static class Seed
    {
        public static IEnumerable<Dish> LoadDishes()
        {
            var dishes = new List<Dish>
            {
                // for morning
                new Dish(Menu.morning, 1, "egg", Course.entree, false),
                new Dish(Menu.morning, 2, "toast", Course.side, false),
                new Dish(Menu.morning, 3, "coffee", Course.drink, true),

                // for evening
                new Dish(Menu.evening, 1, "steak", Course.entree, false),
                new Dish(Menu.evening, 2, "potato", Course.side, true),
                new Dish(Menu.evening, 3, "wine", Course.drink, false),
                new Dish(Menu.evening, 4, "cake", Course.dessert, false)
            };
            return dishes;
        }

    }
}
