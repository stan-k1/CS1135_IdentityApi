using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CS1135_IdentityApi.Models
{
    public class LoginModel
    {
        [Required] public string Username { get; set; }

        [Required] public string Password { get; set; }
    }
}
