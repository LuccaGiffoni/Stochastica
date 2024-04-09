using SkiaSharp;
using SkiaSharp.Views.Maui;
using SkiaSharp.Views.Maui.Controls;
using Stochastica.MVVM.Models;
using Stochastica.MVVM.ViewModels;

namespace Stochastica.MVVM.Views;

public partial class MainPage : ContentPage
{
    private BrownianMotionDrawable _brownianMotionDrawable;

    public MainPage()
    {
        InitializeComponent();

        _brownianMotionDrawable = new BrownianMotionDrawable(0.1, 0.02, 100, 100);
    }

    private void OnCanvasPaint(object sender, SKPaintSurfaceEventArgs e)
    {
        _brownianMotionDrawable.Draw(e.Surface.Canvas, e.Info.Rect);
    }
}