using SkiaSharp;

namespace Stochastica.Drawables;

public class BrownianMotionDrawable(double sigma, double mean, double initialPrice, int numDays) 
{
    public double Sigma { get; set; } = sigma;
    public double Mean { get; set; } = mean;
    public double InitialPrice { get; set; } = initialPrice;
    public int NumDays { get; set; } = numDays;

    public void Draw(SKCanvas canvas, SKRect dirtyRect)
    {
        var prices = GenerateBrownianMotion(Sigma, Mean, InitialPrice, NumDays);
        //DrawGraph(canvas, dirtyRect, prices);
    }

    public static double[] GenerateBrownianMotion(double sigma, double mean, double initialPrice, int numDays)
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

    private static void DrawGraph(SKCanvas canvas, SKRect bounds, double[] prices)
    {
        if (prices != null && prices.Length > 1)
        {
            var deltaX = bounds.Width / (prices.Length - 1);
            var deltaY = bounds.Height / (prices.Max() - prices.Min());

            for (int i = 0; i < prices.Length - 1; i++)
            {
                var x1 = i * deltaX;
                var y1 = bounds.Height - ((prices[i] - prices.Min()) * deltaY);
                var x2 = (i + 1) * deltaX;
                var y2 = bounds.Height - ((prices[i + 1] - prices.Min()) * deltaY);
                var paint = new SKPaint(){ Color = SKColor.Parse("#F2A1G5") };
                canvas.DrawLine(x1, (float)y1, x2, (float)y2, paint);
            }
        }
    }
}