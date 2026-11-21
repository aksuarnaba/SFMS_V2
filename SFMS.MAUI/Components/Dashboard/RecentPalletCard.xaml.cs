namespace SFMS.MAUI.Components.Dashboard;

public partial class RecentPalletCard : ContentView
{
    public static readonly BindableProperty MachineProperty =
        BindableProperty.Create(
            nameof(Machine),
            typeof(string),
            typeof(RecentPalletCard),
            string.Empty);

    public static readonly BindableProperty JobNumberProperty =
        BindableProperty.Create(
            nameof(JobNumber),
            typeof(string),
            typeof(RecentPalletCard),
            string.Empty);

    public static readonly BindableProperty SuffixProperty =
        BindableProperty.Create(
            nameof(Suffix),
            typeof(string),
            typeof(RecentPalletCard),
            string.Empty);

    public static readonly BindableProperty OperationNumberProperty =
        BindableProperty.Create(
            nameof(OperationNumber),
            typeof(string),
            typeof(RecentPalletCard),
            string.Empty);

    public static readonly BindableProperty JobNameProperty =
        BindableProperty.Create(
            nameof(JobName),
            typeof(string),
            typeof(RecentPalletCard),
            string.Empty);

    public static readonly BindableProperty QuantityProperty =
        BindableProperty.Create(
            nameof(Quantity),
            typeof(decimal),
            typeof(RecentPalletCard),
            0m);

    public static readonly BindableProperty StatusProperty =
        BindableProperty.Create(
            nameof(Status),
            typeof(string),
            typeof(RecentPalletCard),
            string.Empty);

    public static readonly BindableProperty CreatedAtProperty =
        BindableProperty.Create(
            nameof(CreatedAt),
            typeof(DateTimeOffset),
            typeof(RecentPalletCard),
            default(DateTimeOffset));

    public string Machine
    {
        get => (string)GetValue(MachineProperty);
        set => SetValue(MachineProperty, value);
    }

    public string JobNumber
    {
        get => (string)GetValue(JobNumberProperty);
        set => SetValue(JobNumberProperty, value);
    }

    public string Suffix
    {
        get => (string)GetValue(SuffixProperty);
        set => SetValue(SuffixProperty, value);
    }

    public string OperationNumber
    {
        get => (string)GetValue(OperationNumberProperty);
        set => SetValue(OperationNumberProperty, value);
    }

    public string JobName
    {
        get => (string)GetValue(JobNameProperty);
        set => SetValue(JobNameProperty, value);
    }

    public decimal Quantity
    {
        get => (decimal)GetValue(QuantityProperty);
        set => SetValue(QuantityProperty, value);
    }

    public string Status
    {
        get => (string)GetValue(StatusProperty);
        set => SetValue(StatusProperty, value);
    }

    public DateTimeOffset CreatedAt
    {
        get => (DateTimeOffset)GetValue(CreatedAtProperty);
        set => SetValue(CreatedAtProperty, value);
    }

    public RecentPalletCard()
    {
        InitializeComponent();
    }
}