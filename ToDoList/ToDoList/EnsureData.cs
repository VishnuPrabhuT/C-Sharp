using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Entities;

namespace ToDoList
{
    public static class EnsureData
    {
        public static void EnsureSeedData(this ToDoListContext cxt)
        {
            if (cxt.Notes.Any())
            {
                return;
            }
            var notes = new List<NoteEntity>()
            {
                new NoteEntity()
                {
                     Id = 1,
                     NoteContent = "Go to sleep!",
                     IsCompleted = true
                },
                new NoteEntity()
                {
                     Id = 2,
                     NoteContent = "Wake Up!!",
                     IsCompleted = true
                }
        };
            cxt.Notes.AddRange(notes);
            cxt.SaveChanges();
        }
    }
}


