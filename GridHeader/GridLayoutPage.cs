using System;

using Xamarin.Forms;

namespace GridHeader
{
	public class GridLayoutPage : ContentPage
	{
		public GridLayoutPage()
		{
			var layout = new StackLayout
			{
				Orientation = StackOrientation.Vertical,
			//	Padding = 20
			};

			if (Device.OS == TargetPlatform.iOS)
				layout.Padding = new Thickness (5, 20, 5, 5);
			else
				layout.Padding = new Thickness (5);

			var header = new Grid()
			{
				ColumnSpacing = 10,
				BackgroundColor = Color.Aqua,
			};

			for (var i = 0; i < 4; i++)
			{
				header.ColumnDefinitions.Add(new ColumnDefinition()
					{   Width= new GridLength(1, GridUnitType.Star)});
			}

			header.RowDefinitions.Add (new RowDefinition () { Height = new GridLength (20)});

			header.Children.Add(new Label { Text = "One" }, 0, 0); // Left, First element
			header.Children.Add(new Label { Text = "Two" }, 1, 0); // Right, First element
			header.Children.Add(new Label { Text = "Three" }, 2, 0); // Left, Second element
			header.Children.Add(new Label { Text = "Four" }, 3, 0); // Right, Second element

			var grid = new Grid
			{
				RowSpacing = 10
			};

			for (var i = 0; i < 4; i++)
			{
				grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
			}

			for (int j = 0; j < 400; j++)
			{
				grid.Children.Add(new Label {Text = "item " + j}, j%4, j/4); 
			}

			layout.Children.Add(header);
			layout.Children.Add(new ScrollView { Content = grid, VerticalOptions = new LayoutOptions(LayoutAlignment.Fill, true)});
			Content = layout;
		}
	} 
}