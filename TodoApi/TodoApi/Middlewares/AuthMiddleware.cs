using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using TodoApi.Config;

namespace TodoApi.Middlewares
{
    public class AuthMiddleware
    {
        private readonly DatabaseConnection _database;
        private readonly RequestDelegate _next;
        private readonly ILogger<AuthMiddleware> _logger;
        public AuthMiddleware(
            RequestDelegate next,
            DatabaseConnection database,
            ILogger<AuthMiddleware> logger)
        {
            _database = database;
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                var path = context.Request.Path.Value;

                if (path.StartsWith("/api/auth/register") ||
                    path.StartsWith("/api/auth/login") ||
                    path.StartsWith("/swagger")
                    )
                {
                    await _next(context);
                    return;
                }

                if (context.Request.Headers.TryGetValue("Authorization", out var authHeader))
                {
                    var headerValue = authHeader.ToString();
                    var token = headerValue.StartsWith("Bearer ") ? headerValue.Substring("Bearer ".Length).Trim() : null;

                    if (token == null)
                    {
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        await context.Response.WriteAsJsonAsync(new
                        {
                            success = false,
                            message = "Unauthorized"
                        });
                        return;
                    }

                    using var connection = _database.GetConnection();
                    await connection.OpenAsync();
                    const string query = @"SELECT [users].id, [users].username, [users].email, [users].role, [session_users].token FROM [users]
                                        INNER JOIN [session_users] ON [session_users].user_id = [users].id
                                        WHERE [session_users].token = @token AND [session_users].expired_at > @dateNow";

                    using var command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@token", token);
                    command.Parameters.AddWithValue("@dateNow", DateTime.Now);

                    using var reader = await command.ExecuteReaderAsync();

                    if (await reader.ReadAsync())
                    {
                        context.Items["username"] = reader["username"].ToString();
                        context.Items["userId"] = reader["id"].ToString();
                        context.Items["role"] = reader["role"].ToString();

                        await _next(context);
                    }
                    else
                    {
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        await context.Response.WriteAsJsonAsync(new
                        {
                            success = false,
                            message = "Unauthorized"
                        });
                    }
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsJsonAsync(new
                    {
                        success = false,
                        message = "Unauthorized"
                    });
                }
            } catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Authentication Middleware.");
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsJsonAsync(new
                {
                    success = false,
                    message = "Internal server error!"
                });
            }
        }
    }
}
