using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hellang.Middleware.ProblemDetails;
using IRestaurant.BL.Managers;
using IRestaurant.DAL.CustomExceptions;
using IRestaurant.DAL.Data;
using IRestaurant.DAL.DTO.Addresses;
using IRestaurant.DAL.Models;
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
        private readonly UserAddressManager userAddressManager;

        public UserAddressListModel(UserAddressManager userAddressManager)
        {
            this.userAddressManager = userAddressManager;
        }

        public List<AddressWithIdDto> UserAddressList { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                UserAddressList = (await userAddressManager.GetCurrentGuestAddressList()).ToList();
            } catch(EntityNotFoundException ex)
            {
                ErrorMessage = ex.Message;
            }
            
            return Page();
        }

        public async Task<IActionResult> OnGetDelete(int addressId)
        {
            try
            {
                await userAddressManager.DeleteUserAddress(addressId);
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
