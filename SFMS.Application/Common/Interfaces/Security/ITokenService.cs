using SFMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Application.Common.Interfaces.Security
{
    public interface ITokenService
    {
        string GenerateAccessToken(User user);
    }
}
