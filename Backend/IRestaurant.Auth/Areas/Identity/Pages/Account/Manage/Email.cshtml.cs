using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using System.Linq;
using System.Threading.Tasks;
using IRestaurant.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;

namespace IRestaurant.Auth.Areas.Identity.Pages.Account.Manage
{
    public partial class EmailModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;

        public EmailModel(
            UserManager<ApplicationUser> userManager,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
        }

        public string Username { get; set; }

        public string Email { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Az email cím megadása kötelező.")]
            [EmailAddress(ErrorMessage = "Az email cím nem érvényes.")]
            [Display(Name = "Új email")]
            public string NewEmail { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var email = await _userManager.GetEmailAsync(user);
            Email = email;

            Input = new InputModel
            {
                NewEmail = email,
            };

            IsEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound("A felhasználó betöltése nem sikerült.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostChangeEmailAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound("A felhasználó betöltése nem sikerült.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var email = await _userManager.GetEmailAsync(user);

            var userNameExists = await _userManager.FindByNameAsync(Input.NewEmail);
            if (userNameExists != null)
            {
                StatusMessage = "Az felhasználónév/email már használatban van. Kérlek válasz egy másikat.";
                return RedirectToPage();
            }

            if (Input.NewEmail != email)
            {
                var userId = await _userManager.GetUserIdAsync(user);
                var code = await _userManager.GenerateChangeEmailTokenAsync(user, Input.NewEmail);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = Url.Page(
                    "/Account/ConfirmEmailChange",
                    pageHandler: null,
                    values: new { userId = userId, email = Input.NewEmail, code = code },
                    protocol: Request.Scheme);
                await _emailSender.SendEmailAsync(
                    Input.NewEmail,
                    "Email megerősítése",
                    $"<p>Kedves {user.FullName}!<br><br>" +
                    $"Az email címed megerősítéséhez kérlek <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>kattints ide.</a><br><br>" +
                    $"Üdvözlettel,<br>" +
                    $"IRestaurant csapata</p>");

                StatusMessage = "Az új email megerősítéséhez szükséges linket elküldtük. Kérlek ellenőrizd az emailjeidet.";
                return RedirectToPage();
            }

            StatusMessage = "Az email címed nem változott.";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSendVerificationEmailAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound("A felhasználó betöltése nem sikerült.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var userId = await _userManager.GetUserIdAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { area = "Identity", userId = userId, code = code },
                protocol: Request.Scheme);
            await _emailSender.SendEmailAsync(
                email,
                "Email megerősítése",
                $"Kedves {user.FullName},\n\n" +
                $"Az email címed megerősítéséhez kérlek <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>kattints ide.</a>\n\n" +
                $"Üdvözlettel,\n" +
                $"IRestaurant csapata");

            StatusMessage = "A megerősítő email elküldésre került. Kérjük, ellenőrizze az e-mailjeit.";
            return RedirectToPage();
        }
    }
}
