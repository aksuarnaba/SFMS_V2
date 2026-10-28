using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Application.Common.Interfaces
{
    public interface IAuthService
    {
        Task<string?> LoginAsync(string empNum, string password);
    }
}
