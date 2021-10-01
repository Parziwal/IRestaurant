﻿using System;
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
using IRestaurant.BL.Managers;
using IRestaurant.DAL.Data;
using IdentityServer4.Services;

namespace IRestaurant.Auth.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> applicationUserManager;
        private readonly ILogger<RegisterModel> logger;
        private readonly IEmailSender emailSender;
        private readonly UserManager userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IIdentityServerInteractionService interactionService;

        public RegisterModel(
            UserManager<ApplicationUser> applicationUserManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            UserManager userManager,
            RoleManager<IdentityRole> roleManager,
            IIdentityServerInteractionService interactionService)
        {
            this.applicationUserManager = applicationUserManager;
            this.signInManager = signInManager;
            this.logger = logger;
            this.emailSender = emailSender;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.interactionService = interactionService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            public string Role { get; set; }
            [Required]
            [StringLength(50)]
            [Display(Name = "Vezeték és keresztnév")]
            public string FullName { get; set; }
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "A {0}nak legalább {2} és maximum {1} karakter hosszúnak kell lennie.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Jelszó")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Jelszó megerősítése")]
            [Compare("Password", ErrorMessage = "A jelszók nem egyeznek meg.")]
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
                var result = await applicationUserManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    if (!await roleManager.RoleExistsAsync(Input.Role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(Input.Role));
                    }

                    await applicationUserManager.AddToRoleAsync(user, Input.Role);
                    if (Input.Role == UserRoles.Restaurant)
                    {
                        try
                        {
                            await userManager.CreateDefaultRestaurantForCurrentUser();
                        }
                        catch (Exception)
                        {
                            await applicationUserManager.DeleteAsync(user);
                            ModelState.AddModelError("Error", "Hiba történt a regisztráció során, kérlem próbálja újra.");
                            return Page();
                        }
                    }

                    logger.LogInformation("User created a new account with password.");

                    var code = await applicationUserManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (applicationUserManager.Options.SignIn.RequireConfirmedAccount)
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

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}