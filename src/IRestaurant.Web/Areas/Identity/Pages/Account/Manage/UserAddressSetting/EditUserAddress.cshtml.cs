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
    public class EditUserAddressModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserRepository userRepository;

        public EditUserAddressModel(
            UserManager<ApplicationUser> userManager,
            IUserRepository userRepository)
        {
            this.userManager = userManager;
            this.userRepository = userRepository;
        }

        [BindProperty]
        public int UserAddressId { get; set; }
        [BindProperty]
        public CreateOrEditAddressDto UserAddress { get; set; }

        public async Task<IActionResult> OnGetAsync(int addressId)
        {
            var currentUser = await userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return NotFound($"Az alábbi azonosítóval rendelkezõ felhasználó betöltése nem lehetséges: '{userManager.GetUserId(User)}'.");
            }

            var addressWithId = await userRepository.GetUserAddress(addressId);
            UserAddressId = addressId;
            UserAddress = new CreateOrEditAddressDto
            {
                ZipCode = addressWithId.ZipCode,
                City = addressWithId.City,
                Street = addressWithId.Street,
                PhoneNumber = addressWithId.PhoneNumber
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var currentUser = await userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return NotFound($"Az alábbi azonosítóval rendelkezõ felhasználó betöltése nem lehetséges: '{userManager.GetUserId(User)}'.");
            }

            await userRepository.EditUserAddress(UserAddressId, UserAddress);

            return RedirectToPage("UserAddressList");
        }
    }
}
