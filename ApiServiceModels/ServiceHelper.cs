using Recipe_app.ApiModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Recipe_app.ApiServiceModels
{
    public class ServiceHelper
    {
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;

        public ServiceHelper() {

            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<List<MealCategories>> GetMealCategories() {
            var Items = new List<MealCategories>();
            Uri uri = new Uri(string.Concat("http://www.themealdb.com/api/json/v1/1/", "categories.php"));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var responseJson =  JsonSerializer.Deserialize<MealParentResponse>(content, _serializerOptions);
                    Items = responseJson.categories;
                }
                else
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        
                    }
                    else
                    {
                        Console.WriteLine("Failed to retrieve data. Status code: " + response.StatusCode);
                    }
                    
                }
            }
            catch (Exception ex)
            {
               
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine("Please check the API endpoint URL.");
            }

            return Items;

         }

        public async Task<List<RecipeItemResponse>> GetRecipeCategories(string category)
        {
            var Items = new List<RecipeItemResponse>();
            Uri uri = new Uri(string.Concat("http://www.themealdb.com/api/json/v1/1/", "filter.php?c="+ category));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var responseJson = JsonSerializer.Deserialize<ParentRecipeItemResponse>(content, _serializerOptions);
                    Items = responseJson.meals;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);

            }

            return Items;

        }
        public async Task<IdWiseMeal> GetIdWiseMealDetail(string Id)
        {
            var Items = new IdWiseMeal();
            Uri uri = new Uri(string.Concat("http://www.themealdb.com/api/json/v1/1/", "lookup.php?i=" +Id));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var responseJson = JsonSerializer.Deserialize<IdWiseParentMeal>(content, _serializerOptions);
                    Items = responseJson.meals[0];
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
               
            return Items;

        }
        public async Task<List<SearchMeal>> GetSearchMealCategories(string category)
        {
            var Items = new List<SearchMeal>();
            Uri uri = new Uri(string.Concat("http://www.themealdb.com/api/json/v1/1/", "search.php?s=" +category));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var responseJson = JsonSerializer.Deserialize<SearchParentMeal>(content, _serializerOptions);
                    Items = responseJson.meals;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);

            }

            return Items;

        }
    }
}
