using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AuthAPI.Models
{
    public class AssignRoleToUser
    {
        [DisplayName("Role")]
        [Required(ErrorMessage = "Choose Role")]
        public string RoleId { get; set; }
        public List<SelectListItem> ListRole { get; set; }
        [DisplayName("User")]
        [Required(ErrorMessage = "Choose Username")]
        public string UserId { get; set; }
        [Required(ErrorMessage = "Choose Username")]
        public string Username { get; set; }
    }
}