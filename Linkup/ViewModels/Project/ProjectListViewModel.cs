using Linkup.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linkup.ViewModels.Project
{
    public class ProjectListViewModel
    {
        public List<ProjectViewModel> Projects { get; set; }
    }

    public class ProjectViewModel
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string CreatedBy { get; set; }        
        public int NeededSkills { get; set; }        
        public int Progress { get; set; }
        public Status Status { get; set; }
    }
}
