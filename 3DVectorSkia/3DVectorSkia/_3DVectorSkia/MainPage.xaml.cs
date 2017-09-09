using System;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace _3DVectorSkia
{
    public partial class MainPage : ContentPage
    {
        static int width = 300;
        static int height = 300;

        public MainPage()
        {
            InitializeComponent();

            xSlider.ValueChanged += SliderValueChanged;
            ySlider.ValueChanged += SliderValueChanged;
            zSlider.ValueChanged += SliderValueChanged;
        }

        private void SliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            canvas.InvalidateSurface();

        }

        void OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKCanvas canvas = e.Surface.Canvas;

            int center = width / 2;

            using (SKPaint paint = new SKPaint() { IsAntialias = true })
            {
                canvas.Clear(Color.White.ToSKColor());

                paint.Color = Color.LightGray.ToSKColor();

             //   canvas.DrawLine(center, center, width, 0, paint);

                paint.Color = Color.Black.ToSKColor();

             //   canvas.DrawLine(center, center, 0, center, paint);
             //   canvas.DrawLine(center, center, center, height, paint);
                canvas.DrawLine(center, center, width, center, paint);
                canvas.DrawLine(center, center, center, -height, paint);
                canvas.DrawLine(center, center, 0, height, paint);

                DrawVector(xSlider.Value, ySlider.Value, zSlider.Value, paint, canvas);
            }




            /*   using (SKPaint paint = new SKPaint())
               {
                   canvas.Clear(Color.White.ToSKColor());

                   canvas.DrawLine(124, 176, width, 176, paint);
                   canvas.DrawLine(124, 176, 124, -height, paint);
                   canvas.DrawLine(124, 176, 0, height, paint);
               }*/
        
        }

        //start with x, y ... constrained between 0 and 1
        void DrawVector(double x, double y, double z, SKPaint paint, SKCanvas canvas)
        {
            double scale = 150;
            int center = width / 2;

            var xPos = x * scale + center;
            var yPos = center - y * scale;

            var zOffset = Math.Sqrt(2) * z * scale / 2.0;
                    
            paint.StrokeWidth = 2;
            paint.Color = Color.FromRgb(0, 120, 215).ToSKColor();

            //3D Vector
            canvas.DrawLine(center, center, (float)(xPos - zOffset), (float)(yPos + zOffset), paint);

            //Guides
            paint.StrokeWidth = 1;
            paint.Color = Color.FromRgb(216, 59, 1).ToSKColor();

            //from vector to xz plane
            canvas.DrawLine((float)(xPos - zOffset), (float)(yPos + zOffset), (float)(xPos - zOffset), (float)(center + zOffset), paint);
            //from x axis
            canvas.DrawLine((float)xPos, center, (float)(xPos - zOffset), (float)(center + zOffset), paint);
            //from z axis
            canvas.DrawLine((float)(center - zOffset), (float)(center + zOffset), (float)(xPos - zOffset), (float)(center + zOffset), paint);




        }
    }
}