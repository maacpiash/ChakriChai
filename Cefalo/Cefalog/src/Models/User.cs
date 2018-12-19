using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Cefalog.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }

        //public User(string username) : base(username) { }


    }
}
