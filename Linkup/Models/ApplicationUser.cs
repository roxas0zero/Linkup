using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Linkup.Models
{
    public class ApplicationUser
    {
        [Key]        
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Project> Projects { get; set; }
    }
}
