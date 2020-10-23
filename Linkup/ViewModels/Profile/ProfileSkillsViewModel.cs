using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linkup.ViewModels.Profile
{
    public class ProfileSkillsViewModel
    {
        public int SelectedSkill { get; set; }
        public List<ProfileSkillViewModel> CurrentSkills { get; set; }
        public List<SelectListItem> Skills { get; set; }
    }

    public class ProfileSkillViewModel
    {
        public int Id { get; set; }
        public string Skill { get; set; }
    }
}
