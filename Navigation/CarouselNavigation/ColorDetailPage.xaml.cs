using System;
using System.Collections.Generic;
using Xamarin.Forms;
using NavigationCommon;

namespace CarouselNavigation
{
	public partial class ColorDetailPage : ContentPage
	{
		public ColorDetailPage (ColorModel color)
		{
			Title = color.Name;

			BindingContext = color;

			InitializeComponent ();
		}
	}
}