using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_app.Models
{
    public class SearchPageModel : ObservableObject
    {
        

        
        public List<History> RecipeHistory { get; set; }
        public List<LastViewed> LastViewedItems { get; set; }

        public SearchPageModel()
        {
            RecipeHistory = new List<History>{
                new History
                {
                    Image = "chinnon_apple.jpg",
                    Name = "Chinon Apple Tarts"
                },
                new History
                {
                    Image = "vegan_lasagna.jpg",
                    Name = "Vegan Lasagna"
                },
                new History
                {
                    Image = "vegan_cass.jpg",
                    Name = "Vegetarian Casserole"
                },
                
 

            };

            LastViewedItems = new List<LastViewed>{
                new LastViewed
                {
                    LImage = "chinnon_apple.jpg",
                    LName = "Spicy Fish Soup"
                },
                
               




            };

            

        }
    }

    public class History
    {
        public string Image { get; set; }
        public string Name { get; set; }
    }
    public class LastViewed
    {
        public string LImage { get; set; }
        public string LName { get; set; }
    }
}
