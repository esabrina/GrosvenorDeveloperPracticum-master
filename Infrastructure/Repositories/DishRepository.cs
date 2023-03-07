using Domain;
using Domain.Interfaces;
using Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class DishRepository: IDishRepository
    {
        private readonly IEnumerable<Dish> _context;

        public DishRepository() => _context = Seed.LoadDishes();

        public IEnumerable<Dish> GetAll() => _context;

        public Dish Get(Menu menu, int id)
        {
            return _context.SingleOrDefault(x => x.Menu == menu && x.Id == id);
        }
    }
}
