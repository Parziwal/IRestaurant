using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using IRestaurant.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using IRestaurant.BLL.Managers;
using IRestaurant.DAL.Data;
using IdentityServer4.Services;

namespace IRestaurant.Auth.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ILogger<RegisterModel> logger;
        private readonly IEmailSender emailSender;
        private readonly ApplicationUserManager applicationUserManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IIdentityServerInteractionService interactionService;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            ApplicationUserManager applicationUserManager,
            RoleManager<IdentityRole> roleManager,
            IIdentityServerInteractionService interactionService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
            this.emailSender = emailSender;
            this.applicationUserManager = applicationUserManager;
            this.roleManager = roleManager;
            this.interactionService = interactionService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "A szerepkör kiválasztása kötelező.")]
            public string Role { get; set; }
            [Required(ErrorMessage = "A vezeték és keresztnév megadása kötelező.")]
            [StringLength(50, ErrorMessage = "A vezeték és a keresztnév maximum {1} karakter hosszú lehet.")]
            [Display(Name = "Vezeték és keresztnév")]
            public string FullName { get; set; }
            [Required(ErrorMessage = "Az email cím megadása kötelező.")]
            [EmailAddress(ErrorMessage = "Az email cím nem érvényes.")]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "A jelszó megadása kötelező.")]
            [StringLength(100, ErrorMessage = "A jelszónak legalább {2} és maximum {1} karakter hosszúnak kell lennie.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Jelszó")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Jelszó megerősítése")]
            [Compare("Password", ErrorMessage = "A jelszavak nem egyeznek meg.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = Input.Email, Email = Input.Email, FullName = Input.FullName };
                var result = await userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    if (!await roleManager.RoleExistsAsync(Input.Role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(Input.Role));
                    }

                    await userManager.AddToRoleAsync(user, Input.Role);
                    if (Input.Role == UserRoles.Restaurant)
                    {
                        try
                        {
                            await applicationUserManager.CreateDefaultRestaurantForUser(user.Id);
                        }
                        catch (Exception)
                        {
                            await userManager.DeleteAsync(user);
                            ModelState.AddModelError("Error", "Hiba történt a regisztráció során, kérlem próbálja újra.");
                            return Page();
                        }
                    }

                    logger.LogInformation("User created a new account with password.");

                    var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await emailSender.SendEmailAsync(Input.Email, "Email megerősítés",
                        $"<p>Kedves {Input.FullName}!<br><br>" +
                        $"Köszönjük, hogy csatkakoztól az IRestaurant portálhoz.<br>" +
                        $"Az email címed megerősítéséhez kérlek <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>kattints ide.</a><br>" +
                        $"Ha bármi ptoblémát tapasztalsz nyugottan jelezd nekünk az irestaurant.net@gmail.com címen.<br><br>" +
                        $"Üdvözlettel,<br>" +
                        $"IRestaurant csapata</p>");

                    if (userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await signInManager.SignInAsync(user, isPersistent: false);
                        if (interactionService.IsValidReturnUrl(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        return LocalRedirect("~/Identity/Account/Manage");
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Page();
        }
    }
}
