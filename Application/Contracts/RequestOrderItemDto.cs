using Domain;

namespace Application.Contracts
{

    /// <summary>
    /// Represents each item of an order
    /// </summary>
    /// <param name="menu">enum, represents the daytime menu</param>
    /// <param name="order">int, represents a requested dish</param>
    public class RequestOrderItemDto
    {
        public Menu Menu { get; set; }
        public int DishId { get; set; }

        public RequestOrderItemDto(Menu menu, int dishId)
        {
            Menu = menu;
            DishId = dishId;
        }   
    }
}
