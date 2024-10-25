using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using ToDoApp.Model;
using Microsoft.Extensions.Configuration;
namespace ToDoApp.Services
{
    public class TodoServiceClass
    {
        private readonly string _connectionString;

        public TodoServiceClass(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("TodoDB");
        }

        // Create New Todo
        public void AddTodo(ModelsTodoClass todo) { 
            using (var conn = new NpgsqlConnection(_connectionString))
            {

                conn.Open();
                using (var cmd = new NpgsqlCommand(
                    "INSERT INTO todos (title, desc, due_date, is_completed) VALUES (@title, @desc, @duedate, @completed)", conn
                    ))
                    {
                    cmd.Parameters.AddWithValue("title", todo.title);
                    cmd.Parameters.AddWithValue("desc", (object)todo.description ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("duedate", todo.dueDate);
                    cmd.Parameters.AddWithValue("completed", todo.isCompleted);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        // Get All Todos
        public List<ModelsTodoClass> GetTodos()
        {

            var todos = new List<ModelsTodoClass>();

            using (var conn = new NpgsqlConnection(_connectionString))
            {

                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM todos", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            todos.Add(new ModelsTodoClass
                            {
                                id = reader.GetInt32(0),
                                title = reader.GetString(1),
                                description = reader.IsDBNull(2) ? null : reader.GetString(2),
                                dueDate = reader.GetDateTime(3),
                                isCompleted = reader.GetBoolean(4)
                            });
                        }
                    }
                }
            }
            return todos;
        }

        // Update a Todo
        public void updateTodo(ModelsTodoClass todo)
        {
            using (var conn = new NpgsqlConnection(_connectionString
                ))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(
                    "UPDATE todos SET title = @title, desc = @desc, due_date = @duedate, is_completed = @completed WHERE id = @id ", conn
                    )) {
                    cmd.Parameters.AddWithValue("title", todo.title);
                    cmd.Parameters.AddWithValue("desc", (object)todo.description ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("duedate", todo.dueDate);
                    cmd.Parameters.AddWithValue("completed", todo.isCompleted);
                    cmd.ExecuteNonQuery();
                
                }
            }
        }

    // Delete a Todo
    public void DeleteTodo(int id)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand (
                   "DELETE FROM todos WHERE id = @id"
                    , conn)) {
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
