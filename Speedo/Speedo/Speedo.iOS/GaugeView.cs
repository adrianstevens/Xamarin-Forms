using System;
using Foundation;
using UIKit;

namespace Speedo.iOS
{
    public class GaugeView : UIView
    {
        public GaugeView()
        {
            MultipleTouchEnabled = true;
            UserInteractionEnabled = true;
        }

        public override void TouchesMoved(NSSet touches, UIEvent evt)
        {
            foreach (UITouch touch in touches)
            {

            }
        }
    }
}
