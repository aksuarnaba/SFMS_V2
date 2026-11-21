using SFMS.MAUI.Models.Dashboard;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.MAUI.Services.Dashboard
{
    public interface IDashboardService
    {
        Task<DashboardSummary> GetSummaryAsync(CancellationToken ct = default);

        Task<IReadOnlyList<ProcessOutput>> GetProcessOutputsAsync(CancellationToken ct = default);
        Task<IReadOnlyList<RecentPallet>> GetRecentPalletsAsync(CancellationToken ct = default);
    }
}
