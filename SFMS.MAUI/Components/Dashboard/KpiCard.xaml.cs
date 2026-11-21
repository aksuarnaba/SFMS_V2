namespace SFMS.MAUI.Components.Dashboard;

public partial class KpiCard : ContentView
{
    public static readonly BindableProperty TitleProperty =
        BindableProperty.Create(
            nameof(Title),
            typeof(string),
            typeof(KpiCard),
            string.Empty);

    public static readonly BindableProperty ValueProperty =
        BindableProperty.Create(
            nameof(Value),
            typeof(string),
            typeof(KpiCard),
            "0");

    public static readonly BindableProperty DescriptionProperty =
        BindableProperty.Create(
            nameof(Description),
            typeof(string),
            typeof(KpiCard),
            string.Empty);

    public static readonly BindableProperty ValueColorProperty =
        BindableProperty.Create(
            nameof(ValueColor),
            typeof(Color),
            typeof(KpiCard),
            Colors.Black);

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public string Value
    {
        get => (string)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    public string Description
    {
        get => (string)GetValue(DescriptionProperty);
        set => SetValue(DescriptionProperty, value);
    }

    public Color ValueColor
    {
        get => (Color)GetValue(ValueColorProperty);
        set => SetValue(ValueColorProperty, value);
    }

    public KpiCard()
    {
        InitializeComponent();
    }
}