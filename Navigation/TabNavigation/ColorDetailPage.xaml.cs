using System;
using System.Collections.Generic;
using Xamarin.Forms;
using NavigationCommon;

namespace TabNavigation
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