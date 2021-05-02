using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using IRestaurant.DAL.Data;
using IRestaurant.DAL.DTO.Addresses;
using IRestaurant.DAL.Models;
using IRestaurant.DAL.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace IRestaurant.Web.Areas.Identity.Pages.Account.Manage.UserAddressSetting
{
    [Authorize(Roles = UserRoles.Guest)]
    public class CreateUserAddressModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserRepository userRepository;

        public CreateUserAddressModel(
            UserManager<ApplicationUser> userManager,
            IUserRepository userRepository)
        {
            this.userManager = userManager;
            this.userRepository = userRepository;
        }

        [BindProperty]
        public CreateOrEditAddressDto UserAddress { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var currentUser = await userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            await userRepository.CreatetUserAddress(currentUser.Id, UserAddress);

            return RedirectToPage("UserAddressList");
        }
    }
}
