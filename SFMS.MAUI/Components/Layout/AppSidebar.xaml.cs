using SFMS.MAUI.Components.Navigation;

namespace SFMS.MAUI.Components.Layout;

public partial class AppSidebar : ContentView
{
    private readonly List<NavigationItem> _navigationItems;

    public event EventHandler<string>? NavigationRequested;

    public event EventHandler? LogoutRequested;

    public static readonly BindableProperty SelectedRouteProperty =
        BindableProperty.Create(
            nameof(SelectedRoute),
            typeof(string),
            typeof(AppSidebar),
            "Dashboard",
            propertyChanged: OnSelectedRouteChanged);

    public string SelectedRoute
    {
        get => (string)GetValue(SelectedRouteProperty);
        set => SetValue(SelectedRouteProperty, value);
    }

    public AppSidebar()
    {
        InitializeComponent();

        _navigationItems =
        [
            DashboardItem,
            PalletTaggingItem,
            ProductionItem,
            MonitoringItem,
            ReportsItem,
            AdministrationItem,
            SettingsItem
        ];

        UpdateSelectedItem();
    }

    private void OnNavigationRequested(
        object? _,
        string route)
    {
        if (string.Equals(
                route,
                "Logout",
                StringComparison.OrdinalIgnoreCase))
        {
            LogoutRequested?.Invoke(
                this,
                EventArgs.Empty);

            return;
        }

        SelectedRoute = route;

        NavigationRequested?.Invoke(
            this,
            route);
    }

    private static void OnSelectedRouteChanged(
        BindableObject bindable,
        object _,
        object __)
    {
        if (bindable is AppSidebar sidebar)
        {
            sidebar.UpdateSelectedItem();
        }
    }

    private void UpdateSelectedItem()
    {
        foreach (var item in _navigationItems)
        {
            item.IsSelected =
                string.Equals(
                    item.Route,
                    SelectedRoute,
                    StringComparison.OrdinalIgnoreCase);
        }
    }
}