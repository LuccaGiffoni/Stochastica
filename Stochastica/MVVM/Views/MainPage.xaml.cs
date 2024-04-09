namespace Stochastica.MVVM.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        InitialPriceEntry.TextChanged += OnDoubleEntry;
        SigmaEntry.TextChanged += OnDoubleEntry;
        MeanEntry.TextChanged += OnDoubleEntry;
        NumDaysEntry.TextChanged += OnIntEntry;
    }

    private void OnDoubleEntry(object sender, TextChangedEventArgs e)
    {
        var entry = (Entry)sender;

        string allowedChars = "0123456789,";

        string filteredText = new(e.NewTextValue.Where(c => allowedChars.Contains(c)).ToArray());

        if (filteredText != entry.Text)
        {
            entry.Text = filteredText;
        }

        if (filteredText.Length > entry.Text.Length)
        {
            entry.CursorPosition = filteredText.Length;
        }
    }

    private void OnIntEntry(object sender, TextChangedEventArgs e)
    {
        var entry = (Entry)sender;

        string allowedChars = "0123456789";

        string filteredText = new(e.NewTextValue.Where(c => allowedChars.Contains(c)).ToArray());

        if (filteredText != entry.Text)
        {
            entry.Text = filteredText;
        }

        if (filteredText.Length > entry.Text.Length)
        {
            entry.CursorPosition = filteredText.Length;
        }
    }
}