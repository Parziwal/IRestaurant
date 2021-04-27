using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IRestaurant.DAL.Data;
using IRestaurant.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace IRestaurant.Web.Areas.Identity.Pages.Account.Manage.UserAddressSetting
{
    public class EditUserAddressModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext dbContext;

        public EditUserAddressModel(
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.dbContext = context;
        }

        [BindProperty]
        public int UserAddressId { get; set; }
        [BindProperty]
        public AddressOwned UserAddress { get; set; }

        public async Task<IActionResult> OnGetAsync(int addressId)
        {
            var currentUser = await userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return NotFound($"Az alábbi azonosítóval rendelkezõ felhasználó betöltése nem lehetséges: '{userManager.GetUserId(User)}'.");
            }

            UserAddressId = addressId;
            UserAddress = (await dbContext.UserAddresses
                                .SingleOrDefaultAsync(ua => ua.Id == addressId && ua.User == currentUser)).Address;
            if (UserAddress == null)
            {
                return NotFound($"Az alábbi azonosítóval rendelkezõ cím nem található: '{addressId}'.");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var currentUser = await userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return NotFound($"Az alábbi azonosítóval rendelkezõ felhasználó betöltése nem lehetséges: '{userManager.GetUserId(User)}'.");
            }
            var dbUserAddress = await dbContext.UserAddresses
                   .SingleOrDefaultAsync(ua => ua.Id == UserAddressId && ua.User == currentUser);
            if (dbUserAddress == null)
            {
                return NotFound($"Az alábbi azonosítóval rendelkezõ cím nem található: '{UserAddressId}'.");
            }

            if (!ModelState.IsValid)
            {
                UserAddress = dbUserAddress.Address;
                return Page();
            }

            dbUserAddress.Address.ZipCode = UserAddress.ZipCode;
            dbUserAddress.Address.City = UserAddress.City;
            dbUserAddress.Address.Street = UserAddress.Street;
            dbUserAddress.Address.PhoneNumber = UserAddress.PhoneNumber;

            await dbContext.SaveChangesAsync();

            return RedirectToPage("UserAddressList");
        }
    }
}
