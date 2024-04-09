using CommunityToolkit.Mvvm.ComponentModel;

namespace Stochastica.MVVM.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    [ObservableProperty] public string sigma;
    [ObservableProperty] private string mean;
    [ObservableProperty] private string initialPrice;
    [ObservableProperty] private string numDays;
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
        double sigma = Convert.ToDouble(Sigma) / 100;
        double mean = Convert.ToDouble(Mean) / 100;
        double initialPrice = Convert.ToDouble(InitialPrice);
        int numDays = Convert.ToInt32(NumDays);

        BrownianData = GenerateBrownianMotion(sigma, mean, initialPrice, numDays);
    }

    private static double[] GenerateBrownianMotion(double sigma, double mean, double initialPrice, int numDays)
    {
        Random rand = new Random();
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