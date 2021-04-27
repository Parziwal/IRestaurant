using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using IRestaurant.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IRestaurant.Web.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public string Username { get; set; }

            public string FullName { get; set; }

        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await userManager.GetUserNameAsync(user);

            Input = new InputModel
            {
                Username = userName,
                FullName = user.FullName,
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Az alábbi azonosítóval rendelkező felhasználó betöltése nem lehetséges: '{userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Az alábbi azonosítóval rendelkező felhasználó betöltése nem lehetséges: '{userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var userName = await userManager.GetUserNameAsync(user);
            if (Input.Username != userName)
            {
                var userNameExists = await userManager.FindByNameAsync(Input.Username);
                if (userNameExists != null)
                {
                    StatusMessage = "A felhasználónév már használatban van. Kérlek válasz egy másikat.";
                    return RedirectToPage();
                }
                var setUserName = await userManager.SetUserNameAsync(user, Input.Username);
                if (!setUserName.Succeeded)
                {
                    StatusMessage = "Hiba történt felhasználónév megváltoztatása során.";
                    return RedirectToPage();
                }
            }

            if (Input.FullName != user.FullName)
            {
                user.FullName = Input.FullName;
                var setFullNameResult = await userManager.UpdateAsync(user);
                if (!setFullNameResult.Succeeded)
                {
                    StatusMessage = "Hiba történt a vezeték és keresztnév megváltoztatása során.";
                    return RedirectToPage();
                }
            }

            await signInManager.RefreshSignInAsync(user);
            StatusMessage = "A profilod frissítésre került.";
            return RedirectToPage();
        }
    }
}
