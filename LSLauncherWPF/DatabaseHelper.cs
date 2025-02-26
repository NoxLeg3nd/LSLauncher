using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace LSLauncherWPF
{
    class DatabaseHelper
    {
        private string dbPath = "Databases/lsdb.db";
        private string connectionString;
        public DatabaseHelper()
        {
            connectionString = $"Data Source={dbPath};Version=3;";
        }
        public List<GameDevelopers> GetGameDevelopers()
        {
            List<GameDevelopers> developers = new List<GameDevelopers>();
            try
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM GameDevelopers";
                    using (var cmd = new SQLiteCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            developers.Add(new GameDevelopers
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return developers;
        }
        public List<Games> GetGamesByDeveloper(int gameDeveloperId)
        {
            List<Games> games = new List<Games>();
            try
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = $"SELECT * FROM Games WHERE DeveloperId = {gameDeveloperId}";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@DeveloperId", gameDeveloperId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                games.Add(new Games
                                {
                                    Id = reader.GetInt32(0),
                                    DeveloperId = reader.GetInt32(1),
                                    Platform = reader.GetString(2),
                                    ImagePath = reader.GetString(3),
                                    GameName = reader.GetString(4),
                                    GameLink = reader.GetString(5)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return games;
        }

        public List<Games> GetGamesByDeveloperAndPlatform(int gameDeveloperId, string platform)
        {
            List<Games> games = new List<Games>();
            try
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = $"SELECT * FROM Games WHERE DeveloperId = @DeveloperId AND Platform = @Platform";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@DeveloperId", gameDeveloperId);
                        cmd.Parameters.AddWithValue("@Platform", platform);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                games.Add(new Games
                                {
                                    Id = reader.GetInt32(0),
                                    DeveloperId = reader.GetInt32(1),
                                    Platform = reader.GetString(2),
                                    ImagePath = reader.GetString(3),
                                    GameName = reader.GetString(4),
                                    GameLink = reader.GetString(5)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return games;
        }
    }
    public class GameDevelopers
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Games
    {
        public int Id { get; set; }
        public int DeveloperId { get; set; }
        public string Platform { get; set; }
        public string ImagePath { get; set; }
        public string GameName { get; set; }
        public string GameLink { get; set; }
    }
}

    