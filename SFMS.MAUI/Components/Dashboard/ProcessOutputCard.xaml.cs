namespace SFMS.MAUI.Components.Dashboard;

public partial class ProcessOutputCard : ContentView
{
    public static readonly BindableProperty ProcessNameProperty =
        BindableProperty.Create(
            nameof(ProcessName),
            typeof(string),
            typeof(ProcessOutputCard),
            string.Empty);

    public static readonly BindableProperty PalletCountProperty =
        BindableProperty.Create(
            nameof(PalletCount),
            typeof(int),
            typeof(ProcessOutputCard),
            0);

    public static readonly BindableProperty PercentageProperty =
        BindableProperty.Create(
            nameof(Percentage),
            typeof(double),
            typeof(ProcessOutputCard),
            0d);

    public string ProcessName
    {
        get => (string)GetValue(ProcessNameProperty);
        set => SetValue(ProcessNameProperty, value);
    }

    public int PalletCount
    {
        get => (int)GetValue(PalletCountProperty);
        set => SetValue(PalletCountProperty, value);
    }

    public double Percentage
    {
        get => (double)GetValue(PercentageProperty);
        set => SetValue(PercentageProperty, value);
    }

    public ProcessOutputCard()
    {
        InitializeComponent();
    }
}