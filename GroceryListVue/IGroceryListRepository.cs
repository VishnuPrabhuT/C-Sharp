using GroceryListVue.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryListVue
{
    public interface IGroceryListRepository
    {
        IEnumerable<GroceryListEntity> GetGroceries();
    }
}
