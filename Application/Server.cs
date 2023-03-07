using Application.Interfaces;
using Domain;
using System;
using System.Collections.Generic;

namespace Application
{
    public class Server : IServer
    {
        private readonly IDishManager _dishManager;

        public Server(IDishManager dishManager)
        {
            _dishManager = dishManager;
        }

        public string TakeOrder(string unparsedOrder)
        {
            try
            {
                Order order = ParseOrder(unparsedOrder);
                List<Dish> dishes = _dishManager.GetDishes(order);
                string returnValue = FormatOutput(dishes);
                return returnValue;
            }
            catch (ArgumentException)
            {
                return "error";
            }
        }

        private void RaiseOrderItemError() => throw new ArgumentException("Order needs to be comma separated list of numbers");

        private Order ParseOrder(string unparsedOrder)
        {
            var orderItems = unparsedOrder.Split(',');
            var returnValue = new Order(orderItems[0])
            {
                Dishes = new List<int>()
            };

            // list order must have at least two items (a daytime menu and a dish)
            if (orderItems.Length < 2) RaiseOrderItemError();

            for (int i = 1; i < orderItems.Length; i++)
            {
                if (int.TryParse(orderItems[i], out int parsedOrder))
                    returnValue.Dishes.Add(parsedOrder);
                else
                    RaiseOrderItemError();
            }

            return returnValue;
        }

        private string FormatOutput(List<Dish> dishes)
        {
            var returnValue = "";

            foreach (var dish in dishes)
            {
                returnValue = returnValue + string.Format(",{0}{1}", dish.DishName, GetMultiple(dish.Count));
            }

            if (returnValue.StartsWith(","))
            {
                returnValue = returnValue.TrimStart(',');
            }

            return returnValue;
        }

        private object GetMultiple(int count)
        {
            if (count > 1)
            {
                return string.Format("(x{0})", count);
            }
            return "";
        }
    }
}
