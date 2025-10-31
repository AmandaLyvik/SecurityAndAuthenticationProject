using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;
using FinalProject.Services;
using System.Reflection;
using Microsoft.Data.Sqlite;


namespace FinalProject.Tests
{
    [TestFixture]
    public class AuthServiceTests
    {
        private AppDbContext _context;
        private AuthService _authService;

        [SetUp]
        public void Setup()
        {
            Console.WriteLine("\nTestInputValidation setup starting...");

            var connectionString = "Data Source=:memory"; // or use a file-based test DB
            _authService = new AuthService(connectionString);

            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            var createTable = connection.CreateCommand();
            createTable.CommandText = @"
                CREATE TABLE IF NOT EXISTS Users (
                    UserID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Username TEXT NOT NULL,
                    Email TEXT NOT NULL,
                    PasswordHash TEXT NOT NULL
                );";
            createTable.ExecuteNonQuery();
        }

        [Test]
        public void AuthenticateUser()
        {
            Console.WriteLine("🚨 Running AuthenticateUser...");

            // Should return true when password matches
            var input = new UserInput
            {
                Username = "testuser",
                Email = "test@example.com",
                Password = "Secure123!"
            };

            _authService.StoreUser(input);

            Assert.That(_authService.AuthenticateUser(input.Username, input.Password), Is.True, "User should be authenticated with correct password.");
            Assert.That(_authService.AuthenticateUser(input.Username, "WrongPassword"), Is.False, "Authentication should fail with incorrect password.");

            Console.WriteLine("✅ AuthenticateUser validation tests passed.");
        }
        
        [TearDown]
        public void Teardown()
        {
            Console.WriteLine("✅ Test finished.");
        }
    }
}
