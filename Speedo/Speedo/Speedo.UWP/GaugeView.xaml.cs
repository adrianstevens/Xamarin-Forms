using System;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml;

namespace Speedo.UWP
{
    public sealed partial class GaugeView : UserControl
    {
        public Double ScaleWidth { get; set; }
        public double Value { get; set; }
        public double MaxValue { get; set; }
        public double NeedleAngle { get; set; }
        public double Minimum { get; set; }
        public double Maximum { get; set; }
        
        Color clrTick = Color.FromArgb(255, 22, 102, 255);
        Color clrAccent = Color.FromArgb(255, 0, 255, 255);

        public GaugeView()
        {
            this.InitializeComponent();

            ScaleWidth = 26.0;
            Minimum = 0;
            Maximum = 120;
            Value = 0;
            MaxValue = 0;

            CreateTicks();

            SetNeedleColor(clrTick, clrAccent);

            UpdateSpeed(Value);
        }

        public void SetNeedleColor(Color clr, Color clrAccent)
        {
            PART_Needle.Fill = new SolidColorBrush(clr);
            clr.A = 0x66;
            PART_Needle.Stroke = new SolidColorBrush(clr);

            this.clrTick = clr;
            this.clrAccent = clrAccent;
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
                    backGrid.Children.Add(GetTick(i * 12.5 + 30.0, rcSmall, clrAccent));
                    continue;
                }

                backGrid.Children.Add(GetTick(i / 2 * 25 + 30, rcLarge, Colors.White));
                backGrid.Children.Add(GetTick(i / 2 * 25 + 30, rcInner, clrTick));
                if (i % 4 == 0)
                    backGrid.Children.Add(GetTickLabel(i * 12.5 + 30));
            }

        }

        public void UpdateMaxValue(double max)
        {
            MaxValue = max;
            txtMaxValue.Text = MaxValue.ToString("N0");
        }

        public void UpdateValue(double value)
        {
            UpdateSpeed(this.Value = value);

            if (Value > MaxValue)
            {
                MaxValue = value;
                txtMaxValue.Text = MaxValue.ToString("N0");
            }
        }

        public void UpdateGauge(int max, string units)
        {
            Maximum = max;
            txtUnits.Text = units;

            //and recreate the ticks
            backGrid.Children.Clear();
            CreateTicks();

        }

        string GetValueFromAngle(double angleDeg)
        {
            double speed = (angleDeg - 30) * Maximum / 300;
            return speed.ToString("N0");
        }

        //make a tick label
        TextBlock GetTickLabel(double angle)
        {
            var txt = new TextBlock();
            txt.Foreground = new SolidColorBrush(Color.FromArgb(255, 170, 170, 170));//.FromArgb(255, 128,128,128 ));
            txt.Text = GetValueFromAngle(angle);
            if (txt.Text.Length < 3)
                txt.Text = txt.Text + "  ";
            //    txt.Text = "999";
            txt.FontSize = 10;
            // txt.FontWeight = FontWeights.Bold;
            txt.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center;
            txt.VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Center;

            //so we could just do a little render transform math
            var xOffset = 0 - Math.Sin(Degrees2Radians * angle) * 47; // 100;
            var yOffset = Math.Cos(Degrees2Radians * angle) * 50; // 95;

            var transform = new TranslateTransform() { X = xOffset, Y = yOffset };
            txt.RenderTransform = transform;

            return txt;
        }

        //make a tick
        Path GetTick(double angle, Rect rcTick, Color clr)
        {
            var path = new Path();
            var rc = new RectangleGeometry();
            rc.Rect = rcTick;//  new Rect(0, 155, 4, 15);
            path.Data = rc;
            path.Fill = new SolidColorBrush(clr);

            var transGroup = new TransformGroup();

            path.HorizontalAlignment = HorizontalAlignment.Center;
            path.VerticalAlignment =VerticalAlignment.Center;

            transGroup.Children.Add(new TranslateTransform() { X = 0, Y = 0 });
            transGroup.Children.Add(new RotateTransform() { Angle = angle });

            path.RenderTransformOrigin = new Point(0.5, 0.5);
            //, AlignmentY = 1.0 };
            path.RenderTransform = transGroup;

            return path;
        }

        void UpdateSpeed(double value)
        {
            if (Double.IsNaN(value) == false)
            {
                var middleOfScale = 77 - ScaleWidth / 2;
                var needle = PART_Needle;
                var valueText = txtValue;
                NeedleAngle = ValueToAngle(value);

                // Needle
                if (needle != null)
                {
                    needle.RenderTransform = new RotateTransform() { Angle = NeedleAngle };
                }

                // Trail
                var trail = PART_Trail;
                if (trail != null)
                {
                    if (NeedleAngle > -146)
                    {
                        trail.Visibility = Visibility.Visible;
                        var pg = new PathGeometry();
                        var pf = new PathFigure();
                        pf.IsClosed = false;
                        pf.StartPoint = ScalePoint(-150, middleOfScale);
                        var seg = new ArcSegment();
                        seg.SweepDirection = SweepDirection.Clockwise;
                        // We start from -150, so +30 becomes a large arc.
                        seg.IsLargeArc = NeedleAngle > 30;
                        seg.Size = new Size(middleOfScale, middleOfScale);
                        seg.Point = ScalePoint(NeedleAngle, middleOfScale);
                        pf.Segments.Add(seg);
                        pg.Figures.Add(pf);
                        trail.Data = pg;
                    }
                    else
                    {
                        trail.Visibility = Visibility.Collapsed;
                    }
                }

                // Value Text
                if (valueText != null)
                {
                    valueText.Text = value.ToString("N0");
                }
            }
        }

        const double Degrees2Radians = Math.PI / 180;
        Point ScalePoint(double angle, double middleOfScale)
        {
            return new Point(100 + Math.Sin(Degrees2Radians * angle) * middleOfScale, 100 - Math.Cos(Degrees2Radians * angle) * middleOfScale);
        }

        double ValueToAngle(double value)
        {
            double minAngle = -150;
            double maxAngle = 150;

            // Off-scale to the left
            if (value < Minimum)
                return minAngle - 7.5;

            // Off-scale to the right
            if (value > Maximum)
                return maxAngle + 7.5;

            double angularRange = maxAngle - minAngle;

            return (value - Minimum) / (Maximum - Minimum) * angularRange + minAngle;
        }
    }
}