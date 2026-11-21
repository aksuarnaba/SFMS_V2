using SFMS.MAUI.Views.Dashboard;

namespace SFMS.MAUI.Views.Layout;

public partial class MainPage : ContentPage
{
    private readonly DashboardView _dashboardView;

    public MainPage(
        DashboardView dashboardView)
    {
        InitializeComponent();

        _dashboardView = dashboardView;

        ShowDashboard();
    }

    private void ShowDashboard()
    {
        MainContent.Content = _dashboardView;

        TopBar.PageTitle =
            "SFMS Production Operations";

        Sidebar.SelectedRoute =
            "Dashboard";
    }

    private void OnNavigationRequested(
        object? _,
        string route)
    {
        switch (route)
        {
            case "Dashboard":
                ShowDashboard();
                break;

            case "PalletTagging":
                MainContent.Content = null;
                TopBar.PageTitle = "Pallet Tagging";
                break;

            case "Production":
                MainContent.Content = null;
                TopBar.PageTitle = "Production";
                break;

            case "Monitoring":
                MainContent.Content = null;
                TopBar.PageTitle = "Monitoring";
                break;

            case "Reports":
                MainContent.Content = null;
                TopBar.PageTitle = "Reports";
                break;

            case "Administration":
                MainContent.Content = null;
                TopBar.PageTitle = "Administration";
                break;

            case "Settings":
                MainContent.Content = null;
                TopBar.PageTitle = "Settings";
                break;
        }
    }

    private void OnLogoutRequested(
        object? _,
        EventArgs __)
    {
        // We'll implement logout later.
    }
}