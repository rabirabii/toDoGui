using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToDoApp.Model;
using ToDoApp.Services;

namespace ToDoApp.Ui
{
    public partial class EditToDoForm : Form
        
    {
        private readonly TodoServiceClass _todoService;
        private ModelsTodoClass _todo;
        public EditToDoForm(TodoServiceClass todoService, ModelsTodoClass todo)
        {
            InitializeComponent();
            _todoService = todoService;
            _todo = todo;

            titleTextBox.Text = _todo.title;
            descriptionTextBox.Text = _todo.description;
            dueDatePicker.Value = _todo.dueDate;
        }

        private void saveButton_click(object sender, EventArgs e)
        {
            _todo.title = titleTextBox.Text;
            _todo.description = descriptionTextBox.Text;
            _todo.dueDate = dueDatePicker.Value;

            _todoService.updateTodo(_todo);
            this.Close();
        }
    }
}
