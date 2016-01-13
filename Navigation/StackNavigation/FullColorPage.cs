using System;

using Xamarin.Forms;
using NavigationCommon;

namespace StackNavigation
{
	public class FullColorPage : ContentPage
	{
		public FullColorPage (ColorModel color)
		{
			this.BackgroundColor = color.Color;
			this.Title = color.Hex;
		}
	}
}


