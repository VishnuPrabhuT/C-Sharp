using GroceryListApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryListApp
{
    public class GroceryListRepository : IGroceryListRepository
    {
        private GroceryListContext _context;
        public GroceryListRepository(GroceryListContext context)
        {
            _context = context;
        }
        public IEnumerable<GroceryListEntity> GetGroceries()
        {
            return _context.GroceryList.ToList();
        }
    }
}
