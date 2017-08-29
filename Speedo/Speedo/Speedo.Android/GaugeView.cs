using System;
using Android.Views;
using Android.Graphics;
using Android.Content;
using Android.Util;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;

//https://github.com/CodeAndMagic/GaugeView
//http://android.codeandmagic.org/android-gaugeview-library/

namespace Speedo.Droid
{
    public class GaugeView : View
    {
        public double Value { get; set; } = 0;
        public double Minimum { get; set; } = 0;
        public double Maximum { get; set; } = 100;

        double needleWidth;
        double needleHeight;


        ShapeDrawable circle;



        public GaugeView(Context context): base(context, null, 0)
        {
            Init();
        }
        public GaugeView(Context context, IAttributeSet attrs) : base(context, attrs) { }
        public GaugeView(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle) { }

        void Init ()
        {
            var paint = new Paint();
            paint.SetARGB(255, 200, 255, 0);
            paint.SetStyle(Paint.Style.Stroke);
            paint.StrokeWidth = 4;

            circle = new ShapeDrawable(new OvalShape());
            circle.Paint.Set(paint);

            circle.SetBounds(0, 0, 300, 300);
        }

        protected override void OnDraw(Canvas canvas)
        {
            circle.Draw(canvas);
        }


    }
    }
}