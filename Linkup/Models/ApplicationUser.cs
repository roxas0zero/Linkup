using System.Collections.Generic;

namespace Linkup.Models
{
    public class ApplicationUser
    {
        public string CorpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Project> Projects { get; set; }
    }
}
