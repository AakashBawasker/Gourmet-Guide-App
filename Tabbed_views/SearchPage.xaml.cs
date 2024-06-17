using Recipe_app.Models;
using Recipe_app.SeeAllPages;
using Recipe_app.Views;

namespace Recipe_app.Tabbed_views;

public partial class SearchPage : ContentPage
{
    private bool isBookmarkClicked = false;
    private readonly AppDbContext _dbContext;
    public SearchPage()
	{
		InitializeComponent();
        _dbContext = new AppDbContext();
        BindingContext = new SearchPageModel();
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new OnSearchPage(""));
    }

    private void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new SeeAll1());
    }

    private void TapGestureRecognizer_Tapped_2(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new SeeAll2());
    }

    private void TapGestureRecognizer_Tapped_3(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new RecipeDetail(""));
    }

    private void ImageButton_Clicked(object sender, EventArgs e)
    {

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