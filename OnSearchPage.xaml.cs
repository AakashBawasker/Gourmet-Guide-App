using CommunityToolkit.Mvvm.Input;
using Recipe_app.ApiModels;
using Recipe_app.Models;
using Recipe_app.Views;

namespace Recipe_app;

public partial class OnSearchPage : ContentPage
{
    private bool categoriesLoaded = false;
    private bool isBookmarkClicked = false;
    private string recipeCate;
    public OnSearchPageViewModel ViewModel { get; private set; }

   
    public OnSearchPage(string category)
	{
		InitializeComponent();
        recipeCate = category;
        ViewModel = new OnSearchPageViewModel();
        BindingContext = ViewModel;
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
            await ViewModel.GetSearchMeals(recipeCate);
            categoriesLoaded = true; // Set the flag to indicate that categories have been loaded
        }

    }

    
    private void Entry_Completed(object sender, EventArgs e)
    {
        var searchTerm = ((Entry)sender).Text;

        // Example: Display an alert with the search term
        

         App.Current.MainPage.Navigation.PushAsync(new OnSearchPage(searchTerm));
    }

    
    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        string searchTerm = searchEntry.Text;

        // Example: Display an alert with the search term
        
        App.Current.MainPage.Navigation.PushAsync(new OnSearchPage(searchTerm));
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        searchEntry.Text = string.Empty;
    }

    private void imageButton_Clicked_1(object sender, EventArgs e)
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

    private void  TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        
    }
}