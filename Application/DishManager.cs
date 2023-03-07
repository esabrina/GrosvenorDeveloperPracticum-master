using Application.Contracts;
using Application.Interfaces;
using Domain;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    public class DishManager : IDishManager
    {
        private readonly IDishRepository _dishRepository;

        public DishManager(IDishRepository dishRepository)
        {
            _dishRepository = dishRepository;
        }


        /// <summary>
        /// Takes an Order object, sorts the orders and builds a list of dishes to be returned. 
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public List<Dish> GetDishes(Order order)
        {
            var returnValue = new List<Dish>();
            order.Dishes.Sort();
            foreach (var dishType in order.Dishes)
            {
                AddOrderToList(new RequestOrderItemDto(order.Menu, dishType), returnValue);
            }
            return returnValue;
        }

        /// <summary>
        /// Receives the requested order. Takes the dish as an int, representing an order type, tries to find it in the list.
        /// If the dish type does not exist, add it and set count to 1
        /// If the type exists, check if multiples are allowed and increment that instances count by one
        /// else throw error
        /// </summary>
        /// <param name="RequestOrderItemDto">A requested order with the daytime menu and one dish</param>
        /// <param name="returnValue">a list of dishes, - get appended to or changed </param>
        private void AddOrderToList(RequestOrderItemDto requestOrder, List<Dish> returnValue)
        {
            var requestedDish = GetDishOrder(requestOrder);
            var existingOrder = returnValue.SingleOrDefault(x => x.Menu == requestedDish.Menu && x.DishName == requestedDish.DishName);
            if (existingOrder == null)
            {
                requestedDish.Count = 1;
                returnValue.Add(requestedDish);
            }
            else if (IsMultipleAllowed(requestedDish))
                existingOrder.Count++;
            else
                throw new ArgumentException(string.Format("Multiple {0}(s) not allowed", requestedDish.DishName));
        }

        /// <summary>
        /// Get requested dish metadata from a requested order item. 
        /// Receives the requested order item (daytime menu and dish) and check if it exists in available dishes.
        /// If the dish type does not exist for the specific daytime menu, throw error.
        /// </summary>
        /// <param name="RequestOrderItemDto">A requested order with the daytime menu and one dish</param>
        /// <returns>Requested dish metadata</returns>
        private Dish GetDishOrder(RequestOrderItemDto requestOrder)
        {
            var orderFound = _dishRepository.Get(requestOrder.Menu, requestOrder.DishId);
            if (orderFound == null) throw new ArgumentException("Order does not exist");

            return orderFound;
        }

        /// <summary>
        /// Check if dish can be ordered multiple times. 
        /// Receives the requested order item (daytime menu and dish) and check if it exists in available dishes.
        /// </summary>
        /// <param name="requestedDish">A requested dish metadata</param>
        /// <returns>True if can be ordered multiple times, other False.</returns>
        private bool IsMultipleAllowed(Dish requestedDish) => requestedDish.MultipleOrderAllowed;
    }
}