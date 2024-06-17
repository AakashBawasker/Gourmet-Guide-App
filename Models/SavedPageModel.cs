using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_app.Models
{
    public class SavedPageModel : ObservableObject
    {
        public List<SavedRecipe> SavedRecipes { get; set; }


        public SavedPageModel()
        {
            SavedRecipes = new List<SavedRecipe>{
                new SavedRecipe
                {
                    
                    LImage = "chicken.png",
                    LName = "Spicy Fish Soup"
                },
                


            };
        }
    }
    public class SavedRecipe
    {
        
        public string LImage { get; set; }
        public string LName { get; set; }
    }
}
