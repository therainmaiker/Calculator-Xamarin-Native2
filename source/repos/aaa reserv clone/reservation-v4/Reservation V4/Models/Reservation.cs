using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Reservation_V4.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public string? Cause { get; set; }

        
        
     
        public ReservationType ReservationType { get; set; }
        public int ReservationTypeId { get; set; }


        public IdentityUser User { get; set; }
        public string UserId { get; set; }

        public ContactStatus Status { get; set; }

        

    }
}

