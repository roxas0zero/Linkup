//using Linkup.Data;
//using Microsoft.AspNetCore.Authentication;
//using System.Linq;
//using System.Security.Claims;
//using System.Threading.Tasks;

//namespace Linkup.Infrastructure
//{
//    public class ClaimsTransformer : IClaimsTransformation
//    {
//        private readonly ApplicationDbContext applicationDbContext;

//        public ClaimsTransformer(ApplicationDbContext applicationDbContext)
//        {
//            this.applicationDbContext = applicationDbContext;
//        }

//        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
//        {
//            ClaimsIdentity identity = (ClaimsIdentity)principal.Identity;
//            string corpId = identity.Name.Substring(identity.Name.LastIndexOf("\\") + 1);
//            string role = applicationDbContext.ApplicationUsers.FirstOrDefault(u => u.CorpId == corpId)?.Role.ToString();
//            if (!string.IsNullOrEmpty(role))
//            {
//                Claim claim = new Claim(ClaimTypes.Role, role);
//                identity.AddClaim(claim);
//            }
//            return Task.FromResult(principal);
//        }
//    }
//}
