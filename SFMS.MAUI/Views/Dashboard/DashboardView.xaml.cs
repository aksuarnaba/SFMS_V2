using SFMS.MAUI.ViewModels.Dashboard;

namespace SFMS.MAUI.Views.Dashboard;

public partial class DashboardView : ContentView
{
    private readonly DashboardViewModel _viewModel;

    public DashboardView(
        DashboardViewModel viewModel)
    {
        InitializeComponent();

        _viewModel = viewModel;
        BindingContext = _viewModel;

        Loaded += OnLoaded;
        Unloaded += OnUnloaded;
    }

    private async void OnLoaded(
        object? _,
        EventArgs __)
    {
        await _viewModel.StartRealtimeUpdatesAsync();
    }

    private void OnUnloaded(
        object? _,
        EventArgs __)
    {
        _viewModel.StopRealtimeUpdates();
    }
}