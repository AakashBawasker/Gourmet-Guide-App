using Recipe_app.ApiModels;
using Recipe_app.ApiModels.DbServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_app.Dao
{
    public class RecipeItemRespnseDao(DatabaseHelper Helper)
    {
        public async Task<List<RecipeItemResponse>> GetItems()
        {
            var connection = Helper.GetConnection();
            var list = await connection.Table<RecipeItemResponse>().ToListAsync();
            await connection.CloseAsync();
            return list;
        }

        public async Task<int> SaveItem(RecipeItemResponse item)
        {

            var connection = Helper.GetConnection();
            var Id = await connection.InsertAsync(item);
            await connection.CloseAsync();
            return Id;
        }

        public async Task<int> DeleteItem(RecipeItemResponse item)
        {

            var connection = Helper.GetConnection();
            var Id = await connection.DeleteAsync(item);
            await connection.CloseAsync();
            return Id;
        }
    }
}
