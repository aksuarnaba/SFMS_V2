using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.MAUI.Models.Authentication
{
    public sealed record LoginRequest(
        int Site,
        string EmployeeNumber,
        string Password);

}
