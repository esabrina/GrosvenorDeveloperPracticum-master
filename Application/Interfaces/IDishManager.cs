using Domain;
using System.Collections.Generic;

namespace Application.Interfaces
{

    public interface IDishManager
    {
        /// <summary>
        /// Constructs a list of dishes, each dish with a name and a count
        /// </summary>
        /// <param name="order">daytime menu with a list of dishes</param>
        /// <returns></returns>
        List<Dish> GetDishes(Order order);
    }
}