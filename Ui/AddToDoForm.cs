using System.Windows.Forms;
using System;
using ToDoApp.Model;
using ToDoApp.Services;

namespace ToDoApp.Ui
{
    public partial class AddToDoForm : Form
    {
        private readonly TodoServiceClass _todoService;

        public AddToDoForm(TodoServiceClass todoService)
        {
            InitializeComponent();
            _todoService = todoService;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var todo = new ModelsTodoClass
            {
                title = titleTextBox.Text,
                description = descriptionTextBox.Text,
                dueDate = dueDatePicker.Value,
                isCompleted = false
            };

            _todoService.AddTodo(todo);
            this.Close();
        }
    }
}
