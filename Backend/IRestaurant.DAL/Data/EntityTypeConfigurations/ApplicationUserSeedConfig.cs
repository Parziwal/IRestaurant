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
    public class ApplicationUserSeedConfig : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(
                //Vendég
                new ApplicationUser {
                    Id = "475c5e32-049c-4d7b-a963-02ebdc15a94b",
                    FullName = "Carson Alexander",
                    UserName = "carson@email.hu",
                    NormalizedUserName = "CARSON@EMAIL.HU",
                    Email = "carson@email.hu",
                    NormalizedEmail = "CARSON@EMAIL.HU",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==", //== Test.54321
                    SecurityStamp = "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO",
                    ConcurrencyStamp = "70ceb6e6-9a79-4fb8-b325-93453e2021b1"
                },

                //Étterem tulajdonos
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

                //Vendégek
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
                new ApplicationUser
                {
                    Id = "0bf93af4-1769-49f8-9bf4-e977feef94b4",
                    FullName = "Fábián Barna",
                    UserName = "fabian.barna@email.hu",
                    NormalizedUserName = "FABIAN.BARNA@EMAIL.HU",
                    Email = "fabian.barna@email.hu",
                    NormalizedEmail = "FABIAN.BARNA@EMAIL.HU",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==",
                    SecurityStamp = "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO",
                    ConcurrencyStamp = "70ceb6e6-9a79-4fb8-b325-93453e2021b1"
                },
                new ApplicationUser
                {
                    Id = "6c364ea9-44b4-4726-9bef-ea83c375e761",
                    FullName = "Balázs Olivér",
                    UserName = "balazs.oliver@email.hu",
                    NormalizedUserName = "BALAZS.OLIVER@EMAIL.HU",
                    Email = "balazs.oliver@email.hu",
                    NormalizedEmail = "BALAZS.OLIVER@EMAIL.HU",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==",
                    SecurityStamp = "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO",
                    ConcurrencyStamp = "70ceb6e6-9a79-4fb8-b325-93453e2021b1"
                },
                new ApplicationUser
                {
                    Id = "fef0a15c-42bb-4f2d-9a65-382d4d95f667",
                    FullName = "Orsós József",
                    UserName = "orsos.jozsef@email.hu",
                    NormalizedUserName = "ORSOS.JOZSEF@EMAIL.HU",
                    Email = "orsos.jozsef@email.hu",
                    NormalizedEmail = "ORSOS.JOZSEF@EMAIL.HU",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==",
                    SecurityStamp = "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO",
                    ConcurrencyStamp = "70ceb6e6-9a79-4fb8-b325-93453e2021b1"
                },

                //Étterem tulajdonosok
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
                new ApplicationUser
                {
                    Id = "95810441-4970-488c-afc7-d91a07256c76",
                    FullName = "Péter Nikoletta",
                    UserName = "peter.nikoletta@email.hu",
                    NormalizedUserName = "PETER.NIKOLETTA@EMAIL.HU",
                    Email = "peter.nikoletta@email.hu",
                    NormalizedEmail = "PETER.NIKOLETTA@EMAIL.HU",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==",
                    SecurityStamp = "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO",
                    ConcurrencyStamp = "70ceb6e6-9a79-4fb8-b325-93453e2021b1"
                },
                new ApplicationUser
                {
                    Id = "c5e189f0-7656-4304-b963-1581f5ecf4fb",
                    FullName = "Szabó Bianka",
                    UserName = "szabo.bianka@email.hu",
                    NormalizedUserName = "SZABO.BIANKA@EMAIL.HU",
                    Email = "szabo.bianka@email.hu",
                    NormalizedEmail = "SZABO.BIANKA@EMAIL.HU",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==",
                    SecurityStamp = "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO",
                    ConcurrencyStamp = "70ceb6e6-9a79-4fb8-b325-93453e2021b1"
                },
                new ApplicationUser
                {
                    Id = "3eba4364-6a33-459c-9871-5823a9aee62a",
                    FullName = "Horváth Katalin",
                    UserName = "horvath.katalin@email.hu",
                    NormalizedUserName = "HORVATH.KATALIN@EMAIL.HU",
                    Email = "horvath.katalin@email.hu",
                    NormalizedEmail = "HORVATH.KATALIN@EMAIL.HU",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==",
                    SecurityStamp = "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO",
                    ConcurrencyStamp = "70ceb6e6-9a79-4fb8-b325-93453e2021b1"
                },
                new ApplicationUser
                {
                    Id = "765c13fb-7f8c-4474-afb5-d3a9e72feef3",
                    FullName = "Gáspár Izabella",
                    UserName = "gaspar.izabella@email.hu",
                    NormalizedUserName = "GASPAR.IZABELLA@EMAIL.HU",
                    Email = "gaspar.izabella@email.hu",
                    NormalizedEmail = "GASPAR.IZABELLA@EMAIL.HU",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==",
                    SecurityStamp = "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO",
                    ConcurrencyStamp = "70ceb6e6-9a79-4fb8-b325-93453e2021b1"
                },
                new ApplicationUser
                {
                    Id = "7236dae3-7bad-4fe6-bb18-d13ff391939d",
                    FullName = "Budai Cintia",
                    UserName = "budai.cintia@email.hu",
                    NormalizedUserName = "BUDAI.CINTIA@EMAIL.HU",
                    Email = "budai.cintia@email.hu",
                    NormalizedEmail = "BUDAI.CINTIA@EMAIL.HU",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==",
                    SecurityStamp = "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO",
                    ConcurrencyStamp = "70ceb6e6-9a79-4fb8-b325-93453e2021b1"
                },
                new ApplicationUser
                {
                    Id = "5075d4b9-0ba6-4811-84ff-fed147c9c09a",
                    FullName = "Szőke Barbara",
                    UserName = "szoke.barbara@email.hu",
                    NormalizedUserName = "SZOKE.BARBARA@EMAIL.HU",
                    Email = "szoke.barbara@email.hu",
                    NormalizedEmail = "SZOKE.BARBARA@EMAIL.HU",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==",
                    SecurityStamp = "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO",
                    ConcurrencyStamp = "70ceb6e6-9a79-4fb8-b325-93453e2021b1"
                },
                new ApplicationUser
                {
                    Id = "e1eaafad-b9f7-4668-9efd-d8c4418c39ca",
                    FullName = "Orsós Nóra",
                    UserName = "orsos.nora@email.hu",
                    NormalizedUserName = "ORSOS.NORA@EMAIL.HU",
                    Email = "orsos.nora@email.hu",
                    NormalizedEmail = "ORSOS.NORA@EMAIL.HU",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==",
                    SecurityStamp = "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO",
                    ConcurrencyStamp = "70ceb6e6-9a79-4fb8-b325-93453e2021b1"
                },
                new ApplicationUser
                {
                    Id = "5f7e27c3-9398-4cd3-977d-dae625124808",
                    FullName = "Török Mónika",
                    UserName = "torok.monika@email.hu",
                    NormalizedUserName = "TOROK.MONIKA@EMAIL.HU",
                    Email = "torok.monika@email.hu",
                    NormalizedEmail = "TOROK.MONIKA@EMAIL.HU",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==",
                    SecurityStamp = "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO",
                    ConcurrencyStamp = "70ceb6e6-9a79-4fb8-b325-93453e2021b1"
                },
                new ApplicationUser
                {
                    Id = "93f49281-b3a5-41b5-972c-ff5910f26e56",
                    FullName = "Fazekas Barnabás",
                    UserName = "fazekas.barnabas@email.hu",
                    NormalizedUserName = "FAZEKAS.BARNABAS@EMAIL.HU",
                    Email = "fazekas.barnabas@email.hu",
                    NormalizedEmail = "FAZEKAS.BARNABAS@EMAIL.HU",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==",
                    SecurityStamp = "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO",
                    ConcurrencyStamp = "70ceb6e6-9a79-4fb8-b325-93453e2021b1"
                },
                new ApplicationUser
                {
                    Id = "4e0a018f-ca12-448e-bda9-67ac1fce5a53",
                    FullName = "Bodnár Erik",
                    UserName = "bodnar.erik@email.hu",
                    NormalizedUserName = "BODNAR.ERIK@EMAIL.HU",
                    Email = "bodnar.erik@email.hu",
                    NormalizedEmail = "BODNAR.ERIK@EMAIL.HU",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==",
                    SecurityStamp = "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO",
                    ConcurrencyStamp = "70ceb6e6-9a79-4fb8-b325-93453e2021b1"
                },
                new ApplicationUser
                {
                    Id = "77d8c466-d2a0-44cb-8a22-a228b6218f23",
                    FullName = "Vászoly Jakab",
                    UserName = "vaszoly.jakab@email.hu",
                    NormalizedUserName = "VASZOLY.JAKAB@EMAIL.HU",
                    Email = "vaszoly.jakab@email.hu",
                    NormalizedEmail = "VASZOLY.JAKAB@EMAIL.HU",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==",
                    SecurityStamp = "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO",
                    ConcurrencyStamp = "70ceb6e6-9a79-4fb8-b325-93453e2021b1"
                },
                new ApplicationUser
                {
                    Id = "5b944a67-5751-423f-89fb-f0c4f0ace3fb",
                    FullName = "Hajdú Ádám",
                    UserName = "hajdu.adam@email.hu",
                    NormalizedUserName = "HAJDU.ADAM@EMAIL.HU",
                    Email = "hajdu.adam@email.hu",
                    NormalizedEmail = "HAJDU.ADAM@EMAIL.HU",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==",
                    SecurityStamp = "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO",
                    ConcurrencyStamp = "70ceb6e6-9a79-4fb8-b325-93453e2021b1"
                },
                new ApplicationUser
                {
                    Id = "96494a5b-f58d-44dd-8428-6543ef5e5bd7",
                    FullName = "Balog Rajmund",
                    UserName = "balog.rajmund@email.hu",
                    NormalizedUserName = "BALOG.RAJMUND@EMAIL.HU",
                    Email = "balog.rajmund@email.hu",
                    NormalizedEmail = "BALOG.RAJMUND@EMAIL.HU",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==",
                    SecurityStamp = "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO",
                    ConcurrencyStamp = "70ceb6e6-9a79-4fb8-b325-93453e2021b1"
                },
                new ApplicationUser
                {
                    Id = "5c55f164-cb41-4453-a473-120af44e3493",
                    FullName = "Pintér Kornél",
                    UserName = "pinter.kornel@email.hu",
                    NormalizedUserName = "PINTER.KORNEL@EMAIL.HU",
                    Email = "pinter.kornel@email.hu",
                    NormalizedEmail = "PINTER.KORNEL@EMAIL.HU",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==",
                    SecurityStamp = "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO",
                    ConcurrencyStamp = "70ceb6e6-9a79-4fb8-b325-93453e2021b1"
                },
                new ApplicationUser
                {
                    Id = "27410ef4-fa83-45cd-872d-d350042dd8e4",
                    FullName = "Király Rudolf",
                    UserName = "kiraly.rudolf@email.hu",
                    NormalizedUserName = "KIRALY.RUDOLF@EMAIL.HU",
                    Email = "kiraly.rudolf@email.hu",
                    NormalizedEmail = "KIRALY.RUDOLF@EMAIL.HU",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==",
                    SecurityStamp = "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO",
                    ConcurrencyStamp = "70ceb6e6-9a79-4fb8-b325-93453e2021b1"
                },
                new ApplicationUser
                {
                    Id = "acd5d503-90e3-475c-b700-8e96fbea9e60",
                    FullName = "Fodor Szabolcs",
                    UserName = "fodor.szabolcs@email.hu",
                    NormalizedUserName = "FODOR.SZABOLCS@EMAIL.HU",
                    Email = "fodor.szabolcs@email.hu",
                    NormalizedEmail = "FODOR.SZABOLCS@EMAIL.HU",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==",
                    SecurityStamp = "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO",
                    ConcurrencyStamp = "70ceb6e6-9a79-4fb8-b325-93453e2021b1"
                },
                new ApplicationUser
                {
                    Id = "4422d2ba-934c-4899-9195-d9872d1b4c63",
                    FullName = "Németh Vince",
                    UserName = "nemeth.vince@email.hu",
                    NormalizedUserName = "NEMETH.VINCE@EMAIL.HU",
                    Email = "nemeth.vince@email.hu",
                    NormalizedEmail = "NEMETH.VINCE@EMAIL.HU",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==",
                    SecurityStamp = "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO",
                    ConcurrencyStamp = "70ceb6e6-9a79-4fb8-b325-93453e2021b1"
                }
            );
        }
    }
}
