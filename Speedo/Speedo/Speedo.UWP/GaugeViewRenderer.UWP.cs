using Speedo.UWP;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using System.ComponentModel;
using Speedo;

[assembly: ExportRenderer(typeof(Gauge), typeof(GaugeViewRenderer))]
namespace Speedo.UWP
{
    class GaugeViewRenderer : ViewRenderer<Gauge, GaugeView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Gauge> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                var gaugeView = new GaugeView();
    
                SetNativeControl(gaugeView);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            //if (e.PropertyName == Gauge.AccentColorProperty.PropertyName)
            {
                //......
            }
        }
    }
}