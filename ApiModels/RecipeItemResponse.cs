using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_app.ApiModels
{
    [Table("lastviewed")]
    public class RecipeItemResponse
    {
        [Column("strmeal")]
        public string strMeal { get; set; }

        [Column("strmealthumb")]
        public string strMealThumb { get; set;}

        public bool isSelected { get; set; }

        [PrimaryKey, AutoIncrement]
        public string idMeal { get; set; }
    }
}
