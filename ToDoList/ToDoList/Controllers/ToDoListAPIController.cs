using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Entities;
using ToDoList.Model;

namespace ToDoList.Controllers
{
    [Route("api/getnotes")]
    public class ToDoListAPIController : Controller
    {
        private ToDoListContext _cxt;
        private IToDoListRepository _repo;
        public ToDoListAPIController(ToDoListContext cxt, IToDoListRepository repo)
        {
            _cxt = cxt;
            _repo = repo;
        }
        [HttpGet()]
        public IActionResult GetNotes()
        {
            var result = _repo.GetNotes();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddNote([FromBody] NoteModel note)
        {
            NoteEntity item = new NoteEntity { Id = _cxt.Notes.Count() + 1, NoteContent = note.NoteContent, IsCompleted = note.IsCompleted };
            _cxt.Notes.Add(item);
            _cxt.SaveChanges();
            return CreatedAtRoute("ToDoList", item, note);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateNote(int id)
        {
            NoteEntity item = _cxt.Notes.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            item.IsCompleted = !(item.IsCompleted);
            _cxt.Notes.Update(item);
            _cxt.SaveChanges();
            return Ok();  
        }
    }
}
