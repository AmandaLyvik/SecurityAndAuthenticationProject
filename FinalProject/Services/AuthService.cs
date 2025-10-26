using Microsoft.Data.Sqlite;
using FinalProject.Helpers;

namespace FinalProject.Services
{
    public class AuthService
    {
        private readonly string _connectionString = "Data Source=FinalProject.db";

        public bool StoreUser(string username, string email)
        {
            const string query = "INSERT INTO Users (Username, Email) VALUES (@Username, @Email)";

            using (var connection = new SqliteConnection(_connectionString))
            using (var command = new SqliteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Email", email);

                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
        }

        public List<User> GetAllUsers()
        {
            var users = new List<User>();
            const string query = "SELECT UserID, Username, Email FROM Users";

            using var connection = new SqliteConnection(_connectionString);
            using var command = new SqliteCommand(query, connection);

            connection.Open();
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                users.Add(new User
                {
                    UserID = reader.GetInt32(0),
                    Username = reader.GetString(1),
                    Email = reader.GetString(2)
                });
            }

            return users;
        }
    }
}
