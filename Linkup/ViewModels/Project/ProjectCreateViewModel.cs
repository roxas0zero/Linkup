using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Linkup.ViewModels.Project
{
    public class ProjectCreateViewModel
    {        
        public string Title { get; set; }
        public string Description { get; set; }
        [Display(Name ="Due Date")]
        public DateTime DueDate { get; set; }        
        public List<SkillViewModel> NeededSkills { get; set; }
        public List<InterestViewModel> RelatedInterests { get; set; }               
    }

    public class SkillViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class InterestViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
