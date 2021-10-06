using System;
using System.Threading.Tasks;
using IRestaurant.BL.Managers;
using IRestaurant.DAL.Data;
using IRestaurant.DAL.DTO.Addresses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IRestaurant.Web.Areas.Identity.Pages.Account.Manage.UserAddressSetting
{
    [Authorize(Roles = UserRoles.Guest)]
    public class EditUserAddressModel : PageModel
    {
        private readonly UserManager userManager;

        public EditUserAddressModel(
            UserManager userManager)
        {
            this.userManager = userManager;
        }

        [BindProperty]
        public int UserAddressId { get; set; }
        [BindProperty]
        public CreateOrEditAddressDto UserAddress { get; set; }

        public async Task<IActionResult> OnGetAsync(int addressId)
        {
            try
            {
                var addressWithId = await userManager.GetUserAddress(addressId);
                UserAddressId = addressId;
                UserAddress = new CreateOrEditAddressDto
                {
                    ZipCode = addressWithId.ZipCode,
                    City = addressWithId.City,
                    Street = addressWithId.Street,
                    PhoneNumber = addressWithId.PhoneNumber
                };
            }
            catch (Exception)
            {
                ModelState.AddModelError("Error", "Hiba történt a lakcím betöltése során, kérem próbálja újra.");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await userManager.EditUserAddress(UserAddressId, UserAddress);
            }
            catch (Exception)
            {
                ModelState.AddModelError("Error", "Hiba történt a lakcímek mentése során, kérem próbálja újra.");
            }

            return RedirectToPage("UserAddressList");
        }
    }
}
