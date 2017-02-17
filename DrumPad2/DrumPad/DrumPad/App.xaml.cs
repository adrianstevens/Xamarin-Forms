using System;
using Utilities;
using Xamarin.Forms;

namespace DrumPad
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new DrumPad.MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        public static void UpdateThemeColors (ColorScheme scheme)
        {
            Current.Resources["mainColor"] = XFUtilities.GetColorFromInt(scheme.MainColor);
            Current.Resources["highlightColor"] = XFUtilities.GetColorFromInt(scheme.HighlightColor);
            Current.Resources["buttonColor"] = XFUtilities.GetColorFromInt(scheme.ButtonColor);
            Current.Resources["backgroundColor"] = XFUtilities.GetColorFromInt(scheme.BackgroundColor);
        }
    }
}