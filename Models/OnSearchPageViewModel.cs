using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
//using Microsoft.UI.Xaml.Controls;
using Recipe_app.ApiModels;
using Recipe_app.ApiServiceModels;
using Recipe_app.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_app.Models
{
    public partial class OnSearchPageViewModel : ObservableObject
    {
        public string searchText;
        [ObservableProperty]
        private List<SearchMeal> meals = [];

        [ObservableProperty]
        private Boolean showLoaderForSearch = false;

        public async Task GetSearchMeals(string cate)
        {
            await GetSearchWiseMeal(cate);
        }


        public async Task GetSearchWiseMeal(string category)
        {
            ShowLoaderForSearch = true;
            await Task.Delay(2000);
            Meals = await new ServiceHelper().GetSearchMealCategories(category);
            ShowLoaderForSearch = false;

        }

        
        [RelayCommand]
        public void RecipeItemSelected(object item)
        {
            Console.WriteLine("On clicked");
            App.Current.MainPage.Navigation.PushAsync(new RecipeDetail((item as SearchMeal).idMeal));
        }

        public async Task SaveRecord()
        {
            try
            {
                if(RecipeItemSelected!=null)
                {
                    //var item = new ApiModels.SearchMeal();
                    //item.strMeal = strMeal;
                    //item.strMealThumb = strMealThumb;

                    //item.CategoryId = SelectedItem.categories[0].id.ToString() ?? "";
                    //item.CategoryName = SelectedItem.categories[0].name;

                    //item.Name = SelectedItem.name;
                    //await Dao.SaveItem(item);

                    //await Utility.ShowToast("Item added successfully");

                    //SelectedItem = null;
                    //strMeal = "";
                }
                    
                    //MainThread.BeginInvokeOnMainThread(async () =>
                    //{
                    //    await m_view.Navigation.PopAsync();
                    //});
                    /*MainThread.BeginInvokeOnMainThread(async () =>
                    {
                        await m_view.Navigation.PopAsync();
                    });*/

                    /* Device.BeginInvokeOnMainThread(async () => );*/
                    /*  Device.BeginInvokeOnMainThread(async () => await _navigation.PopAsync());*/

                
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.ToString()}");
            }
        }

    }
}
