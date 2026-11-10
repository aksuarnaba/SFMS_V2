using System;
using System.Collections.Generic;
using System.Text;

namespace SFMS.Domain.Enums
{
    public enum SiteEnums
    {
        PiSp = 1,
        FpSp = 2,
        PiGrpSp = 3
    }

    public static class SiteEnumExtensions
    {
        public static string ToCode(this SiteEnums site) => site switch
        {
            SiteEnums.PiSp => "PI-SP",
            SiteEnums.FpSp => "FP-SP",
            SiteEnums.PiGrpSp => "PIGRP-SP",
            _ => throw new ArgumentOutOfRangeException(nameof(site), site, null)
        };
    }
}
