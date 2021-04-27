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
    public class UserAddressListModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext dbContext;

        public UserAddressListModel(
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext dbContext)
        {
            this.userManager = userManager;
            this.dbContext = dbContext;
        }

        public List<UserAddress> UserAddressList { get; set; }
        public async Task<IActionResult> OnGet()
        {
            var currentUser = await userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return NotFound($"Az alábbi azonosítóval rendelkezõ felhasználó betöltése nem lehetséges: '{userManager.GetUserId(User)}'.");
            }

            UserAddressList = await dbContext.UserAddresses
                                    .Where(ua => ua.User == currentUser)
                                    .ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnGetDelete(int addressId)
        {
            var currentUser = await userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return NotFound($"Az alábbi azonosítóval rendelkezõ felhasználó betöltése nem lehetséges: '{userManager.GetUserId(User)}'.");
            }
            var dbUserAddress = await dbContext.UserAddresses
                                .SingleOrDefaultAsync(ua => ua.Id == addressId && ua.User == currentUser);

            if (dbUserAddress == null)
            {                
                return NotFound($"Az alábbi azonosítóval rendelkezõ cím nem található: '{addressId}'.");
            }

            dbContext.Remove(dbUserAddress);
            await dbContext.SaveChangesAsync();

            return RedirectToPage("UserAddressList");
        }
    }
}
