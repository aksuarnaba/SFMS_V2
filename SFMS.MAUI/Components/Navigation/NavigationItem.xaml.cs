namespace SFMS.MAUI.Components.Navigation;

public partial class NavigationItem : ContentView
{
    public static readonly BindableProperty TitleProperty =
        BindableProperty.Create(
            nameof(Title),
            typeof(string),
            typeof(NavigationItem),
            string.Empty);

    public static readonly BindableProperty IconProperty =
        BindableProperty.Create(
            nameof(Icon),
            typeof(string),
            typeof(NavigationItem),
            string.Empty);

    public static readonly BindableProperty RouteProperty =
        BindableProperty.Create(
            nameof(Route),
            typeof(string),
            typeof(NavigationItem),
            string.Empty);

    public static readonly BindableProperty IsSelectedProperty =
        BindableProperty.Create(
            nameof(IsSelected),
            typeof(bool),
            typeof(NavigationItem),
            false,
            propertyChanged: OnIsSelectedChanged);

    public event EventHandler<string>? NavigationRequested;

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public string Icon
    {
        get => (string)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    public string Route
    {
        get => (string)GetValue(RouteProperty);
        set => SetValue(RouteProperty, value);
    }

    public bool IsSelected
    {
        get => (bool)GetValue(IsSelectedProperty);
        set => SetValue(IsSelectedProperty, value);
    }

    public NavigationItem()
    {
        InitializeComponent();

        UpdateVisualState();
    }

    private void OnTapped(
        object? _,
        TappedEventArgs __)
    {
        NavigationRequested?.Invoke(
            this,
            Route);
    }

    private static void OnIsSelectedChanged(
        BindableObject bindable,
        object _,
        object __)
    {
        if (bindable is NavigationItem item)
        {
            item.UpdateVisualState();
        }
    }

    private void UpdateVisualState()
    {
        if (Container is null ||
            IconContainer is null ||
            IconLabel is null ||
            TitleLabel is null)
        {
            return;
        }

        if (IsSelected)
        {
            Container.BackgroundColor =
                GetColor("SidebarSelected");

            IconContainer.BackgroundColor =
                Colors.White.WithAlpha(0.16f);

            IconLabel.TextColor =
                Colors.White;

            TitleLabel.TextColor =
                Colors.White;

            TitleLabel.FontFamily =
                "LatoBold";

            return;
        }

        Container.BackgroundColor =
            Colors.Transparent;

        IconContainer.BackgroundColor =
            Colors.Transparent;

        IconLabel.TextColor =
            GetColor("SidebarText");

        TitleLabel.TextColor =
            GetColor("SidebarText");

        TitleLabel.FontFamily =
            "LatoRegular";
    }

    private static Color GetColor(
        string resourceKey)
    {
        if (Application.Current?
                .Resources
                .TryGetValue(
                    resourceKey,
                    out var resource) == true &&
            resource is Color color)
        {
            return color;
        }

        /*
         * Do NOT silently return Transparent here.
         *
         * Transparent made missing resource keys
         * almost impossible to diagnose because
         * controls simply disappeared.
         */

        return Colors.White;
    }
}