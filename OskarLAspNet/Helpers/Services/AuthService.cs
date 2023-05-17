using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OskarLAspNet.Helpers.Repos;
using OskarLAspNet.Models.Entities;
using OskarLAspNet.Models.Identity;
using OskarLAspNet.Models.ViewModels;
using System.Linq.Expressions;

namespace OskarLAspNet.Helpers.Services
{
    public class AuthService
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly AddressService _addressService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthService(UserManager<AppUser> userManager, AddressService addressService, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _addressService = addressService;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }



        public async Task<bool> UserAlreadyExistsAsync(Expression<Func<AppUser, bool>> expression)
        {
            return await _userManager.Users.AnyAsync(expression);

        }


        public async Task<bool> RegisterUserAsync(UserRegisterVM viewModel)
        {
            AppUser appUser = viewModel;
            var roleName = "user";

            if (!await _roleManager.Roles.AnyAsync())
            {
                await _roleManager.CreateAsync(new IdentityRole("admin"));
                await _roleManager.CreateAsync(new IdentityRole("user"));

            }

            if (!await _userManager.Users.AnyAsync())
                roleName = "admin";

            var result = await _userManager.CreateAsync(appUser, viewModel.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(appUser, roleName);



                var addressEntity = await _addressService.GetOrCreateAsync(viewModel);
                if (addressEntity != null)
                {
                    await _addressService.AddAddressAsync(appUser, addressEntity);
                    return true;
                }

            }

            return false;
        }

        //Inlogg
        public async Task<bool> LoginAsync(UserLoginVM viewModel)
        {
            var appUser = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == viewModel.Email);
            if (appUser != null)
            {
                var result = await _signInManager.PasswordSignInAsync(appUser, viewModel.Password, viewModel.RememberMe, false);
                return result.Succeeded;
            }
            return false;
        }

        
    }
}
