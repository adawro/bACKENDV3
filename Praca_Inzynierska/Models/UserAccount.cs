using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Praca_Inzynierska.Models
{
    public class UserAccount : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Rola { get; set; }
    }
}

