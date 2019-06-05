using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GroceryListVue.Entity;
using GroceryListVue.Model;

namespace GroceryListVue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroceryListController : HomeController
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
        public IActionResult GetGroceryList()
        {
            return Ok(_repository.GetGroceries());
        }

        // GET: api/GroceryList/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroceryListModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var groceryListModel = await _context.GroceryListModel.FindAsync(id);

            if (groceryListModel == null)
            {
                return NotFound();
            }

            return Ok(groceryListModel);
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

            _context.Entry(groceryListModel).State = EntityState.Modified;

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

            _context.GroceryListModel.Add(groceryListModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroceryListModel", new { id = groceryListModel.id }, groceryListModel);
        }

        // DELETE: api/GroceryList/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroceryListModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var groceryListModel = await _context.GroceryListModel.FindAsync(id);
            if (groceryListModel == null)
            {
                return NotFound();
            }

            _context.GroceryListModel.Remove(groceryListModel);
            await _context.SaveChangesAsync();

            return Ok(groceryListModel);
        }

        private bool GroceryListModelExists(int id)
        {
            return _context.GroceryListModel.Any(e => e.id == id);
        }
    }
}
