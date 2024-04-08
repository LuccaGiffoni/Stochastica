using SkiaSharp;
using SkiaSharp.Views.Maui;
using SkiaSharp.Views.Maui.Controls;
using Stochastica.Drawables;
using Stochastica.ViewModels;

namespace Stochastica.Views;

public partial class MainPage : ContentPage
{
    private SKCanvasView skiaCanvas;

    public MainPage()
    {
        InitializeComponent();
        InitializeSkiaCanvas();
    }


    public void InitializeSkiaCanvas()
    {
        skiaCanvas = new SKCanvasView();
        skiaCanvas.PaintSurface += OnPainting;
        grid.Children.Add(skiaCanvas); // Add the canvas to the grid
    }

    private void OnPainting(object sender, SKPaintSurfaceEventArgs e)
    {
        // Implement the painting logic here
        // This method will be called when the canvas needs to be redrawn
    }

    private void GenerateGraph()
    {
        // Get ViewModel from BindingContext
        var viewModel = (ViewModels.MainPageViewModel)BindingContext;

        // Generate Brownian motion using provided parameters
        double[] prices = BrownianMotionDrawable.GenerateBrownianMotion(viewModel.Sigma, viewModel.Mean, viewModel.InitialPrice, viewModel.NumDays);

        // Draw graph using SkiaSharp
        skiaCanvas.PaintSurface += (sender, args) =>
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear(SKColors.White);

            // Draw your graph using SkiaSharp APIs based on 'prices' array
            // Example: draw a line chart
            using (SKPaint paint = new SKPaint())
            {
                paint.Color = SKColors.Blue;
                paint.StrokeWidth = 2;

                for (int i = 1; i < prices.Length; i++)
                {
                    float x1 = i - 1;
                    float y1 = (float)prices[i - 1];
                    float x2 = i;
                    float y2 = (float)prices[i];

                    canvas.DrawLine(x1, y1, x2, y2, paint);
                }
            }
        };

        // Force SkiaCanvas to repaint
        skiaCanvas.InvalidateSurface();
    }
}