using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.MAUI.Models.Authentication
{
    public sealed record LoginResponse(
        string AccessToken,
        string EmployeeNumber,
        string Name,
        int Site,
        int Role);
}
