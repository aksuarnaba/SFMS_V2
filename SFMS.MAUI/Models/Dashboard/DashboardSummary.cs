using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.MAUI.Models.Dashboard
{
    public sealed record DashboardSummary(
        int TotalQtyProcessedToday,
        int ProcessJobByMachineToday,
        int ProcessJobByMachineThisWeek,
        int ProcessJobBySectionToday,
        int GeneratedPalletsToday,
        int GeneratedChecklistToday
        );
    
}
