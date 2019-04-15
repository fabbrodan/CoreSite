using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Site.Models
{
    public partial class Users
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public string UserRootPath { get; set; }
    }
}
