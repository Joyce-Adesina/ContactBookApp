using ContactBook_Domain.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook_Domain.Dtos.Response
{
    public class UserResponseDto
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
       
        public string Email { get; set; }
        public User userType { get; set; }
        public DateTime DateTime { get; set; }
        public string PhoneNumber { get; set; }
        public string Birthday { get; set; }
    }
}
