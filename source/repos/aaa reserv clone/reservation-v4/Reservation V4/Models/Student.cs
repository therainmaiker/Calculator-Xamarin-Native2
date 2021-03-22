using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Reservation_V4.Models
{
    public class Student:IdentityUser
    {
        //public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ResCounter { get; set; } = 0;

        

    }
}
