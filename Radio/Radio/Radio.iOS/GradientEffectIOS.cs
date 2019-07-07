using System.ComponentModel;
using Radio;
using CoreAnimation;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName ("Xamarin")]
[assembly: ExportEffect (typeof (GradientEffectIOS), "GradientEffect")]

namespace Radio
{
	public class GradientEffectIOS : PlatformEffect
	{
		CAGradientLayer gradLayer;

		protected override void OnAttached()
		{
			SetGradientLayer ();
		}		

		protected override void OnDetached()
		{
			gradLayer?.RemoveFromSuperLayer ();
		}

		protected override void OnElementPropertyChanged(PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(e);

			SetGradientLayer ();
		}

		void SetGradientLayer()
		{
			var button = Element as Button;

			if (button.Width < 1)
				return;

			gradLayer?.RemoveFromSuperLayer ();

			gradLayer = new CAGradientLayer();
			gradLayer.Frame = new CGRect(0, 0, button.Width, button.Height);

			var color1 = UIColor.FromRGB (0, 0, 40).CGColor;
			var color2 = Container.BackgroundColor.CGColor;

			gradLayer.Colors = new CGColor[]{color2, color1};
			gradLayer.StartPoint = new CGPoint(0, 0);
			gradLayer.EndPoint = new CGPoint(0, 1);
			gradLayer.CornerRadius = Control.Layer.CornerRadius;

			Control.Layer.InsertSublayer(gradLayer, 0);
		}
	}
}