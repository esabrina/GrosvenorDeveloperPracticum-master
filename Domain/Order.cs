using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    /// <summary>
    /// Contains the daytime menu and the list of dishes requested
    /// </summary>
    public class Order
    {
        public Menu Menu { get; set; } 
        public List<int> Dishes { get; set; }

        public Order(string menu)
        {
            Dishes = new List<int>();
            Menu = ParseDaytime(menu);
        }

        /// <summary>
        /// Validate and convert string to enum Menu
        /// </summary>
        private Menu ParseDaytime(string str)
        {
            var daytimeFound = Enum.GetValues(typeof(Menu)).OfType<object>()
                                .FirstOrDefault(v => v.ToString() == str.Trim().ToLowerInvariant());
            if (daytimeFound == null) throw new ArgumentException($"Menu {str} does not exist.");

           return (Menu) daytimeFound;
        }

    }
}