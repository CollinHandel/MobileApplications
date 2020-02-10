using System;
using Android.Content;
using Android.Graphics;
using RoundedCorners;
using RoundedCorners.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ImageBox), typeof(ImageBoxRenderer))]
namespace RoundedCorners.Droid
{
    public class ImageBoxRenderer: ImageRenderer
    {
        public ImageBoxRenderer(Context context) : base(context)
        {
        }

        protected override bool DrawChild(Android.Graphics.Canvas canvas, Android.Views.View child, long drawingTime)
        {
            try
            {
                // Clip path
                var radius = 25.0f;
                var path = new Path();
                RectF rect = new RectF(0, 0, Width, Height);
                path.AddRoundRect(rect, radius, radius, Path.Direction.Cw);
                canvas.Save();
                canvas.ClipPath(path);
                var result = base.DrawChild(canvas, child, drawingTime);
                canvas.Restore();

                // Create Border
                path = new Path();
                path.AddRoundRect(rect, radius, radius, Path.Direction.Cw);
                var paint = new Paint();
                paint.AntiAlias = true;
                paint.StrokeWidth = 1;
                paint.SetStyle(Paint.Style.Stroke);
                paint.Color = global::Android.Graphics.Color.Rgb(11, 11, 14);
                canvas.DrawPath(path, paint);

                // Clean Up
                paint.Dispose();
                path.Dispose();

                return result;
            } catch {}

            return base.DrawChild(canvas, child, drawingTime);
        }
    }
}
