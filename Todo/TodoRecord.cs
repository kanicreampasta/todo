using System;
using SQLite;

namespace Todo
{
    public class TodoRecord
    {
        [PrimaryKey, AutoIncrement]
        public int ID {get; set;}
        public string Name { get; set; }

        public Todo ToTodo()
        {
            return new Todo(Name);
        }

        public TodoRecord(int id, Todo t)
        {
            ID = id;
            Name = t.Name;
        }

        public TodoRecord()
        { }
    }
}
