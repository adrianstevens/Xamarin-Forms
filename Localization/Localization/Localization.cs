using System;

using Xamarin.Forms;

namespace Localization
{
	public class App : Application
	{
		public App ()
		{


			// The root page of your application
			MainPage = new ContentPage {
				Content = new StackLayout {
					VerticalOptions = LayoutOptions.Center,
					Children = 
					{
						new Label 
						{
							XAlign = TextAlignment.Center,
							Text = AppRes.ResMan.GetString("Title"), //defined in Strings.resx
						}
					}
				}
			};
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

