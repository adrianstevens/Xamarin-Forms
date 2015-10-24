using System;
using UIKit;

namespace FormStyles.iOS
{
	public class SetSystemColors : ISetSystemColors
	{
		public SetSystemColors ()
		{
		}

		public void SetTintColor(double r, double g, double b)
		{
			UIApplication.SharedApplication.KeyWindow.TintColor = UIColor.FromRGB ((nfloat)r, (nfloat)g, (nfloat)b);
		}
	}
}

