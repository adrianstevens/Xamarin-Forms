using System;

using Xamarin.Forms;

namespace GridHeader
{
	public partial class GridLayoutXAMLPage : ContentPage
	{
		public GridLayoutXAMLPage()
		{
			InitializeComponent ();

			AddData ();
		}

		void AddData ()
		{
			for (int j = 0; j < 400; j++)
			{
				gridData.Children.Add (new Label {Text = "item " + j}, j%4, j/4); 
			}
		}
	} 
}