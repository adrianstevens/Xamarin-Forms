using System;

using Xamarin.Forms;

namespace WebViewLocalContent
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			var tabPage = new TabbedPage();

			tabPage.Children.Add (new MyMainPage (){Title="No Binding"});
			tabPage.Children.Add (new MyMainPageBindingFix (){Title="Binding Fix"});

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

