using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRestaurant.Auth.Services
{
    /// <summary>
    /// Az Identity hiba üzeneteinek lokalizálása magyar nyelven.
    /// </summary>
    public class HungarianIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DefaultError() { return new IdentityError { Code = nameof(DefaultError), Description = $"Ismeretlen hiba történt" }; }
        public override IdentityError PasswordMismatch() { return new IdentityError { Code = nameof(PasswordMismatch), Description = "Nem megfelelő jelszó." }; }
        public override IdentityError InvalidEmail(string email) { return new IdentityError { Code = nameof(InvalidEmail), Description = $"Nem megfelelő email cím." }; }
        public override IdentityError DuplicateUserName(string userName) { return new IdentityError { Code = nameof(DuplicateUserName), Description = $"A felhasználónév/email cím már használatban van. Kérlek válasz egy másikat." }; }
        public override IdentityError DuplicateEmail(string email) { return new IdentityError { Code = nameof(DuplicateEmail), Description = $"A felhasználónév/email cím már használatban van. Kérlek válasz egy másikat." }; }
        public override IdentityError PasswordTooShort(int length) { return new IdentityError { Code = nameof(PasswordTooShort), Description = $"A jelszónak legalább {length} karakter hosszúnak kell lennie." }; }
        public override IdentityError PasswordRequiresNonAlphanumeric() { return new IdentityError { Code = nameof(PasswordRequiresNonAlphanumeric), Description = "A jelszónak tartalmaznia kell legalább egy nem alfanumerikus karaktert." }; }
        public override IdentityError PasswordRequiresDigit() { return new IdentityError { Code = nameof(PasswordRequiresDigit), Description = "A jelszónak tartalmaznia kell legalább egy számjegyet ('0'-'9')." }; }
        public override IdentityError PasswordRequiresLower() { return new IdentityError { Code = nameof(PasswordRequiresLower), Description = "A jelszónak tartalmaznia kell legalább egy kisbetűt ('a'-'z')." }; }
        public override IdentityError PasswordRequiresUpper() { return new IdentityError { Code = nameof(PasswordRequiresUpper), Description = "A jelszónak tartalmaznia kell legalább egy nagybetűt ('A'-'Z')." }; }
    }
}
