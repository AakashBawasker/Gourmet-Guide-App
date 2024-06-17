using CommunityToolkit.Mvvm.ComponentModel;
using Recipe_app.ApiModels;
using Recipe_app.ApiServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Recipe_app.Models
{
    public partial class RecipeDetailModel : ObservableObject
    {
        [ObservableProperty]
        private IdWiseMeal meals = new IdWiseMeal();

        [ObservableProperty]
        private Boolean showLoaderForDetail = false;



        public async Task GetMeals(string mealId)
        {
            await GetIdWiseMeal(mealId);
        }

        
        public async Task GetIdWiseMeal(string Id)
        {
            ShowLoaderForDetail = true;
            await Task.Delay(2000);
            Meals = await new ServiceHelper().GetIdWiseMealDetail(Id);
            ShowLoaderForDetail = false;

        }


    }
}
