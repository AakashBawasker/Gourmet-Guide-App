using Recipe_app.ApiModels;
using Recipe_app.ApiModels.DbServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_app.Dao
{
    public class SearchMealDao(DatabaseHelper Helper)
    {
        public async Task<List<SearchMeal>> GetItems()
        {
            var connection = Helper.GetConnection();
            var list = await connection.Table<SearchMeal>().ToListAsync();
            await connection.CloseAsync();
            return list;
        }

        public async Task<int> SaveItem(SearchMeal item)
        {

            var connection = Helper.GetConnection();
            var Id = await connection.InsertAsync(item);
            await connection.CloseAsync();
            return Id;
        }

        public async Task<int> DeleteItem(SearchMeal item)
        {

            var connection = Helper.GetConnection();
            var Id = await connection.DeleteAsync(item);
            await connection.CloseAsync();
            return Id;
        }
    }
}
