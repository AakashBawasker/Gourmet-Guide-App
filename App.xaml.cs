
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Recipe_app.Tabbed_views;
using Recipe_app.Views;

namespace Recipe_app
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            bool isGetStarted = Preferences.Get("IsGetStarted", false);
            if(isGetStarted)
            {
                MainPage = new NavigationPage(new HomePage());
            }
            else {
                MainPage = new NavigationPage(new MainPage());
            }
            
        }
        
    }
}
