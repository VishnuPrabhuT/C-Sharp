using GroceryListApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryListApp
{
    public interface IGroceryListRepository
    {
        IEnumerable<GroceryListEntity> GetGroceries();
    }
}
