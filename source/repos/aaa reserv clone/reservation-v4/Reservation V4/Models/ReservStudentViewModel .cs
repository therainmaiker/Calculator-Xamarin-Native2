using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reservation_V4.Models
{
    public class ReservStudentViewModel
    {
        [Key]
        public string UserId { get; set; }
        public int ReservationTypeId { get; set; }
        
        
        
        public int ReservationId { get; set; }
        
        
        public string ReservationName { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string Cause { get; set; }
    }
}
