using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_app.ApiModels
{
    [Table("history")]
    public class SearchMeal
    {
        
        

        [Column("str_meal")]
        public string strMeal { get; set; }

        [Column("str_meal_thumb")]
        public string strMealThumb { get; set; }

        public bool isSelected { get; set; }

        [PrimaryKey, AutoIncrement]
        public string idMeal { get; set; }

        public string strCategory { get; set; }
    }
}
