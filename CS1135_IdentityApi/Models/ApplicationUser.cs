using System;
using Microsoft.AspNetCore.Identity;

namespace CS1135_IdentityApi.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
    }
}
