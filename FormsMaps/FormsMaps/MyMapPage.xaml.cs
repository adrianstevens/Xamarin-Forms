using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Diagnostics;
using Xamarin.Forms.Maps;

namespace FormsMaps
{
	public partial class MyMapPage : ContentPage
	{
		public MyMapPage ()
		{
			InitializeComponent ();

			var posVancouver = new Xamarin.Forms.Maps.Position (49.25, -123.13);

			var myPin = new Xamarin.Forms.Maps.Pin () {
				Label = "Vancouver, BC",
				Position = posVancouver,
				Type = PinType.SearchResult//no effect in XM 1.4
			};

			MyMap.Pins.Add (myPin);

			myPin.Clicked += (object sender, EventArgs e) => {

				//not currently working - Xam Forms bug?
				var pin = sender as Xamarin.Forms.Maps.Pin;

				if(pin != null)
				{
					DisplayAlert ("Tapped!", "Pin was tapped.", "OK");
					Debug.WriteLine("Pin {0} Clicked!!", pin.Label);
				}
			};

			//move to location
			var mapSpan = MapSpan.FromCenterAndRadius (posVancouver, Distance.FromKilometers (2.5));

			MyMap.MoveToRegion(mapSpan);



		
		}
	}
}

