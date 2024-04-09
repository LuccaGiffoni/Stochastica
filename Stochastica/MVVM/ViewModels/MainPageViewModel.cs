using CommunityToolkit.Mvvm.ComponentModel;
using Stochastica.Drawables;

namespace Stochastica.MVVM.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    public double Sigma { get; set; }
    public double Mean { get; set; }
    public double InitialPrice { get; set; }
    public int NumDays { get; set; }

    public Command GenerateGraphCommand { get; }

    private BrownianMotionDrawable _brownianMotionDrawable;
    public BrownianMotionDrawable BrownianMotionDrawable
    {
        get => _brownianMotionDrawable;
        set => SetProperty(ref _brownianMotionDrawable, value);
    }

    public MainPageViewModel() => GenerateGraphCommand = new Command(GenerateGraph);

    private void GenerateGraph()
    {
        //BrownianMotionDrawable = new BrownianMotionDrawable(Sigma, Mean, InitialPrice, NumDays);
        BrownianMotionDrawable = new BrownianMotionDrawable(10, 10, 20, 100);
    }
}