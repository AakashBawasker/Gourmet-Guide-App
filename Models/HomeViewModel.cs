using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Recipe_app.ApiModels;
using Recipe_app.ApiServiceModels;
using Recipe_app.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace Recipe_app.Models
{
    public partial class HomeViewModel : ObservableObject
    {



        [ObservableProperty]
        private List<MealCategories> categories = [];

        [ObservableProperty]
        private Boolean showLoaderForCategoris = false;

        [ObservableProperty]
        public Boolean showNoInternetMessage = false;

        [ObservableProperty]
        private Boolean showLoaderForMeal = false;

        [ObservableProperty]
        private List<RecipeItemResponse> recipes = [];




        [RelayCommand]
        private async Task ClickAsync(MealCategories category)
        {
            Console.WriteLine("Category >> " + category.strCategory);
            var list = Categories;


            foreach (var item in list)
            {


                item.isSelected = item.strCategory == category.strCategory;


            }
            Categories = list;
            await GetCategoriesWiseMeal(category.strCategory);


        }
        public async Task GetCategories() {
            ///Check internet connection if connected then only call below block
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                ShowNoInternetMessage = true;
                return;
            }
            ShowLoaderForCategoris = true;
            await Task.Delay(2000);
            try
            {
                var items = await new ServiceHelper().GetMealCategories();
                Categories = items;
                await GetCategoriesWiseMeal(Categories[0].strCategory);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching categories: {ex.Message}");
            }
            finally
            {
                ShowLoaderForCategoris = false;
            }
        }

        public async Task GetCategoriesWiseMeal(string category)
        {
            ShowLoaderForMeal = true;
            await Task.Delay(2000);
            var items = await new ServiceHelper().GetRecipeCategories(category);
            Recipes = items;
            ShowLoaderForMeal = false;

        }


        [RelayCommand]
        public void RecipeItemSelected(object item)
        {
            Console.WriteLine("On clicked");
            App.Current.MainPage.Navigation.PushAsync(new RecipeDetail((item as RecipeItemResponse).idMeal ));
        }




    }

    }
