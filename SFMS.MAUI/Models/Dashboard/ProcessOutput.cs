using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.MAUI.Models.Dashboard
{
    public sealed record ProcessOutput(
        string ProcessName,
        int PalletCount,
        double Percentage
        );
}
