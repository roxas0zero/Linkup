using Linkup.Models;
using Linkup.Services.Interfaces;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Globalization;

namespace Linkup.Services
{
    public class ActiveDirectoryService : IActiveDirectoryService
    {
        public string GetUserFirstName(string corpId)
        {
            PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, "CORP");
            UserPrincipal userPrincipal = UserPrincipal.FindByIdentity(principalContext, corpId);

            if (userPrincipal != null)
            {
                DirectoryEntry directoryEntry = userPrincipal.GetUnderlyingObject() as DirectoryEntry;
                if (directoryEntry.Properties["givenName"].Value != null)
                    return CultureInfo.GetCultureInfo("en-US").TextInfo
                        .ToTitleCase(directoryEntry.Properties["givenName"].Value.ToString().ToLower());
            }

            return null;
        }

        public ActiveDirectoryUser GetUserInfo(string corpId)
        {
            PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, "CORP");
            UserPrincipal userPrincipal = UserPrincipal.FindByIdentity(principalContext, corpId);

            if (userPrincipal != null)
            {
                DirectoryEntry directoryEntry = userPrincipal.GetUnderlyingObject() as DirectoryEntry;
                ActiveDirectoryUser activeDirectoryUser = new ActiveDirectoryUser();

                activeDirectoryUser.CorpId = corpId;

                if (directoryEntry.Properties["EmployeeNumber"].Value != null)
                    activeDirectoryUser.PRN = directoryEntry.Properties["EmployeeNumber"].Value.ToString();

                if (directoryEntry.Properties["mail"].Value != null)
                    activeDirectoryUser.Email = directoryEntry.Properties["mail"].Value.ToString().ToLower();

                if (directoryEntry.Properties["mobile"].Value != null)
                    activeDirectoryUser.Mobile = directoryEntry.Properties["mobile"].Value.ToString();

                if (directoryEntry.Properties["givenName"].Value != null)
                    activeDirectoryUser.FirstName = CultureInfo.GetCultureInfo("en-US").TextInfo
                        .ToTitleCase(directoryEntry.Properties["givenName"].Value.ToString().ToLower());

                if (directoryEntry.Properties["middleName"].Value != null)
                    activeDirectoryUser.MiddleName = CultureInfo.GetCultureInfo("en-US").TextInfo
                        .ToTitleCase(directoryEntry.Properties["middleName"].Value.ToString().ToLower());

                if (directoryEntry.Properties["DisplayName"].Value != null)
                    if (directoryEntry.Properties["DisplayName"].Value.ToString().Contains(","))
                    {
                        activeDirectoryUser.LastName = CultureInfo.GetCultureInfo("en-US").TextInfo
                            .ToTitleCase(directoryEntry.Properties["DisplayName"].Value.ToString()
                            .Substring(0, directoryEntry.Properties["DisplayName"].Value.ToString().IndexOf(',')).ToLower());
                    }
                    else
                    {
                        activeDirectoryUser.LastName = CultureInfo.GetCultureInfo("en-US").TextInfo
                            .ToTitleCase(directoryEntry.Properties["DisplayName"].Value.ToString());
                    }

                return activeDirectoryUser;
            }

            return null;
        }
    }
}
