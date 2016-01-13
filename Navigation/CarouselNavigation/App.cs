using System;
using System.Linq;
using Xamarin.Forms;
using NavigationCommon;

namespace CarouselNavigation
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			var carouselPage = new CarouselPage();

			var rand = new Random ();

			//133 colors 
			var colors = ColorLoader.GetColors ().Skip(rand.Next()%121).Take (12);

			foreach (var c in colors) {
				var p = new ColorDetailPage (c);
				carouselPage.Children.Add (p);

			}

			MainPage = carouselPage;
		}
	}
}