using System;
using Xamarin.Forms;
using NavigationCommon;

namespace StackNavigation
{
	public class App : Application
	{
		public App ()
		{
			MainPage = new NavigationPage( new ColorListPage(ColorLoader.GetColors ()));
		}
	}
}