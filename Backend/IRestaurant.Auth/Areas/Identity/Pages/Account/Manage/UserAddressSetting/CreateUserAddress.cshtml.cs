using System.Threading.Tasks;
using IRestaurant.BL.Managers;
using IRestaurant.DAL.CustomExceptions;
using IRestaurant.DAL.Data;
using IRestaurant.DAL.DTO.Addresses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IRestaurant.Web.Areas.Identity.Pages.Account.Manage.UserAddressSetting
{
    [Authorize(Roles = UserRoles.Guest)]
    public class CreateUserAddressModel : PageModel
    {
        private readonly UserAddressManager userAddressManager;

        public CreateUserAddressModel(
            UserAddressManager userAddressManager)
        {
            this.userAddressManager = userAddressManager;
        }

        [BindProperty]
        public CreateOrEditAddressDto UserAddress { get; set; }


        [TempData]
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await userAddressManager.CreateUserAddress(UserAddress);
            }
            catch (EntityNotFoundException ex)
            {
                ErrorMessage = ex.Message;
            }

            return RedirectToPage("UserAddressList");
        }
    }
}
