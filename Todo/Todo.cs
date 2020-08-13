using System;
namespace Todo
{
    public class Todo
    {
        public string Name { get; set; }

        public Todo(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
