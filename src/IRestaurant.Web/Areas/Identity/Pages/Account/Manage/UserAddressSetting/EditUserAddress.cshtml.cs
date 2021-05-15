using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hellang.Middleware.ProblemDetails;
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
    public class EditUserAddressModel : PageModel
    {
        private readonly UserAddressManager userAddressManager;

        public EditUserAddressModel(
            UserAddressManager userAddressManager)
        {
            this.userAddressManager = userAddressManager;
        }

        [BindProperty]
        public int UserAddressId { get; set; }
        [BindProperty]
        public CreateOrEditAddressDto UserAddress { get; set; }


        [TempData]
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int addressId)
        {
            try
            {
                var addressWithId = await userAddressManager.GetUserAddress(addressId);
                UserAddressId = addressId;
                UserAddress = new CreateOrEditAddressDto
                {
                    ZipCode = addressWithId.ZipCode,
                    City = addressWithId.City,
                    Street = addressWithId.Street,
                    PhoneNumber = addressWithId.PhoneNumber
                };
            }
            catch (ProblemDetailsException ex)
            {
                ErrorMessage = ex.Details.Title;
            }
            catch (EntityNotFoundException ex)
            {
                ErrorMessage = ex.Message;
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
                await userAddressManager.EditUserAddress(UserAddressId, UserAddress);
            }
            catch (ProblemDetailsException ex)
            {
                ErrorMessage = ex.Details.Title;
            }
            catch (EntityNotFoundException ex)
            {
                ErrorMessage = ex.Message;
            }

            return RedirectToPage("UserAddressList");
        }
    }
}
