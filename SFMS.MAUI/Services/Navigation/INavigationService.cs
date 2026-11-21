using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.MAUI.Services.Navigation
{
    public interface INavigationService
    {
        Task GoToMainAsync();
        Task GoToLoginAsync();
    }
}
