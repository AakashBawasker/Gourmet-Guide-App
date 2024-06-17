using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recipe_app.Models;
using SQLite;

namespace Recipe_app.ApiModels.DbServiceModels
{
    public class DatabaseHelper
    {
        public DatabaseHelper()
        {

            InitializeDatabase();
            
        }
        private const int DatabaseVersion = 1;

        public SQLiteAsyncConnection GetConnection()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "mydatabase.db3");
            return new SQLiteAsyncConnection(dbPath);
        }

        public void InitializeDatabase()
        {
            var connection = GetConnection();
            connection.CreateTableAsync<SearchMeal>();
            connection.CreateTableAsync<RecipeItemResponse>();
            connection.CloseAsync();
        }

        private async Task<int> GetCurrentVersion(SQLiteAsyncConnection connection)
        {
            var tableInfo = await connection.GetTableInfoAsync("VersionInfo");

            if (!tableInfo.Any())
            {
                await connection.CreateTableAsync<VersionInfo>();
                await connection.InsertAsync(new VersionInfo { Version = 1 });
                return 1;
            }
            var version = await connection.Table<VersionInfo>().FirstOrDefaultAsync();
            return version?.Version ?? 1;
        }

        private static void SetCurrentVersion(SQLiteAsyncConnection connection, int version)
        {
            connection.Table<VersionInfo>().DeleteAsync(v => v.Id > 0); // Assuming VersionInfo has Id column
            connection.InsertAsync(new VersionInfo { Version = version });
        }

        [Table("VersionInfo")]
        public class VersionInfo
        {
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }

            public int Version { get; set; }
        }

    }
}
