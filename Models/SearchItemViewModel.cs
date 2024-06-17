using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_app.Models
{
    public class SearchItemViewModel : INotifyPropertyChanged
    {
        public string searchText;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string SearchText
        {
            get => searchText;
            set
            {
                if (searchText != value)
                {
                    searchText = value;
                    OnPropertyChanged(nameof(SearchText));
                    FilterItems();
                }
            }
        }

        public ObservableCollection<string> AllItems { get; } = new ObservableCollection<string>
        {
            "Apple", "Banana", "Orange", "Grapes", "Strawberry", "Watermelon", "Pineapple",
            "chicken.png"
        };

        public ObservableCollection<string> FilteredItems { get; } = new ObservableCollection<string>();

       
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void FilterItems()
        {
            // Simple case-insensitive filtering
            var filtered = AllItems.Where(item => item.Contains(SearchText, StringComparison.OrdinalIgnoreCase));
            FilteredItems.Clear();
            foreach (var item in filtered)
            {
                FilteredItems.Add(item);
            }
        }
    }
}
