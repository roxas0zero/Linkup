using Linkup.Enums;
using System;
using System.Collections.Generic;

namespace Linkup.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public List<ApplicationUser> Participants { get; set; }
        public List<Skill> NeededSkills { get; set; }
        public List<Interest> RelatedInterests { get; set; }
        public int Progress { get; set; }
        public Status Status { get; set; }
    }
}
