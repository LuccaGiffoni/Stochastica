using CommunityToolkit.Mvvm.ComponentModel;

namespace Stochastica.MVVM.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    private double _sigma;
    public double Sigma
    {
        get => _sigma;
        set
        {
            if (double.TryParse(value.ToString(), out double result) && result >= 0)
            {
                _sigma = result;
                OnPropertyChanged();
            }
        }
    }

    private double _mean;
    public double Mean
    {
        get => _mean;
        set
        {
            if (double.TryParse(value.ToString(), out double result) && result >= 0)
            {
                _mean = result;
                OnPropertyChanged();
            }
        }
    }

    private double _initialPrice;
    public double InitialPrice
    {
        get => _initialPrice;
        set
        {
            if (double.TryParse(value.ToString(), out double result) && result >= 0)
            {
                _initialPrice = result;
                OnPropertyChanged();
            }
        }
    }

    private int _numDays;
    public int NumDays
    {
        get => _numDays;
        set
        {
            if (int.TryParse(value.ToString(), out int result) && result > 0)
            {
                _numDays = result;
                OnPropertyChanged();
            }
        }
    }

    [ObservableProperty] private double[] brownianData;

    [ObservableProperty] private double _horizontalScale = 1.0;
    [ObservableProperty] private double _verticalScale = 1.0;

    public Command GenerateGraphCommand { get; }
    public Command ResetScalesCommand { get; }

    public MainPageViewModel()
    {
        GenerateGraphCommand = new Command(GenerateGraph);
        ResetScalesCommand = new Command(ResetScales);
    }

    private void ResetScales()
    {
        HorizontalScale = 1.0;
        VerticalScale = 1.0;
    }

    private void GenerateGraph()
    {
        BrownianData = GenerateBrownianMotion(Sigma / 100, Mean / 100, InitialPrice, NumDays);
    }

    private static double[] GenerateBrownianMotion(double sigma, double mean, double initialPrice, int numDays)
    {
        Random rand = new();
        double[] prices = new double[numDays];
        prices[0] = initialPrice;

        for (int i = 1; i < numDays; i++)
        {
            double u1 = 1.0 - rand.NextDouble();
            double u2 = 1.0 - rand.NextDouble();
            double z = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Cos(2.0 * Math.PI * u2);
            double dailyReturn = mean + sigma * z;
            prices[i] = prices[i - 1] * Math.Exp(dailyReturn);
        }

        return prices;
    }
}