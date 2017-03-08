using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using Xamarin.Forms;

namespace SkiaPong
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void OnPaintSquare(object sender, SKPaintSurfaceEventArgs e)
        {
            int width = e.Info.Width;
            int height = e.Info.Height;
            SKCanvas canvas = e.Surface.Canvas;

            float side = Math.Min(height, width) * 0.9f;

            using (SKPaint paint = new SKPaint())
            {
                canvas.Clear(Color.White.ToSKColor()); //paint it black

                SKRect rect = new SKRect(width/2 - side/2, height/2 - side/2, width / 2 + side / 2, height / 2 + side / 2);
                paint.Color = Color.Teal.ToSKColor();
                canvas.DrawRect(rect, paint);
            }
        }

        void OnPaintCircle(object sender, SKPaintSurfaceEventArgs e)
        {
            int width = e.Info.Width;
            int height = e.Info.Height;
            SKCanvas canvas = e.Surface.Canvas;
            float side = Math.Min(height, width) * 0.9f;

            using (SKPaint paint = new SKPaint())
            {
                canvas.Clear(Color.White.ToSKColor()); //paint it black

                SKRect rect = new SKRect(width / 2 - side / 2, height / 2 - side / 2, width / 2 + side / 2, height / 2 + side / 2);

                paint.Color = Color.Purple.ToSKColor();
                canvas.DrawOval(rect, paint);
            }
        }

        void OnPaintShadedStar(object sender, SKPaintSurfaceEventArgs e)
        {
            int width = e.Info.Width;
            int height = e.Info.Height;

            SKCanvas canvas = e.Surface.Canvas;

            using (SKPaint paint = new SKPaint())
            {
                canvas.Clear(Color.White.ToSKColor()); //paint it black

                paint.Color = Color.Green.ToSKColor();

                paint.PathEffect = SKPathEffect.CreateDiscrete(5.0f, 2.0f);

                paint.Shader = SKShader.CreateLinearGradient(new SKPoint(0, 0),
                    new SKPoint(256, 256),
                    new SKColor[] { Color.Lime.ToSKColor(), Color.Orange.ToSKColor() }, 
                    null, SKShaderTileMode.Clamp);

                paint.IsAntialias = true;

                canvas.DrawPath(GetStarPath(width/2 - 128), paint);
            }
        }

        SKPath GetStarPath(int xOffSet)
        {
            var R = 60.0f;
            var C = 128.0f;

            SKPath path = new SKPath();
            path.MoveTo(R + xOffSet, C);

            for (int i = 1; i < 16; ++i)
            {
                var a = 0.44879895f * i;
                var r = R + R * (i % 2);
                path.LineTo(xOffSet + C + r * (float)Math.Cos(a), C + r * (float)Math.Sin(a));
            }
            return path;
        }
    } 
}