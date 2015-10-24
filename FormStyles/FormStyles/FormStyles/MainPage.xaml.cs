using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FormStyles
{
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();


			//http://www.color-hex.com/color/ffb6c1
			btnBlue.Clicked += (sender, e) => App.SetThemeColors (Color.FromHex("#1E90FF"), Color.FromHex("#E8F3FF"), Color.FromHex("#1EFFFE"));
			btnPink.Clicked += (sender, e) => App.SetThemeColors (Color.FromHex("#FFB6C1"), Color.FromHex("#FFF7F8"), Color.FromHex("#b6c1ff"));
			btnOrange.Clicked += (sender, e) => App.SetThemeColors (Color.FromHex("#FF8C00"), Color.FromHex("#190E00"), Color.FromHex("#F3FF00"));

			myStepper.ValueChanged += (sender, e) => lblStepper.Text = myStepper.Value.ToString();

			mySwitch.Toggled += (sender, e) => lblSwitch.Text = mySwitch.IsToggled?"On":"Off";

			mySlider.ValueChanged += (sender, e) => myBoxView.Rotation = mySlider.Value*360;

			myButton.Clicked += (sender, e) => ToggleProgressBar();
		}

		bool showProgress = false;
		void ToggleProgressBar ()
		{
			showProgress = !showProgress;

			if (showProgress == true) {
				Device.StartTimer (new TimeSpan (0, 0, 0, 0, 1500), () => {
					myProgressBar.Progress = 0;
					myProgressBar.ProgressTo (1, 1000, Easing.SinInOut);

					return showProgress;

				});
			}
		}



	}
}

