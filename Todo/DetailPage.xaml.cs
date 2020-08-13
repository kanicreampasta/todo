using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Todo
{
    public partial class DetailPage : ContentPage
    {
        public DetailPage(Todo todo)
        {
            this.todo = todo;
            Title = todo.Name;
            InitializeComponent();
        }

        private readonly Todo todo;

        public string TodoName {
            get => todo.Name;
            set => todo.Name = value;
        }
        public DateTime AlertTime { get; set; }
    }
}
