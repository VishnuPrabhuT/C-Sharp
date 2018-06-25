using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Entities;

namespace ToDoList
{
    public interface IToDoListRepository
    {
        IEnumerable<NoteEntity> GetNotes();
    }
}
