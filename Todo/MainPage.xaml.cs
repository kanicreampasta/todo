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

            Todos.Add(new Todo("tesuto"));

            todoList.BindingContext = this;
        }

        void OnAddButtonClicked(object sender, EventArgs e)
        {
            Debug.WriteLine("userInput: " + userInput.Text);
            if (!userInput.Text.Equals(""))
            {
                Todos.Add(new Todo(userInput.Text));
                Debug.WriteLine("Number of Todos: " + Todos.Count);
            }

            userInput.Text = "";
        }

        public ObservableCollection<Todo> Todos { get; private set; }
    }
}
