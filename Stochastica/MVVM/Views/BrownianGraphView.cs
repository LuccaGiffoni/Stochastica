using SkiaSharp;
using SkiaSharp.Views.Maui;
using SkiaSharp.Views.Maui.Controls;

namespace Stochastica.MVVM.Views;

public class BrownianGraphView : SKCanvasView
{
    public static readonly BindableProperty DataProperty =
        BindableProperty.Create(nameof(Data), typeof(double[]), typeof(BrownianGraphView), null,
            propertyChanged: (bindable, oldValue, newValue) => (bindable as BrownianGraphView)?.InvalidateSurface());

    public double[] Data
    {
        get => (double[])GetValue(DataProperty);
        set => SetValue(DataProperty, value);
    }

    protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
    {
        base.OnPaintSurface(e);

        var canvas = e.Surface.Canvas;

        canvas.Clear();

        if (Data != null && Data.Length > 0)
        {
            using var paint = new SKPaint();

            paint.Style = SKPaintStyle.Stroke;
            paint.Color = SKColors.Blue;
            paint.StrokeWidth = 2;
            paint.StrokeCap = SKStrokeCap.Round;

            var path = new SKPath();
            var xScale = e.Info.Width / (Data.Length - 1);
            var yScale = e.Info.Height / (Data.Max() - Data.Min());

            path.MoveTo(0, (float)(e.Info.Height - Data[0] * yScale));

            for (int i = 1; i < Data.Length; i++)
            {
                var x = i * xScale;
                var y = (float)(e.Info.Height - Data[i] * yScale);
                path.LineTo(x, y);
            }

            canvas.DrawPath(path, paint);
        }
    }
}
