using System;
using System.Linq;
using Xamarin.Forms;
using NavigationCommon;

namespace TabNavigation
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			var tabbedPage = new TabbedPage();

			var rand = new Random ();

			//133 colors 
			var colors = ColorLoader.GetColors ().Skip(rand.Next()%127).Take (6);

			foreach (var c in colors) {
				var p = new ColorDetailPage (c);
				tabbedPage.Children.Add (p);

			}

			MainPage = tabbedPage;
		}
	}
}