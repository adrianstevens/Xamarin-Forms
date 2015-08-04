using System;

using Xamarin.Forms;

namespace GridHeader
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			var tabPage = new TabbedPage();

			tabPage.Children.Add (new GridLayoutPage () {Title = "Code"} ); 
			tabPage.Children.Add (new GridLayoutXAMLPage () {Title = "XAML"} );

			MainPage = tabPage;
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

