using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.MAUI.Models.Authentication
{
    public sealed record SiteOption(
        int Value,
        string Code,
        string CompanyName)
    {
        public string DisplayName =>
            CompanyName;

        public override string ToString() => DisplayName;
    }

}
