using Recipe_app.Tabbed_views;
using Recipe_app.Views;

namespace Recipe_app
{
    public partial class MainPage : ContentPage
    {
       

        public MainPage()
        {
            InitializeComponent();
            Preferences.Set("IsGetStarted", true);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HomePage());

        }
    }

}
