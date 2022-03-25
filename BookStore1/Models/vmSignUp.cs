using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore1.Models
{
    public class vmSignUp
    {
        public SignUpModel signUp { get; set; }
        public List<IdentityRole> liRole { get; set; }
    }
}
