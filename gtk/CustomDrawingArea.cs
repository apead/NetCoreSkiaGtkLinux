    using GLib;
    using SkiaSharp;
    using Gtk;
    using System;

namespace gtk
{
 public class CustomDrawing : DrawingArea
        {
            protected override bool OnDrawn(Cairo.Context cr)
            {
                const int width = 1200;
                const int height = 800;

                using (var bitmap = new SKBitmap(width, height, SKColorType.Rgb888x, SKAlphaType.Premul))
                {
                    IntPtr len;
                    using (var skSurface = SKSurface.Create(bitmap.Info.Width, bitmap.Info.Height, SKColorType.Rgb888x, SKAlphaType.Premul, bitmap.GetPixels(out len), bitmap.Info.RowBytes))
                    {
                        var canvas = skSurface.Canvas;
                        canvas.Clear(SKColors.White);

                        using (var paint = new SKPaint())
                        {
                            paint.TextSize = 80;
                           
                            canvas.DrawText("Good Luck Dale!  :-)",new SKPoint(){X=100,Y=100},paint);

                        }

                        Cairo.Surface surface = new Cairo.ImageSurface(
                            bitmap.GetPixels(out len),
                            Cairo.Format.Argb32,
                            bitmap.Width, bitmap.Height,
                            bitmap.Width * 4);


                        surface.MarkDirty();
                        cr.SetSourceSurface(surface, 0, 0);
                        cr.Paint();
                    }
                }

                return true;
            }
        }
}