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
    public partial class MainForm : Form
    {
        private readonly TodoServiceClass _todoService;
        private List<ModelsTodoClass> _todos;

        public MainForm(TodoServiceClass todoService)
        {
            InitializeComponent();
            _todoService = todoService;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadTodos();
        }

        private void LoadTodos()
        {
            _todos = _todoService.GetTodos();
            todoDataGridView.DataSource = null; // Clear existing binding
            todoDataGridView.DataSource = _todos;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var addForm = new AddToDoForm(_todoService);
            addForm.ShowDialog();
            LoadTodos();
        }

        private void editButton_click(object sender, EventArgs e)
        {
            if (todoDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a todo to edit.");
                return;
            }

            var selectedTodo = (ModelsTodoClass)todoDataGridView.SelectedRows[0].DataBoundItem;
            var editForm = new EditToDoForm(_todoService, selectedTodo);
            editForm.ShowDialog();
            LoadTodos();
        }

        private void deleteButton_click(object sender, EventArgs e)
        {
            if (todoDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a todo to delete.");
                return;
            }

            var selectedTodo = (ModelsTodoClass)todoDataGridView.SelectedRows[0].DataBoundItem;

            var result = MessageBox.Show(
                "Are you sure you want to delete this todo?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _todoService.DeleteTodo(selectedTodo.id);
                LoadTodos();
            }
        }
    }
}