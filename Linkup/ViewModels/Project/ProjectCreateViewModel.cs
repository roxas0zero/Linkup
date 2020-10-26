using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Linkup.ViewModels.Project
{
    public class ProjectCreateViewModel
    {
        public int ProjectId { get; set; }
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [Display(Name = "Due Date")]
        public DateTime DueDate { get; set; }
        public int SelectedSkill { get; set; }
        public List<SelectListItem> SkillsList { get; set; }
        public List<ProjectSkillViewModel> NeededSkills { get; set; }
        public int SelectedInterest { get; set; }
        public List<SelectListItem> InterestList { get; set; }
        public List<ProjectInterestViewModel> RelatedInterests { get; set; }
    }

    public class ProjectSkillViewModel
    {
        public int Id { get; set; }
        public string Skill { get; set; }
    }

    public class ProjectInterestViewModel
    {
        public int Id { get; set; }
        public string Interest { get; set; }
    }
}
