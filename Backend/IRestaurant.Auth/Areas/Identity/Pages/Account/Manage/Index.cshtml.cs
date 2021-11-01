using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using IRestaurant.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IRestaurant.Auth.Areas.Identity.Pages.Account.Manage
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

            [Display(Name = "Vezetéknév és Keresztnév")]
            public string FullName { get; set; }

        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound("A felhasználó betöltése nem sikerült.");
            }

            Input = new InputModel
            {
                FullName = user.FullName,
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound("A felhasználó betöltése nem sikerült.");
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
