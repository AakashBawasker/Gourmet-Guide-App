using Recipe_app.ApiModels;
using Recipe_app.Models;
using Recipe_app.Tabbed_views;
using System.Collections.ObjectModel;

namespace Recipe_app.Views;

public partial class RecipeDetail : ContentPage
{
    private string recipeId;

    private bool isBookmarkClicked = false;

    public RecipeDetailModel ViewModel { get; private set; }

    public RecipeDetail(string id)
    {
        InitializeComponent();
        recipeId = id;
        ViewModel = new RecipeDetailModel();
        BindingContext = ViewModel;

    }

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
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

        await ViewModel.GetMeals(recipeId);

    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var viewModel = (RecipeDetailModel)BindingContext;
        string youtubeLink = viewModel.Meals.strYoutube;

        if (!string.IsNullOrWhiteSpace(youtubeLink))
        {
            Launcher.OpenAsync(new System.Uri(youtubeLink));
        }
        else
        {
            // Handle if YouTube link is not available
        }
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