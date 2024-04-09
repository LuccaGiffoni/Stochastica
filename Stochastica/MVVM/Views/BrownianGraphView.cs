using SkiaSharp;
using SkiaSharp.Views.Maui;
using SkiaSharp.Views.Maui.Controls;
using Stochastica.MVVM.Views.Interfaces;
using System.Diagnostics;

namespace Stochastica.MVVM.Views;

public class BrownianGraphView : SKCanvasView, IBrownianGraphView
{
    public static readonly BindableProperty NumLinesProperty =
    BindableProperty.Create(nameof(NumLines), typeof(int), typeof(BrownianGraphView), 1,
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            (bindable as BrownianGraphView)?.InvalidateSurface();
        });

    public int NumLines
    {
        get => (int)GetValue(NumLinesProperty);
        set => SetValue(NumLinesProperty, value);
    }

    public static readonly BindableProperty GraphDataProperty =
        BindableProperty.Create(nameof(GraphData), typeof(double[][]), typeof(BrownianGraphView), null,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                (bindable as BrownianGraphView)?.InvalidateSurface();
            });

    public double[][] GraphData
    {
        get => (double[][])GetValue(GraphDataProperty);
        set => SetValue(GraphDataProperty, value);
    }

    public static readonly BindableProperty HorizontalScaleProperty =
        BindableProperty.Create(nameof(HorizontalScale), typeof(double), typeof(BrownianGraphView), 1.0,
            propertyChanged: (bindable, oldValue, newValue) => (bindable as BrownianGraphView)?.InvalidateSurface());

    public double HorizontalScale
    {
        get => (double)GetValue(HorizontalScaleProperty);
        set => SetValue(HorizontalScaleProperty, value);
    }

    public static readonly BindableProperty VerticalScaleProperty =
        BindableProperty.Create(nameof(VerticalScale), typeof(double), typeof(BrownianGraphView), 1.0,
            propertyChanged: (bindable, oldValue, newValue) => (bindable as BrownianGraphView)?.InvalidateSurface());

    public double VerticalScale
    {
        get => (double)GetValue(VerticalScaleProperty);
        set => SetValue(VerticalScaleProperty, value);
    }

    protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
    {
        base.OnPaintSurface(e);

        var canvas = e.Surface.Canvas;

        canvas.Clear();

        if (GraphData != null && GraphData.Length > 0)
        {
            int numGraphs = GraphData.Length;
            var dataLength = GraphData[0].Length;

            using var paint = new SKPaint();
            for (int k = 0; k < numGraphs; k++)
            {
                double[] data = GraphData[k];

                paint.Style = SKPaintStyle.Stroke;
                paint.Color = GetRandomContrastColor();
                paint.StrokeWidth = 2;
                paint.StrokeCap = SKStrokeCap.Round;

                var path = new SKPath();
                var xScale = e.Info.Width / (dataLength - 1);
                var yScale = e.Info.Height / (data.Max() - data.Min());

                path.MoveTo(0, (float)(e.Info.Height - data[0] * yScale));

                for (int i = 1; i < dataLength; i++)
                {
                    var x = i * xScale;
                    var y = (float)(e.Info.Height - data[i] * yScale);
                    path.LineTo((float)x, y);
                }

                canvas.DrawPath(path, paint);
            }
        }
    }

    private static SKColor GetRandomContrastColor()
    {
        Random random = new();

        int hue = random.Next(0, 360);
        int saturation = random.Next(40, 101);
        int lightness = random.Next(40, 61);

        SKColor color = SKColor.FromHsl(hue, saturation, lightness);

        return SKColor.Parse($"#{color.Red:X2}{color.Green:X2}{color.Blue:X2}");
    }
}