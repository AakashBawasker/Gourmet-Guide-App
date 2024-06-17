using Recipe_app.Views;
using System.Net.Http;
using Microsoft.Maui.Controls;

using Microsoft.Maui.Controls.Platform;
using Recipe_app.Models;
using Recipe_app.ApiModels;
using static Java.Util.Jar.Attributes;
using Android.App;

namespace Recipe_app.Tabbed_views;

public partial class HomePage : TabbedPage
{
    public HomeViewModel ViewModel { get; private set; }

    private bool isBookmarkClicked = false;
    private bool categoriesLoaded = false;

    public HomePage()
	{
		InitializeComponent();
        
        ViewModel = new HomeViewModel();
        BindingContext = ViewModel;

        var externalPage1 = new SearchPage();
        Children.Add(externalPage1);

        var externalPage2 = new SavedPage();
        Children.Add(externalPage2);

    }

    

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Check if the navigation bar is available
        if (NavigationPage.GetHasNavigationBar(this))
        {
            // Hide the back button
            NavigationPage.SetHasBackButton(this, false);
        }
        

        if (!categoriesLoaded)
        {
            await ViewModel.GetCategories();
            categoriesLoaded = true; // Set the flag to indicate that categories have been loaded
        }


    }

    
    private void Button_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            // Change the button color when clicked
            button.BackgroundColor = Colors.Orange; // Set your desired color
        }
    }





    private void Label_HandlerChanging(object sender, HandlerChangingEventArgs e)
    {
        if (sender is Label label)
        {
            // Change the label text color when clicked
            label.TextColor = Colors.Black; // Set your desired color
        }

    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        if (sender is Label label)
        {
            // Change the label text color when clicked
            label.TextColor = Colors.Black; // Set your desired color
        }
    }

    private  void RecipeButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new RecipeDetail(""));

    }

    private void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {

    }

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        ((ImageButton)sender).BackgroundColor = Colors.LightGray;
    }

    private void TapGestureRecognizer_Tapped_2(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new OnSearchPage(""));
    }

    private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        /* if (e.PreviousSelection != null)
         {
             foreach (MealCategories item in e.PreviousSelection)
             {
                 item.IsSelected = false;
             }
         }

         if (e.CurrentSelection != null)
         {
             foreach (MealCategories item in e.CurrentSelection)
             {
                 item.IsSelected = true;
             }
         }*/

        
    }

    private void ImageButton_Clicked_1(object sender, EventArgs e)
    {
        var imageButton = (ImageButton)sender;

        if (isBookmarkClicked)
        {
            // Change to the previous image
            imageButton.Source = "bookmarkwhite.png";
        }
        else
        {
            // Change to the new image
            imageButton.Source = "bookmark.png";
        }

        // Toggle the state
        isBookmarkClicked = !isBookmarkClicked;
    }
}