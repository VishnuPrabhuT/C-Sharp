using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Entities;

namespace ToDoList
{
    public class ToDoListRepository : IToDoListRepository
    {
        private ToDoListContext _cxt;
        public ToDoListRepository(ToDoListContext cxt)
        {
            _cxt = cxt;
        }

        public IEnumerable<NoteEntity> GetNotes()
        {
            return _cxt.Notes.OrderBy(c => c.Id).ToList();
        }
    }
}
