using System.Collections.Generic;


namespace Domain.Interfaces
{
    public interface IDishRepository
    {
        public IEnumerable<Dish> GetAll();
        public Dish Get(Menu menu, int id);
    }
}
