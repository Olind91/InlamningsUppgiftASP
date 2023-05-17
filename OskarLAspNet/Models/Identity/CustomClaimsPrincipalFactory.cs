using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;


namespace OskarLAspNet.Models.Identity
{
    public class CustomClaimsPrincipalFactory : UserClaimsPrincipalFactory<AppUser>
    {
        private readonly UserManager<AppUser> _userManager;

        public CustomClaimsPrincipalFactory(UserManager<AppUser> userManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
        {
            _userManager = userManager;
        }



        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(AppUser user)
        {
            var claimsIdentity = await base.GenerateClaimsAsync(user);

            if (await _userManager.IsInRoleAsync(user, "admin"))
            {
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
            }
            else
            {
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, "user"));
            }

            claimsIdentity.AddClaim(new Claim("DisplayName", $"{user.FirstName} {user.LastName}"));
            claimsIdentity.AddClaim(new Claim("FirstName", $"{user.FirstName}"));

            return claimsIdentity;
        }


    }
}
