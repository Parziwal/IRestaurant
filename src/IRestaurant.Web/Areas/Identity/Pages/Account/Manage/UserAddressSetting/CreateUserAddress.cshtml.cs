using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
    public class CreateUserAddressModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext dbContext;

        public CreateUserAddressModel(
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.dbContext = context;
        }

        [BindProperty]
        public AddressOwned UserAddress { get; set; }

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

            var dbUserAddress = new UserAddress
            {
                Address = UserAddress,
                User = currentUser
            };
            dbContext.UserAddresses.Add(dbUserAddress);

            await dbContext.SaveChangesAsync();
            return RedirectToPage("UserAddressList");
        }
    }
}
