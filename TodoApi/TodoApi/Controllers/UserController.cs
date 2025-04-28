using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Data.SqlClient;
using TodoApi.Config;
using TodoApi.Dto;
using TodoApi.Helpers;

namespace TodoApi.Controllers
{
    [Route("api/auth/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DatabaseConnection _database;
        private readonly ILogger<UserController> _logger;
        public UserController(
            DatabaseConnection database,
            ILogger<UserController> logger
            )
        {
            _database = database;
            _logger = logger;
        }

        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register(UserDto user)
        {
            try
            {
                var hasherPassword = new PasswordHashHelper();
                if (!ModelState.IsValid)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = ModelState.ToString()
                    });
                }

                using var connection = _database.GetConnection();
                await connection.OpenAsync();
                const string query = @"INSERT INTO [users] (username, email, password, role) VALUES (@username, @email, @password, @role)";

                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", user.Username?.Trim());
                command.Parameters.AddWithValue("@email", user.Email?.Trim());
                command.Parameters.AddWithValue("@password", hasherPassword.PasswordHash(user.Password?.Trim()));
                command.Parameters.AddWithValue("@role", string.IsNullOrEmpty(user.Role) ? DBNull.Value : user.Role?.Trim());

                int affectedRows = await command.ExecuteNonQueryAsync();

                if (affectedRows > 0)
                {
                    return Ok(new
                    {
                        success = true,
                        message = "Successfully regiter!",
                        data = new UserDto
                        {
                            Username = user.Email,
                            Email = user.Email,
                            Role = user.Role,
                        } 
                    });
                } else
                {
                    return StatusCode(500, new
                    {
                        success = false,
                        message = "Internal server error!"
                    });
                }
            } catch (Exception ex)
            {
                _logger.LogError(ex, "Error in register user!");
                return StatusCode(500, new
                {
                    success = false,
                    message = "Internal server error!"
                });
            }
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto login)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = ModelState.ToString()
                    });
                }

                var hasherPassword = new PasswordHashHelper();
                var hasherToken = new TokenHashHelper();

                var token = Guid.NewGuid().ToString();
                var expiredDateTime = DateTime.Now.AddHours(2);
                var tokenHashed = hasherToken.HashToken(token);

                using var connection = _database.GetConnection();
                await connection.OpenAsync();
                const string query = @"SELECT * FROM [users] WHERE email = @email";

                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@email", login.Email?.Trim());

                using var reader = await command.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    if (hasherPassword.VerifyPasswordHash(reader["password"].ToString(), login.Password))
                    {
                        InsertToSessionUsers(Convert.ToInt32(reader["id"]), tokenHashed, expiredDateTime);

                        return Ok(new
                        {
                            success = true,
                            message = "Successfuly login!",
                            data = new
                            {
                                username = reader["username"],
                                email = reader["email"],
                                role = reader["role"]
                            },
                            token = tokenHashed,
                            expired_at = expiredDateTime
                        });
                    } else
                    {
                        return StatusCode(401, new
                        {
                            success = false,
                            message = "Email and password wrong!"
                        });
                    }

                } else
                {
                    return StatusCode(401, new
                    {
                        success = false,
                        message = "Email and password wrong!"
                    });
                }
            } catch (Exception ex)
            {
                _logger.LogError(ex, "Error in login user!");
                return StatusCode(500, new
                {
                    success = false,
                    message = "Internal server error!",
                });
            }
        }

        private async Task InsertToSessionUsers(int userId, string token, DateTime expiredAt)
        {
            try
            {
                using var connection = _database.GetConnection();
                await connection.OpenAsync();
                const string query = @"INSERT INTO [session_users] (user_id, token, expired_at) VALUES (@userId, @token, @expiredAt)";

                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@userId", userId.ToString().Trim());
                command.Parameters.AddWithValue("@token", token?.Trim());
                command.Parameters.AddWithValue("@expiredAt", expiredAt.ToString().Trim());

                await command.ExecuteNonQueryAsync();
            } catch (Exception ex)
            {
                _logger.LogError(ex, "Error while insert to session users!");
            }
        }
    }
}
