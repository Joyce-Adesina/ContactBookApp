using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactBook_Domain.Model.Common;
using Microsoft.AspNetCore.Identity;

namespace ContactBook_Domain.Model.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateTime { get; set; }
        public string Birthday { get; set; }
    }
}
