using SFMS.MAUI.Models.Dashboard;

namespace SFMS.MAUI.Services.Dashboard
{
    public sealed class DashboardService : IDashboardService
    {
        public Task<IReadOnlyList<ProcessOutput>> GetProcessOutputsAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<RecentPallet>> GetRecentPalletsAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<DashboardSummary> GetSummaryAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
