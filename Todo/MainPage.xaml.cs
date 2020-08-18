using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace Todo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Todos = new ObservableCollection<Todo>();
            Title = "Simple Todo";

            todoList.BindingContext = this;

            var savedTodos = App.Database.GetTodoAsync().GetAwaiter().GetResult();
            foreach (var savedTodo in savedTodos)
            {
                Todos.Add(savedTodo);
            }
        }

        void OnAddButtonClicked(object sender, EventArgs e)
        {
            Debug.WriteLine("userInput: " + userInput.Text);
            if (!userInput.Text.Equals(""))
            {
                var todo = new Todo(userInput.Text);
                Todos.Add(todo);
                Debug.WriteLine("Number of Todos: " + Todos.Count);
                App.Database.InsertTodoAsync(todo);
            }

            userInput.Text = "";
        }

        public ObservableCollection<Todo> Todos { get; private set; }

        async void OnTodoItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            Todo todo = e.SelectedItem as Todo;
            Debug.WriteLine("TODO selected: " + todo.ToString());
            await Navigation.PushAsync(new DetailPage(todo));
            (sender as ListView).SelectedItem = null;
        }
    }
}
