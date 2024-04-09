namespace Stochastica.MVVM.Views.Interfaces;

public interface IBrownianGraphView
{
    double[] Data { get; set; }
    double HorizontalScale { get; set; }
    double VerticalScale { get; set; }
}