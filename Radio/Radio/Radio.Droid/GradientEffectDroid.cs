using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Radio;
using Android.Graphics.Drawables;

[assembly: ResolutionGroupName ("Xamarin")]
[assembly: ExportEffect (typeof (GradientEffectDroid), "GradientEffect")]

namespace Radio
{
	public class GradientEffectDroid : PlatformEffect
	{
		Drawable originalDrawable;

		protected override void OnAttached()
		{
			var view = Element as View;

			if (view == null)
				return;
			
			var color1 = view.BackgroundColor.ToAndroid ();
            byte r = (byte)((int)(color1.R) * 9 / 10);
            byte g = (byte)((int)(color1.G) * 9 / 10);
            byte b = (byte)((int)(color1.B) * 9 / 10);
            var color2 = new Android.Graphics.Color(r, g, b);

            originalDrawable = Control.Background;

			var gradDrawable = new GradientDrawable (GradientDrawable.Orientation.TopBottom, new int[]{color1, color2});

			Control.SetBackground (gradDrawable);
		}

		protected override void OnDetached()
		{
			if (originalDrawable != null)
				Control.SetBackground (originalDrawable);
		}
	}
}