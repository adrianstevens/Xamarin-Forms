using System;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace Speedo.UWP
{
    public sealed partial class GaugeView : UserControl
    {
        public double Value { get; set; } = 0;
        public double Minimum { get; set; } = 0;
        public double Maximum { get; set; } = 100;


        double needleAngle { get; set; }
        Color accentColor { get; set; } = Colors.Orange;


        public Color NeedleColor
        {
            get { return (Color)GetValue(NeedleColorProperty); }
            set { SetValueDp(NeedleColorProperty, value); }
        }
        public static readonly DependencyProperty NeedleColorProperty = 
            DependencyProperty.Register("NeedleColor", typeof(Color), typeof(GaugeView), null);

        public event PropertyChangedEventHandler PropertyChanged;
        void SetValueDp(DependencyProperty property, object value, [CallerMemberName] String p = null)
        {
            SetValue(property, value);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
        }
    



        
        //Color colorTick = Color.FromArgb(255, 22, 102, 255);
        //Color colorAccent = Color.FromArgb(255, 0, 255, 255);

        public GaugeView()
        {
            this.InitializeComponent();
         //   (this.Content as FrameworkElement).DataContext = this;

            CreateTicks();

          //  SetNeedleColor(needleColor, accentColor);

            UpdateValue(Value);
        }

        void SetNeedleColor(Color colorNeedle, Color colorAccent)
        {
            needle.Fill = new SolidColorBrush(colorNeedle);
            colorNeedle.A = 0x66;
            needle.Stroke = new SolidColorBrush(colorNeedle);
        }

        void CreateTicks()
        {
            //starts at 30, ends at 330 - total sweep 300 degrees

            Rect rcLarge = new Rect(0, 155, 3, 15);
            Rect rcSmall = new Rect(0, 165, 1, 5);
            Rect rcInner = new Rect(0, 128, 1, 5);

            //add ticks
            for (int i = 0; i < 25; i++)
            {
                if (i % 2 == 1)
                {
                    backGrid.Children.Add(GetTick(i * 12.5 + 30.0, rcSmall, NeedleColor));
                    continue;
                }

                backGrid.Children.Add(GetTick(i / 2 * 25 + 30, rcLarge, Colors.White));
                backGrid.Children.Add(GetTick(i / 2 * 25 + 30, rcInner, accentColor));
                if (i % 4 == 0)
                    backGrid.Children.Add(GetTickLabel(i * 12.5 + 30));
            }
        }

        Path GetTick(double angle, Rect rectTick, Color tickColor)
        {
            var transform = new TransformGroup();
            transform.Children.Add(new TranslateTransform() { X = 0, Y = 0 });
            transform.Children.Add(new RotateTransform() { Angle = angle });

            var path = new Path()
            {
                Data = new RectangleGeometry() { Rect = rectTick },
                Fill = new SolidColorBrush(tickColor),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                RenderTransformOrigin = new Point(0.5, 0.5),
                RenderTransform = transform,
            };

            return path;
        }

        TextBlock GetTickLabel(double angle)
        {
            var xOffset = 0 - Math.Sin(Degrees2Radians * angle) * 47;
            var yOffset = Math.Cos(Degrees2Radians * angle) * 50;

            var transform = new TranslateTransform()
            {
                X = xOffset,
                Y = yOffset
            };

            var txt = new TextBlock()
            {
                Foreground = new SolidColorBrush(Color.FromArgb(255, 170, 170, 170)),
                FontSize = 10,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                RenderTransform = transform,
            };
                    
            txt.Text = GetAngleAsString(angle);
            if (txt.Text.Length < 3)
                txt.Text = txt.Text + "  ";

            return txt;
        }

        void UpdateValue(double value)
        {
            if (Double.IsNaN(value))
                return;

            Value = value;

            UpdateNeedle(Value);
            txtValue.Text = Value.ToString("N0");
        }

        void UpdateNeedle(double value)
        { 
            needle.RenderTransform = (new RotateTransform() { Angle = GetAngleFromValue(value) });
        }

        const double Degrees2Radians = Math.PI / 180;
        Point GetScalePoint(double angle, double middleOfScale)
        {
            return new Point(100 + Math.Sin(Degrees2Radians * angle) * middleOfScale, 100 - Math.Cos(Degrees2Radians * angle) * middleOfScale);
        }

        double GetAngleFromValue(double value)
        {
            double minAngle = -150;
            double maxAngle = 150;

            if (value < Minimum)
                return minAngle - 7.5;

            if (value > Maximum)
                return maxAngle + 7.5;

            double angularRange = maxAngle - minAngle;

            return (value - Minimum) / (Maximum - Minimum) * angularRange + minAngle;
        }

        string GetAngleAsString(double angleDeg)
        {
            double speed = (angleDeg - 30) * Maximum / 300;
            return speed.ToString("N0");
        }
    }
}