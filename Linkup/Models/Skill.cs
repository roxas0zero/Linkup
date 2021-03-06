﻿using System.Collections.Generic;

namespace Linkup.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ApplicationUser> Users { get; set; }
        public List<Project> Projects { get; set; }
    }
}
