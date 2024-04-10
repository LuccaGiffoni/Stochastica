namespace Stochastica.MVVM.Views.Interfaces;

public interface IBrownianGraphView
{
    double[][] GraphData { get; set; }
    double HorizontalScale { get; set; }
    double VerticalScale { get; set; }
}