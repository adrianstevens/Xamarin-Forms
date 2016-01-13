using System;
using System.Collections.Generic;

using Xamarin.Forms;
using NavigationCommon;

namespace StackNavigation
{
	public partial class ColorListPage : ContentPage
	{
		public List<ColorModel> Colors { get; set; }

		public ColorListPage (List<ColorModel> colors)
		{
			this.Colors = colors;

			BindingContext = this;

			InitializeComponent ();

			listColors.ItemTapped += ListColorsItemTapped;
		}

		void ListColorsItemTapped (object sender, ItemTappedEventArgs e)
		{
			var color = listColors.SelectedItem as ColorModel;

			this.Navigation.PushAsync(new ColorDetailPage(color));
		}
	}
}