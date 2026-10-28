using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Application.DTOs.Auth
{
    public sealed record LoginRequest(
        string Site,
        string EmpNum,
        string Password);
}
