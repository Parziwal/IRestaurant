using IRestaurant.DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace IRestaurant.Test.Data
{
    public static class TestSeedService
    {
        public static IReadOnlyList<IdentityRole> Roles { get; } = new List<IdentityRole>()
        {
            new IdentityRole
            {
                Id = "rc95a82e-0abc-4d85-9877-4184177c3a7f",
                Name = "Restaurant",
                NormalizedName = "RESTAURANT",
                ConcurrencyStamp = "e388975f-eb14-4f40-ba09-159e4164b513",
            },
            new IdentityRole
            {
                Id = "g8aceb4d-b534-459e-8c4e-d13374f43b65",
                Name = "Guest",
                NormalizedName = "GUEST",
                ConcurrencyStamp = "24d76572-e1bb-4588-b442-b3907c67e05e",
            }
        };
        public static IReadOnlyList<ApplicationUser> Users { get; } = new List<ApplicationUser>() {
            //Vendégek
            new ApplicationUser
            {
                Id = "475c5e32-049c-4d7b-a963-02ebdc15a94b",
                FullName = "Carson Alexander",
                UserName = "carson@email.hu",
                NormalizedUserName = "CARSON@EMAIL.HU",
                Email = "carson@email.hu",
                NormalizedEmail = "CARSON@EMAIL.HU",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==",
                SecurityStamp = "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO",
                ConcurrencyStamp = "70ceb6e6-9a79-4fb8-b325-93453e2021b1"
            },
            new ApplicationUser
            {
                Id = "cb35b922-5a91-4949-94e6-47a2d6f82d93",
                FullName = "Bács Imre",
                UserName = "bacs.imre@email.hu",
                NormalizedUserName = "BACS.IMRE@EMAIL.HU",
                Email = "bacs.imre@email.hu",
                NormalizedEmail = "BACS.IMRE@EMAIL.HU",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==",
                SecurityStamp = "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO",
                ConcurrencyStamp = "70ceb6e6-9a79-4fb8-b325-93453e2021b1"
            },

            //Étterem tulajdonosok
            new ApplicationUser
            {
                Id = "512dac39-94d2-429a-a258-7740ca64c50f",
                FullName = "Peggy Justice",
                UserName = "peggy@email.hu",
                NormalizedUserName = "PEGGY@EMAIL.HU",
                Email = "peggy@email.hu",
                NormalizedEmail = "PEGGY@EMAIL.HU",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==",
                SecurityStamp = "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO",
                ConcurrencyStamp = "70ceb6e6-9a79-4fb8-b325-93453e2021b1"
            },
            new ApplicationUser
            {
                Id = "bc803e89-e8c0-4c5a-9467-e94cd5dd0300",
                FullName = "Csonka Krisztina",
                UserName = "csonka.krisztina@email.hu",
                NormalizedUserName = "CSONKA.KRISZTINA@EMAIL.HU",
                Email = "csonka.krisztina@email.hu",
                NormalizedEmail = "CSONKA.KRISZTINA@EMAIL.HU",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==",
                SecurityStamp = "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO",
                ConcurrencyStamp = "70ceb6e6-9a79-4fb8-b325-93453e2021b1"
            },
            new ApplicationUser
            {
                Id = "8480bf9e-9553-47b7-a57b-474715139a83",
                FullName = "Kiss Anikó",
                UserName = "kiss.aniko@email.hu",
                NormalizedUserName = "KISS.ANIKO@EMAIL.HU",
                Email = "kiss.aniko@email.hu",
                NormalizedEmail = "KISS.ANIKO@EMAIL.HU",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==",
                SecurityStamp = "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO",
                ConcurrencyStamp = "70ceb6e6-9a79-4fb8-b325-93453e2021b1"
            },
        };
        public static IReadOnlyList<IdentityUserRole<string>> UserRoles { get; } = new List<IdentityUserRole<string>>() {
            new IdentityUserRole<string>
            {
                UserId = "475c5e32-049c-4d7b-a963-02ebdc15a94b",
                RoleId = "g8aceb4d-b534-459e-8c4e-d13374f43b65"
            },
            new IdentityUserRole<string>
            {
                UserId = "cb35b922-5a91-4949-94e6-47a2d6f82d93",
                RoleId = "g8aceb4d-b534-459e-8c4e-d13374f43b65"
            },
            new IdentityUserRole<string>
            {
                UserId = "512dac39-94d2-429a-a258-7740ca64c50f",
                RoleId = "rc95a82e-0abc-4d85-9877-4184177c3a7f"
            },
            new IdentityUserRole<string>
            {
                UserId = "bc803e89-e8c0-4c5a-9467-e94cd5dd0300",
                RoleId = "rc95a82e-0abc-4d85-9877-4184177c3a7f"
            },
            new IdentityUserRole<string>
            {
                UserId = "8480bf9e-9553-47b7-a57b-474715139a83",
                RoleId = "rc95a82e-0abc-4d85-9877-4184177c3a7f"
            }
        };
        public static IReadOnlyList<Restaurant> Restaurants { get; } = new List<Restaurant>() {
            new Restaurant
            {
                Id = 1,
                Name = "Trófea Grill Étterem - Király",
                ShortDescription = "Olasz, Pizza, Hamburger, Amerikai, Magyaros",
                DetailedDescription = "KING'S BUFFET Kft. Fix áron fogyaszthat a több mint 100 féle ételt felvonultató svédasztalunkról és ihat finom borokat, pezsgőt, csapolt sört, szénsavas és rostos üdítőket, ásványvizet és kávét. Használja ki a svédasztalos rendszer előnyeit és válogasson saját ízlése szerint a különböző ínyencségek között! Bőséges kínálatunkban a hideg és meleg előételektől kezdve levesek és főételek sokaságán át a desszertekig számtalan fogás megtalálható. A hagyományos magyaros ételek kedvelői éppúgy megtalálják kedvenceiket, mint a reformkonyha hívei és a vegetáriánusok. A svédasztal részeként tizenkét különböző pácban friss nyers húsok és zöldségek találhatók, amelyeket szakácsaink az Ön választása alapján látványkonyhánkban készítenek el. Kellemes hangulatban rendezhetik meg családi, baráti és céges összejöveteleiket vagy tölthetnek el egy egyszerű hétköznapi ebédet is. Várjuk Önöket szeretettel!",
                ShowForUsers = true,
                IsOrderAvailable = true,
                OwnerId = "512dac39-94d2-429a-a258-7740ca64c50f",
                ImagePath = "/images/restaurant/trofea.jpg",
                Address = new AddressOwned
                {
                    City = "Budapest",
                    ZipCode = 1061,
                    Street = "Király utca 30",
                    PhoneNumber = "06-30-123-4567"
                }
            },
            new Restaurant
            {
                Id = 2,
                Name = "Twentysix Budapest",
                ShortDescription = "Mediterrán, Olasz , Nemzetközi, Közép Keleti, Terasz és kert",
                DetailedDescription = "A Twentysix Budapest egy hatalmas ősoázis tele növénnyel a belváros szívében, egy nagyon zöld, botanikus, tér, ahol a gasztronómia, a természet és a felelős vendéglátás filozófiája találkozik és kel életre a különböző terekben: GARDEN° – mediterrán étterem, SHOP° – no waste kávézó és csomagolásmentes delikátesz bolt, STUDIO° – jógastúdió és HOUSE° – lakásstúdió és rendezvényterem. Budapest legzöldebb kertje, ahol nincsenek évszakok, csak az igazi, mediterrán nyár, az év minden napján. Egy hely, ahol a természet, a gasztronómia és a tudatos lét találkozik.",
                ShowForUsers = true,
                IsOrderAvailable = true,
                OwnerId = "bc803e89-e8c0-4c5a-9467-e94cd5dd0300",
                ImagePath = "/images/restaurant/twentysix.jpg",
                Address = new AddressOwned
                {
                    City = "Budapest",
                    ZipCode = 1148,
                    Street = "Örs vezér tere 1",
                    PhoneNumber = "06-30-541-2567"
                }
            },
            new Restaurant
            {
                Id = 3,
                Name = "Csokonai Étterem",
                ShortDescription = "Terasz és kert, Privát helyiség, Gyermekbarát, Elvitel",
                DetailedDescription = "A söröző-étterem a Csokonai Színházzal szemben található, klimatizált pincehelyiség, ahol különböző méretű és hangulatú termek állnak rendelkezésre csoportok fogadsára, rendezvények lebonyolítására. Elkülönített, nemdohányzó helyiség is szolgálja a vendégek kényelmét. Az ételválasztékban nemzetközi, és hagyományos magyaros ételspecialitások gazdag kínálatát vonultatja fel az étterem. ",
                ShowForUsers = true,
                IsOrderAvailable = true,
                OwnerId = "8480bf9e-9553-47b7-a57b-474715139a83",
                ImagePath = "/images/restaurant/csokonai.jpg",
                Address = new AddressOwned
                {
                    City = "Debrecen",
                    ZipCode = 4025,
                    Street = "Kossuth utca 21",
                    PhoneNumber = "06-20-343-3499"
                }
            }
        };
        public static IReadOnlyList<Review> Reviews { get; } = new List<Review>() {
            new Review
            {
                Id = 1,
                UserId = "475c5e32-049c-4d7b-a963-02ebdc15a94b",
                RestaurantId = 1,
                Rating = 4.867,
                CreatedAt = new DateTime(2021, 10, 10, 10, 1, 1),
                Title = "Nagyon ajánlom",
                Description = "Ízletes fogások, kiváló kiszolgálás."
            },
            new Review
            {
                Id = 2,
                UserId = "cb35b922-5a91-4949-94e6-47a2d6f82d93",
                RestaurantId = 1,
                Rating = 4.677,
                CreatedAt = new DateTime(2021, 9, 10, 10, 1, 1),
                Title = "Közel remek hely",
                Description = "Remek hely, de a pincérek egy kicsit túl voltak terhelve, a hétköznap délutáni teltház persze nem segített a helyzeten."
            },
            new Review
            {
                Id = 3,
                UserId = "475c5e32-049c-4d7b-a963-02ebdc15a94b",
                RestaurantId = 2,
                Rating = 3.2,
                CreatedAt = new DateTime(2021, 9, 10, 10, 1, 1),
                Title = "Egyszer elég volt",
                Description = "Nem voltam megelégedve a kiszolgálásal."
            },
        };
        public static IReadOnlyList<FavouriteRestaurant> FavouriteRestaurants { get; } = new List<FavouriteRestaurant>() {
            new FavouriteRestaurant
            {
                Id = 1,
                UserId = "475c5e32-049c-4d7b-a963-02ebdc15a94b",
                RestaurantId = 1
            },
            new FavouriteRestaurant
            {
                Id = 2,
                UserId = "475c5e32-049c-4d7b-a963-02ebdc15a94b",
                RestaurantId = 2
            }
        };
    }
}
