using Recipe_app.Models;

namespace Recipe_app.SeeAllPages;

public partial class SeeAll2 : ContentPage
{
    private bool isBookmarkClicked = false;
    public SeeAll2()
	{
		InitializeComponent();
        BindingContext = new SearchPageModel();
    }

    private void ImageButton_Clicked(object sender, EventArgs e)
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