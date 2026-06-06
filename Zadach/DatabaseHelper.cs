using System;
using System.Data.SQLite;
using System.IO;

namespace TaskManager
{
    public static class DatabaseHelper
    {
        private static string dbFile = "tasks.db";
        private static string connectionString = $"Data Source={dbFile};Version=3;";

        public static void InitializeDatabase()
        {
            if (!File.Exists(dbFile))
            {
                SQLiteConnection.CreateFile(dbFile);
            }

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string createUsers = @"
                    CREATE TABLE IF NOT EXISTS Users (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Username TEXT UNIQUE NOT NULL,
                        PasswordHash TEXT NOT NULL
                    )";
                using (var cmd = new SQLiteCommand(createUsers, connection))
                    cmd.ExecuteNonQuery();

                string createTasks = @"
                    CREATE TABLE IF NOT EXISTS Tasks (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        UserId INTEGER NOT NULL,
                        Title TEXT NOT NULL,
                        Description TEXT,
                        DayOfWeek INTEGER NOT NULL DEFAULT 0,
                        Complexity INTEGER NOT NULL DEFAULT 1,
                        CreatedAt TEXT NOT NULL,
                        AssignedTo TEXT,
                        FOREIGN KEY(UserId) REFERENCES Users(Id)
                    )";
                using (var cmd = new SQLiteCommand(createTasks, connection))
                    cmd.ExecuteNonQuery();

                
                try
                {
                    string addDayOfWeek = "ALTER TABLE Tasks ADD COLUMN DayOfWeek INTEGER DEFAULT 0";
                    using (var cmd = new SQLiteCommand(addDayOfWeek, connection)) cmd.ExecuteNonQuery();
                }
                catch { }

                try
                {
                    string addAssignedTo = "ALTER TABLE Tasks ADD COLUMN AssignedTo TEXT";
                    using (var cmd = new SQLiteCommand(addAssignedTo, connection)) cmd.ExecuteNonQuery();
                }
                catch { }
            }
        }

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(connectionString);
        }
    }
}