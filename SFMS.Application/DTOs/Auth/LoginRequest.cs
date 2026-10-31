using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SFMS.Application.DTOs.Auth
{
    public sealed record LoginRequest(
        [Required(ErrorMessage = "Site is required")] string Site,
        [Required(ErrorMessage = "Employee number is required")] string EmpNum,
        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 255 characters")]
        string Password);
}
