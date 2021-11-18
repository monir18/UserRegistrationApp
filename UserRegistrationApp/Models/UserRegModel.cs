using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserRegistrationApp.Models
{
    public class UserRegModel
    {
        [Required]
        [DisplayName("User ID")]
        public int id { get; set; }
        [DisplayName("Email ID")]
        public string emailid { get; set; }
        [DisplayName("User Password")]
        public string password { get; set; }
        [DisplayName("User Name")]
        public string name { get; set; }
    }
}
