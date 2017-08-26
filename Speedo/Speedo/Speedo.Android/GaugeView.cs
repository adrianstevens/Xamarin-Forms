using System;
using Android.Views;
using Android.Graphics;
using Android.Content;
using Android.Util;
using System.Collections.Generic;

namespace Speedo.Droid
{
    public class GaugeView : View
    {
        public GaugeView(Context context): base(context, null, 0)
        {

        }
        public GaugeView(Context context, IAttributeSet attrs) : base(context, attrs) { }
        public GaugeView(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle) { }
    }
}