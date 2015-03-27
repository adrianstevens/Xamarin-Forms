using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using CoreLocation;

namespace FormsMaps.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();
			Xamarin.FormsMaps.Init();

			LoadApplication (new App ());

			var LocMgr = new CLLocationManager ();
			LocMgr.RequestWhenInUseAuthorization ();

			return base.FinishedLaunching (app, options);
		}
	}
}

