using System;
using System.Collections.Generic;
using Xamarin.Forms;
using NavigationCommon;

namespace StackNavigation
{
	public partial class ColorDetailPage : ContentPage
	{
		public ColorDetailPage (ColorModel color)
		{
			Title = color.Name;

			BindingContext = color;

			InitializeComponent ();

			boxColor.GestureRecognizers.Add(new TapGestureRecognizer( (v, o)=> Navigation.PushAsync(new FullColorPage(color))));
		}
	}
}

