using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Data.SqlClient;
using TodoApi.Config;
using TodoApi.Dto;

namespace TodoApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly DatabaseConnection _database;
        private readonly ILogger<TodoController> _logger;

        public TodoController(
            DatabaseConnection database,
            ILogger<TodoController> logger
            )
        {
            _database = database;
            _logger = logger;
        }

        [HttpGet]
        [Route("todos")]
        public async Task<IActionResult> GetAllDataTodos()
        {
            try
            {
                var userId = HttpContext.Items["userId"]?.ToString();
                var username = HttpContext.Items["username"]?.ToString();
                var role = HttpContext.Items["role"]?.ToString();
                var listTodos = new List<TodoDto>();

                if (role?.ToLower() != "admin")
                {
                    return StatusCode(403, new
                    {
                        success = false,
                        message = "Forbidden!"
                    });
                }

                using var connection = _database.GetConnection();
                await connection.OpenAsync();
                const string query = @"SELECT * FROM todos WHERE deleted_at IS NULL";

                using var command = new SqlCommand(query, connection);

                using var reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        var data = new TodoDto
                        {
                            UserId = Convert.ToInt32(reader["user_id"]),
                            Title = reader["title"].ToString(),
                            Description = reader["description"].ToString(),
                            CreatedAt = Convert.ToDateTime(reader["created_at"]),
                        };

                        listTodos.Add(data);
                    }

                    return Ok(new
                    {
                        success = true,
                        message = "Successfully get data todos.",
                        data = listTodos
                    });
                } else
                {
                    return NotFound(new
                    {
                        success = false,
                        message = "Data todos not found!"
                    });
                }
            } catch (Exception ex)
            {
                _logger.LogError(ex, "Error while getting data todos!");
                return StatusCode(500, new
                {
                    success = false,
                    message = "Internal server error!"
                });
            }
        }

        [HttpPost]
        [Route("todos")]
        public async Task<IActionResult> InsertDataTodo([FromBody] TodoDto todo)
        {
            try
            {
                using var connection = _database.GetConnection();
                await connection.OpenAsync();
                const string query = @"INSERT INTO [todos] (title, description, created_at) VALUES (@title, @desc, @createdAt)";

                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@title", todo.Title);
                command.Parameters.AddWithValue("@desc", todo.Description);
                command.Parameters.AddWithValue("@createdAt", DateTime.Now);

                var data = new
                {
                    title = todo.Title,
                    description = todo.Description,
                    created_at = DateTime.Now,
                };

                int affectedRows = await command.ExecuteNonQueryAsync();

                if (affectedRows > 0)
                {
                    return Ok(new
                    {
                        success = true,
                        message = "Successfully insert data todo.",
                        data
                    });
                } else
                {
                    return StatusCode(500, new
                    {
                        success = false,
                        message = "Failed to insert data todo!"
                    });
                }
            } catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error while insert data!");
                return StatusCode(500, new
                {
                    success = false,
                    message = "Internal server error!"
                });
            }
        }

        [HttpGet]
        [Route("todos/{id}")]
        public async Task<IActionResult> GetDataTodoById(int id)
        {
            try
            {
                var userId = HttpContext.Items["userId"]?.ToString();
                var username = HttpContext.Items["username"]?.ToString();
                var role = HttpContext.Items["role"]?.ToString();

                if (username == null)
                {
                    return Unauthorized(new
                    {
                        success = false,
                        message = "Unauthorized"
                    });
                }

                if (role?.ToLower() != "admin")
                {
                    return StatusCode(403, new
                    {
                        success = false,
                        message = "Forbidden"
                    });
                }

                using var connection = _database.GetConnection();
                await connection.OpenAsync();
                const string query = @"SELECT * FROM [todos] WHERE id = @id AND deleted_at IS NULL";

                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                using var reader = await command.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    var todo = new
                    {
                        id = reader["id"].ToString(),
                        title = reader["title"].ToString(),
                        description = reader["description"].ToString(),
                        createdAt = Convert.ToDateTime(reader["created_at"]),
                    };

                    return Ok(new
                    {
                        success = true,
                        message = "Successfully get data todo.",
                        data = todo
                    });
                } else
                {
                    return NotFound(new
                    {
                        success = false,
                        message = "Todo not found!"
                    });
                }
            } catch (Exception ex)
            {
                _logger.LogError(ex, "Error in get data todo by id!");
                return StatusCode(500, new
                {
                    success = false,
                    message = "Internal server error!"
                });
            }
        }

        [HttpPut]
        [Route("todos/{id}")]
        public async Task<IActionResult> UpdateDataById([FromBody] TodoDto todo, int id)
        {
            try
            {
                var userId = HttpContext.Items["userId"]?.ToString();
                var username = HttpContext.Items["username"]?.ToString();
                var role = HttpContext.Items["role"]?.ToString();

                if (username == null)
                {
                    return Unauthorized(new
                    {
                        success = false,
                        message = "Unauthorized"
                    });
                }

                if (role?.ToLower() != "admin")
                {
                    return StatusCode(403, new
                    {
                        success = false,
                        message = "Forbidden"
                    });
                }

                using var connection = _database.GetConnection();
                await connection.OpenAsync();
                const string query = @"UPDATE [todos] SET title = @title, description = @desc WHERE id = @idWhere";

                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@title", todo.Title);
                command.Parameters.AddWithValue("@desc", todo.Description);
                command.Parameters.AddWithValue("@idWhere", id);

                int affectedRows = await command.ExecuteNonQueryAsync();

                if (affectedRows > 0)
                {
                    return Ok(new
                    {
                        success = true,
                        message = "Successfully updated data todo."
                    });
                } else
                {
                    return StatusCode(500, new
                    {
                        success = false,
                        message = "Failed to update data todo!"
                    });
                }
            } catch (Exception ex)
            {
                _logger.LogError(ex, "Error while update data todos!");
                return StatusCode(500, new
                {
                    success = false,
                    message = "Internal server error!"
                });
            }
        }

        [HttpDelete]
        [Route("todos/{id}")]
        public async Task<IActionResult> DeleteDataTodo(int id)
        {
            try
            {
                using var connection = _database.GetConnection();
                await connection.OpenAsync();
                const string query = @"UPDATE [todos] SET deleted_at = @dateNow WHERE id = @id";

                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@dateNow", DateTime.Now.ToString());
                command.Parameters.AddWithValue("@id", id);

                int affectedRows = await command.ExecuteNonQueryAsync();

                if (affectedRows > 0)
                {
                    return Ok(new
                    {
                        success = true,
                        message = "Successfully delete data todo."
                    });
                } else
                {
                    return StatusCode(500, new
                    {
                        success = false,
                        message = "Failed to delete data todo!"
                    });
                }
            } catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Error while deleting todo!");
                return StatusCode(500, new
                {
                    success = false,
                    message = "Internal server error!"
                });
            }
        }
    }
}
