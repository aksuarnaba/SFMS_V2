using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.MAUI.Models.Dashboard
{
    public sealed record RecentPallet(
        string Machine,
        string JobNumber,
        string Suffix,
        string OperationNumber,
        string JobName,
        decimal Quantity,
        string Status,
        DateTimeOffset CreatedAt);
    
}
