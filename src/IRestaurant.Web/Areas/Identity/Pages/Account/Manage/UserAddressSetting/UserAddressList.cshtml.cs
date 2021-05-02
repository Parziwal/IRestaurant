using System;
using System.Collections.Generic;
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
    public class UserAddressListModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserRepository userRepository;

        public UserAddressListModel(
            UserManager<ApplicationUser> userManager,
            IUserRepository userRepository)
        {
            this.userManager = userManager;
            this.userRepository = userRepository;
        }

        public List<AddressWithIdDto> UserAddressList { get; set; }
        public async Task<IActionResult> OnGet()
        {
            var currentUser = await userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return NotFound($"Az alábbi azonosítóval rendelkezõ felhasználó betöltése nem lehetséges: '{userManager.GetUserId(User)}'.");
            }

            UserAddressList = (await userRepository.GetUserAddressList(currentUser.Id)).ToList();
            return Page();
        }

        public async Task<IActionResult> OnGetDelete(int addressId)
        {
            var currentUser = await userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return NotFound($"Az alábbi azonosítóval rendelkezõ felhasználó betöltése nem lehetséges: '{userManager.GetUserId(User)}'.");
            }

            await userRepository.DeleteUserAddress(addressId);

            return RedirectToPage("UserAddressList");
        }
    }
}
