using Radio;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

//add appropriate using statement for each windows platform variant

[assembly: ResolutionGroupName ("Xamarin")]
[assembly: ExportEffect (typeof (GradientEffectWindows), "GradientEffect")]
namespace Radio
{
	internal class GradientEffectWindows : PlatformEffect
	{
        Brush oldBrush;

		protected override void OnAttached()
		{
            var button = Element as Button;

            if (button == null)
                return;

            var gradBrush = new LinearGradientBrush()
            {
                StartPoint = new global::Windows.Foundation.Point(0, 0),
                EndPoint = new global::Windows.Foundation.Point(0, 1)
            };

            var color1 = button.BackgroundColor;
            var color2 = new Color(color1.R * 0.9, color1.G * 0.9, color1.B * 0.9);

            gradBrush.GradientStops.Add(new GradientStop() { Color = GetWindowsColor(color1), Offset = 0 });
            gradBrush.GradientStops.Add(new GradientStop() { Color = GetWindowsColor(color2), Offset = 1 });

            var btn = Control as FormsButton;

            oldBrush = btn.Background;
            btn.BackgroundColor = gradBrush;
        }

		protected override void OnDetached()
		{
            var btn = Control as global::Windows.UI.Xaml.Controls.Button;

            if (btn == null)
                return;

            btn.Background = oldBrush;
        }

		protected override void OnElementPropertyChanged (System.ComponentModel.PropertyChangedEventArgs args)
		{
			base.OnElementPropertyChanged (args);
		}

        global::Windows.UI.Color GetWindowsColor (Color color)
        {
            return global::Windows.UI.Color.FromArgb((byte)(255 * color.A), (byte)(255 * color.R), (byte)(255 * color.G), (byte)(255 * color.B));
        }
	}
}