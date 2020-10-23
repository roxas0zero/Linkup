using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Linkup.ViewModels.Profile
{
    public class ProfileGeneralViewModel
    {
        public string Email { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Department { get; set; }
        public string Team { get; set; }
        public string Extension { get; set; }
    }
}
