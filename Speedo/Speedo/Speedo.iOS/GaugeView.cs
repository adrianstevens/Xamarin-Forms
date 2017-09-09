using System;
using CoreGraphics;
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

        public override void Draw(CGRect rect)
        {
            base.Draw(rect);

            using (CGContext cg = UIGraphics.GetCurrentContext())
            {
                DrawGauge(cg);
            };
        }

        void DrawGauge (CGContext cg)
        {



        }
    }
}
