using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_app.ApiModels
{
    public class MealCategories 
    {
        public string idCategory { get; set; }
        public string strCategory { get; set; }

        public string strCategoryThumb { get; set; }
        public string strCategoryDescription { get; set;}

        public bool isSelected { get; set; }

        
        //private bool _isSelected;
        //public bool IsSelected
        //{
        //    get { return _isSelected; }
        //    set
        //    {
        //        if (_isSelected != value)
        //        {
        //            _isSelected = value;
        //            OnPropertyChanged(nameof(IsSelected));
        //        }
        //    }
        //}

        //public event PropertyChangedEventHandler PropertyChanged;
        //protected virtual void OnPropertyChanged(string propertyName)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        //public class SelectionToColorConverter : IValueConverter
        //{
        //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        //    {
        //        bool isSelected = (bool)value;
        //        return isSelected ? Colors.Orange : Colors.White;
        //    }

        //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

    }
}
