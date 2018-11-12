using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GroceryListApp.Entity;
using GroceryListApp.Model;
using Newtonsoft.Json;

namespace GroceryListApp.Controllers
{
    [Route("api/GroceryList")]
    [Produces("application/json")]
    [ApiController]
    public class GroceryListController : ControllerBase
    {
        private GroceryListContext _context;
        private IGroceryListRepository _repository;
        public GroceryListController(GroceryListContext context, IGroceryListRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        // GET: api/GroceryList
        [HttpGet]
        public IActionResult GroceryList()
        {
            var result = _repository.GetGroceries();            
            return Ok(result);
        }

        // GET: api/GroceryList/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroceryListModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var groceryList = await _context.GroceryList.FindAsync(id);

            if (groceryList == null)
            {
                return NotFound();
            }

            return Ok(groceryList);
        }

        [HttpPut()]
        public async Task<IActionResult> PutGroceryListModel([FromBody] GroceryListModel groceryListModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //IEnumerable<GroceryListEntity> items = from row in _context.GroceryList
            //                                       where row.Checked == !groceryListModel.isChecked
            //                                       select new GroceryListEntity
            //                                       {
            //                                           row.Checked = groceryListModel.isChecked
            //                                       };
            IEnumerable<GroceryListEntity> items = _context.GroceryList.Where(item => item.Checked == !groceryListModel.isChecked);
            items = items.Select(item => { item.Checked = groceryListModel.isChecked; return item; });
            _context.UpdateRange(items);

            //_context.Entry(groceryListModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // PUT: api/GroceryList/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroceryListModel([FromRoute] int id, [FromBody] GroceryListModel groceryListModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != groceryListModel.id)
            {
                return BadRequest();
            }
            GroceryListEntity item = _context.GroceryList.Find(id);
            item.Checked = groceryListModel.isChecked;
            item.Quantity = groceryListModel.quantity;
            _context.Update(item);
            
            //_context.Entry(groceryListModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroceryListModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/GroceryList
        [HttpPost]
        public async Task<IActionResult> PostGroceryListModel([FromBody] GroceryListModel groceryListModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            GroceryListEntity groceryListItem = new GroceryListEntity { Price = groceryListModel.price, Quantity = groceryListModel.quantity, Checked = groceryListModel.isChecked, Description = groceryListModel.description, Expiry_Date = groceryListModel.expiryDate, Item_Name = groceryListModel.itemName }; 
            _context.GroceryList.Add(groceryListItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroceryListModel", new { ID = groceryListModel.id }, groceryListModel);
        }

        // DELETE: api/GroceryList/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroceryListModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var groceryListModel = await _context.GroceryList.FindAsync(id);
            if (groceryListModel == null)
            {
                return NotFound();
            }

            _context.GroceryList.Remove(groceryListModel);
            await _context.SaveChangesAsync();

            return Ok(groceryListModel);
        }

        private bool GroceryListModelExists(int id)
        {
            return _context.GroceryList.Any(e => e.ID == id);
        }
    }
}