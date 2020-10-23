using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Linkup.ViewModels.Profile
{
    public class ProfileInterestsViewModel
    {
        public int SelectedInterest { get; set; }
        public List<ProfileInterestViewModel> CurrentInterests { get; set; }
        public List<SelectListItem> Interests { get; set; }
    }

    public class ProfileInterestViewModel
    {
        public int Id { get; set; }
        public string Interest { get; set; }
    }
}
