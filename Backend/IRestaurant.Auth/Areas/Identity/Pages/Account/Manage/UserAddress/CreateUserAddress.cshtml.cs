using System;
using System.Threading.Tasks;
using IRestaurant.BLL.Managers;
using IRestaurant.DAL.DTO.Addresses;
using IRestaurant.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IRestaurant.Auth.Areas.Identity.Pages.Account.Manage.UserAddress
{
    [Authorize(Roles = UserRoles.Guest)]
    public class CreateUserAddressModel : PageModel
    {
        private readonly UserManager userManager;

        public CreateUserAddressModel(
            UserManager userManager)
        {
            this.userManager = userManager;
        }

        [BindProperty]
        public CreateOrEditAddressDto UserAddress { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await userManager.CreateUserAddress(UserAddress);
            }
            catch (Exception)
            {
                ModelState.AddModelError("Error", "Hiba történt a lakcímek létrehozása során, kérem próbálja újra.");
            }

            return RedirectToPage("UserAddressList");
        }
    }
}
