using SFMS.Application.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Application.Common.Interfaces
{
    public interface IAuthService
    {
        Task<string?> LoginAsync(LoginRequest request, CancellationToken ct = default);
    }
}
