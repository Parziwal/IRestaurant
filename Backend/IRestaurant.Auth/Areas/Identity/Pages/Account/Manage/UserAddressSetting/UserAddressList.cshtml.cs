using System;
using System.Collections.Generic;
using System.Linq;
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
    public class UserAddressListModel : PageModel
    {
        private readonly UserManager userManager;

        public UserAddressListModel(UserManager userManager)
        {
            this.userManager = userManager;
        }

        public List<AddressWithIdDto> UserAddressList { get; set; }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                UserAddressList = (await userManager.GetCurrentGuestAddressList()).ToList();
            } catch(Exception)
            {
                UserAddressList = new List<AddressWithIdDto>();
                ModelState.AddModelError("Error", "Hiba t�rt�nt a lakc�mek bet�lt�se sor�n, k�rem pr�b�lja �jra.");
            }
            
            return Page();
        }

        public async Task<IActionResult> OnDelete(int addressId)
        {
            try
            {
                await userManager.DeleteUserAddress(addressId);
            } 
            catch (Exception)
            {
                ModelState.AddModelError("Error", "Hiba t�rt�nt a lakc�mek t�rl�se sor�n, k�rem pr�b�lja �jra.");
            }

            return RedirectToPage("UserAddressList");
        }
    }
}
