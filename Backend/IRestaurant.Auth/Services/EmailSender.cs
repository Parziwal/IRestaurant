using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRestaurant.Auth.Services
{
    /// <summary>
    /// Az emailek küldéséért felelős osztály
    /// </summary>
    public class EmailSender : IEmailSender
    {
        private const string senderEmail = "irestaurant.net@gmail.com";
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        /// <summary>
        /// Az email kulcsot tartalmazzsa.
        /// </summary>
        public AuthMessageSenderOptions Options { get; }

        /// <summary>
        /// Az email elküldése a megadott email címre, a paraméterben szereplő tárgyal és szöveggel.
        /// </summary>
        /// <param name="email">A cél email címe.</param>
        /// <param name="subject">Az email tárgya.</param>
        /// <param name="message">Az email törzse.</param>
        /// <returns>Az email elküldése sikeres volt-e.</returns>       
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var client = new SendGridClient(Options.SendGridKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(senderEmail),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));

            msg.SetClickTracking(false, false);

            return client.SendEmailAsync(msg);
        }
    }
}
