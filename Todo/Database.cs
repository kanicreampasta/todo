using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace Todo
{
    public class Database
    {
        private readonly SQLiteAsyncConnection database;

        public Database(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<TodoRecord>().Wait();
        }

        public Task<List<TodoRecord>> GetTodoRecordAsync()
        {
            return database.Table<TodoRecord>().ToListAsync();
        }

        public Task<int> InsertTodoRecordAsync(TodoRecord record)
        {
            return database.InsertAsync(record);
        }

        public Task<List<Todo>> GetTodoAsync()
        {
            return GetTodoRecordAsync()
                    .ContinueWith(t => t.Result.Select(tr => tr.ToTodo()).ToList());
        }

        public Task<int> InsertTodoAsync(Todo todo)
        {
            var record = new TodoRecord();
            record.Name = todo.Name;
            return database.InsertAsync(record);
        }
    }
}
