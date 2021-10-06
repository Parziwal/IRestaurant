using IRestaurant.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.Data.EntityTypeConfigurations
{
    public class ReviewSeedConfig : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasData(
                new Review
                {
                    Id = 1,
                    UserId = "475c5e32-049c-4d7b-a963-02ebdc15a94b",
                    RestaurantId = 1,
                    Rating = 5.0,
                    CreatedAt = DateTime.Now.AddDays(-60),
                    Title = "Nagyon ajánlom",
                    Description = "Ízletes fogások, kiváló kiszolgálás."
                },
                new Review
                {
                    Id = 2,
                    UserId = "cb35b922-5a91-4949-94e6-47a2d6f82d93",
                    RestaurantId = 1,
                    Rating = 4.5,
                    CreatedAt = DateTime.Now.AddDays(-30),
                    Title = "Remek hely",
                    Description = "Remek hely, de a pincérek egy kicsit túl voltak terhelve, a hétköznap délutáni teltház persze nem segített a helyzeten. Tavasszal a lezárások alatt egy vendégre 3 felszolgáló jutott, az jobban tetszett. :D."
                },
                new Review
                {
                    Id = 3,
                    UserId = "475c5e32-049c-4d7b-a963-02ebdc15a94b",
                    RestaurantId = 2,
                    Rating = 4.2,
                    CreatedAt = DateTime.Now.AddDays(-30),
                    Title = "Kellemes hely",
                    Description = "Kellemes hely. Olyan hely, ahol a legjobb ételek és borok mellett önfeledten beszélgethetsz barátaiddal . Az alaphangszint (vagy inkább zaj) kicsit szokatlan lehet, de viszonylag könnyen hozzá lehet szokni. A felszolgálás ugyanolyan fesztelen, mint maga a hely. "
                },
                new Review
                {
                    Id = 4,
                    UserId = "cb35b922-5a91-4949-94e6-47a2d6f82d93",
                    RestaurantId = 2,
                    Rating = 4.5,
                    CreatedAt = DateTime.Now.AddDays(-30),
                    Title = "Remek hely",
                    Description = "Remek hely, de a pincérek egy kicsit túl voltak terhelve, a hétköznap délutáni teltház persze nem segített a helyzeten. Tavasszal a lezárások alatt egy vendégre 3 felszolgáló jutott, az jobban tetszett. :D."
                },
                new Review
                {
                    Id = 5,
                    UserId = "475c5e32-049c-4d7b-a963-02ebdc15a94b",
                    RestaurantId = 3,
                    Rating = 4.7,
                    CreatedAt = DateTime.Now.AddDays(-50),
                    Title = "Több mint étkezés",
                    Description = "Itt az étkezés nem kizárólag étkezés, sokkal inkább egy különleges szertartás. A kiszolgálás másodpercre pontosan kiszámolt, mérnöki pontosságú."
                },
                new Review
                {
                    Id = 6,
                    UserId = "cb35b922-5a91-4949-94e6-47a2d6f82d93",
                    RestaurantId = 3,
                    Rating = 4.2,
                    CreatedAt = DateTime.Now.AddDays(-30),
                    Title = "Remek hely",
                    Description = "Remek hely, de a pincérek egy kicsit túl voltak terhelve, a hétköznap délutáni teltház persze nem segített a helyzeten. Tavasszal a lezárások alatt egy vendégre 3 felszolgáló jutott, az jobban tetszett. :D."
                },
                new Review
                {
                    Id = 7,
                    UserId = "475c5e32-049c-4d7b-a963-02ebdc15a94b",
                    RestaurantId = 10,
                    Rating = 4.5,
                    CreatedAt = DateTime.Now.AddDays(-20),
                    Title = "Kiváló ár-érték arány",
                    Description = "Összességében azt mondhatom, igazán remek, kiváló ár - érték arányú ebédet hoztak össze.Szívesen jövünk még újabb finomságokat kóstolni."
                },
                new Review
                {
                    Id = 8,
                    UserId = "cb35b922-5a91-4949-94e6-47a2d6f82d93",
                    RestaurantId = 10,
                    Rating = 4.1,
                    CreatedAt = DateTime.Now.AddDays(-30),
                    Title = "Remek hely",
                    Description = "Remek hely, de a pincérek egy kicsit túl voltak terhelve, a hétköznap délutáni teltház persze nem segített a helyzeten. Tavasszal a lezárások alatt egy vendégre 3 felszolgáló jutott, az jobban tetszett. :D."
                },
                new Review
                {
                    Id = 9,
                    UserId = "cb35b922-5a91-4949-94e6-47a2d6f82d93",
                    RestaurantId = 11,
                    Rating = 4.0,
                    CreatedAt = DateTime.Now.AddDays(-20),
                    Title = "Kiváló ár-érték arány",
                    Description = "Összességében azt mondhatom, igazán remek, kiváló ár - érték arányú ebédet hoztak össze.Szívesen jövünk még újabb finomságokat kóstolni."
                },
                new Review
                {
                    Id = 10,
                    UserId = "cb35b922-5a91-4949-94e6-47a2d6f82d93",
                    RestaurantId = 12,
                    Rating = 3.9,
                    CreatedAt = DateTime.Now.AddDays(-20),
                    Title = "Kiváló ár-érték arány",
                    Description = "Összességében azt mondhatom, igazán remek, kiváló ár - érték arányú ebédet hoztak össze.Szívesen jövünk még újabb finomságokat kóstolni."
                },
                new Review
                {
                    Id = 11,
                    UserId = "cb35b922-5a91-4949-94e6-47a2d6f82d93",
                    RestaurantId = 13,
                    Rating = 4.1,
                    CreatedAt = DateTime.Now.AddDays(-20),
                    Title = "Kiváló ár-érték arány",
                    Description = "Összességében azt mondhatom, igazán remek, kiváló ár - érték arányú ebédet hoztak össze.Szívesen jövünk még újabb finomságokat kóstolni."
                },
                new Review
                {
                    Id = 12,
                    UserId = "cb35b922-5a91-4949-94e6-47a2d6f82d93",
                    RestaurantId = 15,
                    Rating = 3.8,
                    CreatedAt = DateTime.Now.AddDays(-20),
                    Title = "Kiváló ár-érték arány",
                    Description = "Összességében azt mondhatom, igazán remek, kiváló ár - érték arányú ebédet hoztak össze.Szívesen jövünk még újabb finomságokat kóstolni."
                },
                new Review
                {
                    Id = 13,
                    UserId = "cb35b922-5a91-4949-94e6-47a2d6f82d93",
                    RestaurantId = 20,
                    Rating = 1.9,
                    CreatedAt = DateTime.Now.AddDays(-10),
                    Title = "Nem ajánlom",
                    Description = "Megérkezdtünk. Nem kisértek az asztalunkhoz, azt mondták, üljünk ahová akarunk. Majd 10 percen keresztül a kutya sem szòlt hozzánk. Akkor megkérdeztük, hogy mikor veszik fel legalább az italrendelést, azt mondták rögtön. Újabb 5 perc után, mivel senki sem jött az asztalunkhoz, távoztunk. Senki nem kérdezte meg, hogy miért megyünk el. Az étlap, amit más asztalokon láttunk, gyürött ès koszos volt. A pincèrnö ruhàja àpolatlan. Senkinek nem ajànlom a helyet.",
                },

                new Review
                {
                    Id = 14,
                    UserId = "0bf93af4-1769-49f8-9bf4-e977feef94b4",
                    RestaurantId = 8,
                    Rating = 3.7,
                    CreatedAt = DateTime.Now.AddDays(-20),
                    Title = "Ízléses, de kis adagok",
                    Description = "Egy friss, fiatalos, üde étterem, ez a szemlélet, lendület visszaköszön ételeiken is. Akár déli, akár esti ajánlatra térsz be, nem fogsz csalódni; remek ár-érték arányú hely. Viszont ha jól szeretnél lakni, nem ez a számodra megfelelő hely. Az ételek bár ízletesek, az adagok kicsik. ."
                },
                new Review
                {
                    Id = 15,
                    UserId = "0bf93af4-1769-49f8-9bf4-e977feef94b4",
                    RestaurantId = 9,
                    Rating = 3.5,
                    CreatedAt = DateTime.Now.AddDays(-20),
                    Title = "Ízléses, de kis adagok",
                    Description = "Egy friss, fiatalos, üde étterem, ez a szemlélet, lendület visszaköszön ételeiken is. Akár déli, akár esti ajánlatra térsz be, nem fogsz csalódni; remek ár-érték arányú hely. Viszont ha jól szeretnél lakni, nem ez a számodra megfelelő hely. Az ételek bár ízletesek, az adagok kicsik. ."
                },
                new Review
                {
                    Id = 16,
                    UserId = "0bf93af4-1769-49f8-9bf4-e977feef94b4",
                    RestaurantId = 16,
                    Rating = 3.6,
                    CreatedAt = DateTime.Now.AddDays(-20),
                    Title = "Ízléses, de kis adagok",
                    Description = "Egy friss, fiatalos, üde étterem, ez a szemlélet, lendület visszaköszön ételeiken is. Akár déli, akár esti ajánlatra térsz be, nem fogsz csalódni; remek ár-érték arányú hely. Viszont ha jól szeretnél lakni, nem ez a számodra megfelelő hely. Az ételek bár ízletesek, az adagok kicsik. ."
                },
                new Review
                {
                    Id = 17,
                    UserId = "0bf93af4-1769-49f8-9bf4-e977feef94b4",
                    RestaurantId = 17,
                    Rating = 3.4,
                    CreatedAt = DateTime.Now.AddDays(-20),
                    Title = "Ízléses, de kis adagok",
                    Description = "Egy friss, fiatalos, üde étterem, ez a szemlélet, lendület visszaköszön ételeiken is. Akár déli, akár esti ajánlatra térsz be, nem fogsz csalódni; remek ár-érték arányú hely. Viszont ha jól szeretnél lakni, nem ez a számodra megfelelő hely. Az ételek bár ízletesek, az adagok kicsik. ."
                },

                new Review
                {
                    Id = 18,
                    UserId = "6c364ea9-44b4-4726-9bef-ea83c375e761",
                    RestaurantId = 4,
                    Rating = 4.1,
                    CreatedAt = DateTime.Now.AddDays(-20),
                    Title = "Átlagon felüli, de nem hibátlan",
                    Description = "Bár az előétel és a desszert remek volt, a többi fogás nem varázsolt el. Kicsit olyan érzésem volt, hogy ennek az étteremnek nagyobb a füstje, mint a lángja. Átlagon felüli, de nem hibátlan. Többet vártam."
                },
                new Review
                {
                    Id = 19,
                    UserId = "6c364ea9-44b4-4726-9bef-ea83c375e761",
                    RestaurantId = 5,
                    Rating = 4.0,
                    CreatedAt = DateTime.Now.AddDays(-20),
                    Title = "Átlagon felüli, de nem hibátlan",
                    Description = "Bár az előétel és a desszert remek volt, a többi fogás nem varázsolt el. Kicsit olyan érzésem volt, hogy ennek az étteremnek nagyobb a füstje, mint a lángja. Átlagon felüli, de nem hibátlan. Többet vártam."
                },
                new Review
                {
                    Id = 20,
                    UserId = "6c364ea9-44b4-4726-9bef-ea83c375e761",
                    RestaurantId = 14,
                    Rating = 3.9,
                    CreatedAt = DateTime.Now.AddDays(-20),
                    Title = "Átlagon felüli, de nem hibátlan",
                    Description = "Bár az előétel és a desszert remek volt, a többi fogás nem varázsolt el. Kicsit olyan érzésem volt, hogy ennek az étteremnek nagyobb a füstje, mint a lángja. Átlagon felüli, de nem hibátlan. Többet vártam."
                },
                new Review
                {
                    Id = 21,
                    UserId = "6c364ea9-44b4-4726-9bef-ea83c375e761",
                    RestaurantId = 18,
                    Rating = 3.8,
                    CreatedAt = DateTime.Now.AddDays(-20),
                    Title = "Átlagon felüli, de nem hibátlan",
                    Description = "Bár az előétel és a desszert remek volt, a többi fogás nem varázsolt el. Kicsit olyan érzésem volt, hogy ennek az étteremnek nagyobb a füstje, mint a lángja. Átlagon felüli, de nem hibátlan. Többet vártam."
                },
                new Review
                {
                    Id = 22,
                    UserId = "6c364ea9-44b4-4726-9bef-ea83c375e761",
                    RestaurantId = 19,
                    Rating = 2.0,
                    CreatedAt = DateTime.Now.AddDays(-60),
                    Title = "Nem ajánlom",
                    Description = "Megérkezdtünk. Nem kisértek az asztalunkhoz, azt mondták, üljünk ahová akarunk. Majd 10 percen keresztül a kutya sem szòlt hozzánk. Akkor megkérdeztük, hogy mikor veszik fel legalább az italrendelést, azt mondták rögtön. Újabb 5 perc után, mivel senki sem jött az asztalunkhoz, távoztunk. Senki nem kérdezte meg, hogy miért megyünk el. Az étlap, amit más asztalokon láttunk, gyürött ès koszos volt. A pincèrnö ruhàja àpolatlan. Senkinek nem ajànlom a helyet. "
                },

                new Review
                {
                    Id = 23,
                    UserId = "fef0a15c-42bb-4f2d-9a65-382d4d95f667",
                    RestaurantId = 6,
                    Rating = 4.2,
                    CreatedAt = DateTime.Now.AddDays(-40),
                    Title = "Kifinomult, harmonikus ételek",
                    Description = "Érdemes megkóstolni a különböző finomságokat, igazán jó konyhát visznek. Az ételeik kifinomultak, harmonikusak, mondjuk nem az a hely, ahol tele fogod enni magad - de nem is ez a cél."
                },
                new Review
                {
                    Id = 24,
                    UserId = "fef0a15c-42bb-4f2d-9a65-382d4d95f667",
                    RestaurantId = 7,
                    Rating = 4.3,
                    CreatedAt = DateTime.Now.AddDays(-40),
                    Title = "Kifinomult, harmonikus ételek",
                    Description = "Érdemes megkóstolni a különböző finomságokat, igazán jó konyhát visznek. Az ételeik kifinomultak, harmonikusak, mondjuk nem az a hely, ahol tele fogod enni magad - de nem is ez a cél."
                }
            );
        }
    }
}
