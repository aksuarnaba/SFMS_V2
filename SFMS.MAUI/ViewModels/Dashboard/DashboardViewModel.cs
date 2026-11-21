using CommunityToolkit.Mvvm.ComponentModel;
using SFMS.MAUI.Models.Dashboard;
using SFMS.MAUI.Services.Dashboard;
using System.Collections.ObjectModel;

namespace SFMS.MAUI.ViewModels.Dashboard
{
    public partial class DashboardViewModel(
        IDashboardService dashboardService) : ObservableObject
    {
        private readonly IDashboardService _dashboardService = dashboardService;

        private CancellationTokenSource? _refreshCancellationTokenSource;

        [ObservableProperty]
        public partial DashboardSummary Summary { get; set; }
            = new(
                TotalQtyProcessedToday: 0,
                ProcessJobByMachineToday: 0,
                ProcessJobByMachineThisWeek: 0,
                ProcessJobBySectionToday: 0,
                GeneratedPalletsToday: 0,
                GeneratedChecklistToday: 0);

        [ObservableProperty]
        public partial bool IsBusy { get; set; }

        [ObservableProperty]
        public partial bool HasError { get; set; }

        [ObservableProperty]
        public partial string ErrorMessage { get; set; }
            = string.Empty;

        [ObservableProperty]
        public partial DateTimeOffset? LastUpdatedAt { get; set; }

        public ObservableCollection<ProcessOutput>
            ProcessOutputs
        { get; } = [];

        public ObservableCollection<RecentPallet>
            RecentPallets
        { get; } = [];

        public async Task StartRealtimeUpdatesAsync()
        {
            StopRealtimeUpdates();

            _refreshCancellationTokenSource =
                new CancellationTokenSource();

            var cancellationToken =
                _refreshCancellationTokenSource.Token;

            /*
             * Load immediately so the user does not wait
             * five seconds for the first dashboard values.
             */
            await LoadAsync(cancellationToken);

            _ = RunRefreshLoopAsync(cancellationToken);
        }

        public void StopRealtimeUpdates()
        {
            if (_refreshCancellationTokenSource is null)
            {
                return;
            }

            _refreshCancellationTokenSource.Cancel();
            _refreshCancellationTokenSource.Dispose();
            _refreshCancellationTokenSource = null;
        }

        private async Task RunRefreshLoopAsync(
            CancellationToken cancellationToken)
        {
            using var timer = new PeriodicTimer(
                TimeSpan.FromSeconds(5));

            try
            {
                while (await timer.WaitForNextTickAsync(
                           cancellationToken))
                {
                    await LoadAsync(cancellationToken);
                }
            }
            catch (OperationCanceledException)
            {
                // Expected when leaving the dashboard.
            }
        }

        private async Task LoadAsync(
            CancellationToken cancellationToken)
        {
            if (IsBusy)
            {
                return;
            }

            try
            {
                IsBusy = true;
                HasError = false;
                ErrorMessage = string.Empty;

                var summaryTask =
                    _dashboardService.GetSummaryAsync(
                        cancellationToken);

                var processOutputsTask =
                    _dashboardService.GetProcessOutputsAsync(
                        cancellationToken);

                var recentPalletsTask =
                    _dashboardService.GetRecentPalletsAsync(
                        cancellationToken);

                await Task.WhenAll(
                    summaryTask,
                    processOutputsTask,
                    recentPalletsTask);

                Summary = await summaryTask;

                ReplaceCollection(
                    ProcessOutputs,
                    await processOutputsTask);

                ReplaceCollection(
                    RecentPallets,
                    await recentPalletsTask);

                LastUpdatedAt = DateTimeOffset.Now;
            }
            catch (OperationCanceledException)
            {
                // Expected during page navigation.
            }
            catch (Exception exception)
            {
                HasError = true;

                ErrorMessage =
                    $"Dashboard data could not be loaded: " +
                    $"{exception.Message}";
            }
            finally
            {
                IsBusy = false;
            }
        }

        private static void ReplaceCollection<T>(
            ObservableCollection<T> target,
            IEnumerable<T> source)
        {
            target.Clear();

            foreach (var item in source)
            {
                target.Add(item);
            }
        }
    }
}