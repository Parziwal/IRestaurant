using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IRestaurant.DAL.Migrations
{
    public partial class SeedConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "g8aceb4d-b534-459e-8c4e-d13374f43b65", "24d76572-e1bb-4588-b442-b3907c67e05e", "Guest", "GUEST" },
                    { "rc95a82e-0abc-4d85-9877-4184177c3a7f", "e388975f-eb14-4f40-ba09-159e4164b513", "Restaurant", "RESTAURANT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "4422d2ba-934c-4899-9195-d9872d1b4c63", 0, "70ceb6e6-9a79-4fb8-b325-93453e2021b1", "nemeth.vince@email.hu", true, "Németh Vince", false, null, "NEMETH.VINCE@EMAIL.HU", "NEMETH.VINCE@EMAIL.HU", "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==", null, false, "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO", false, "nemeth.vince@email.hu" },
                    { "acd5d503-90e3-475c-b700-8e96fbea9e60", 0, "70ceb6e6-9a79-4fb8-b325-93453e2021b1", "fodor.szabolcs@email.hu", true, "Fodor Szabolcs", false, null, "FODOR.SZABOLCS@EMAIL.HU", "FODOR.SZABOLCS@EMAIL.HU", "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==", null, false, "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO", false, "fodor.szabolcs@email.hu" },
                    { "27410ef4-fa83-45cd-872d-d350042dd8e4", 0, "70ceb6e6-9a79-4fb8-b325-93453e2021b1", "kiraly.rudolf@email.hu", true, "Király Rudolf", false, null, "KIRALY.RUDOLF@EMAIL.HU", "KIRALY.RUDOLF@EMAIL.HU", "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==", null, false, "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO", false, "kiraly.rudolf@email.hu" },
                    { "5c55f164-cb41-4453-a473-120af44e3493", 0, "70ceb6e6-9a79-4fb8-b325-93453e2021b1", "pinter.kornel@email.hu", true, "Pintér Kornél", false, null, "PINTER.KORNEL@EMAIL.HU", "PINTER.KORNEL@EMAIL.HU", "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==", null, false, "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO", false, "pinter.kornel@email.hu" },
                    { "96494a5b-f58d-44dd-8428-6543ef5e5bd7", 0, "70ceb6e6-9a79-4fb8-b325-93453e2021b1", "balog.rajmund@email.hu", true, "Balog Rajmund", false, null, "BALOG.RAJMUND@EMAIL.HU", "BALOG.RAJMUND@EMAIL.HU", "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==", null, false, "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO", false, "balog.rajmund@email.hu" },
                    { "5b944a67-5751-423f-89fb-f0c4f0ace3fb", 0, "70ceb6e6-9a79-4fb8-b325-93453e2021b1", "hajdu.adam@email.hu", true, "Hajdú Ádám", false, null, "HAJDU.ADAM@EMAIL.HU", "HAJDU.ADAM@EMAIL.HU", "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==", null, false, "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO", false, "hajdu.adam@email.hu" },
                    { "77d8c466-d2a0-44cb-8a22-a228b6218f23", 0, "70ceb6e6-9a79-4fb8-b325-93453e2021b1", "vaszoly.jakab@email.hu", true, "Vászoly Jakab", false, null, "VASZOLY.JAKAB@EMAIL.HU", "VASZOLY.JAKAB@EMAIL.HU", "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==", null, false, "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO", false, "vaszoly.jakab@email.hu" },
                    { "4e0a018f-ca12-448e-bda9-67ac1fce5a53", 0, "70ceb6e6-9a79-4fb8-b325-93453e2021b1", "bodnar.erik@email.hu", true, "Bodnár Erik", false, null, "BODNAR.ERIK@EMAIL.HU", "BODNAR.ERIK@EMAIL.HU", "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==", null, false, "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO", false, "bodnar.erik@email.hu" },
                    { "93f49281-b3a5-41b5-972c-ff5910f26e56", 0, "70ceb6e6-9a79-4fb8-b325-93453e2021b1", "fazekas.barnabas@email.hu", true, "Fazekas Barnabás", false, null, "FAZEKAS.BARNABAS@EMAIL.HU", "FAZEKAS.BARNABAS@EMAIL.HU", "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==", null, false, "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO", false, "fazekas.barnabas@email.hu" },
                    { "5f7e27c3-9398-4cd3-977d-dae625124808", 0, "70ceb6e6-9a79-4fb8-b325-93453e2021b1", "torok.monika@email.hu", true, "Török Mónika", false, null, "TOROK.MONIKA@EMAIL.HU", "TOROK.MONIKA@EMAIL.HU", "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==", null, false, "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO", false, "torok.monika@email.hu" },
                    { "e1eaafad-b9f7-4668-9efd-d8c4418c39ca", 0, "70ceb6e6-9a79-4fb8-b325-93453e2021b1", "orsos.nora@email.hu", true, "Orsós Nóra", false, null, "ORSOS.NORA@EMAIL.HU", "ORSOS.NORA@EMAIL.HU", "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==", null, false, "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO", false, "orsos.nora@email.hu" },
                    { "5075d4b9-0ba6-4811-84ff-fed147c9c09a", 0, "70ceb6e6-9a79-4fb8-b325-93453e2021b1", "szoke.barbara@email.hu", true, "Szőke Barbara", false, null, "SZOKE.BARBARA@EMAIL.HU", "SZOKE.BARBARA@EMAIL.HU", "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==", null, false, "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO", false, "szoke.barbara@email.hu" },
                    { "765c13fb-7f8c-4474-afb5-d3a9e72feef3", 0, "70ceb6e6-9a79-4fb8-b325-93453e2021b1", "gaspar.izabella@email.hu", true, "Gáspár Izabella", false, null, "GASPAR.IZABELLA@EMAIL.HU", "GASPAR.IZABELLA@EMAIL.HU", "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==", null, false, "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO", false, "gaspar.izabella@email.hu" },
                    { "3eba4364-6a33-459c-9871-5823a9aee62a", 0, "70ceb6e6-9a79-4fb8-b325-93453e2021b1", "horvath.katalin@email.hu", true, "Horváth Katalin", false, null, "HORVATH.KATALIN@EMAIL.HU", "HORVATH.KATALIN@EMAIL.HU", "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==", null, false, "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO", false, "horvath.katalin@email.hu" },
                    { "c5e189f0-7656-4304-b963-1581f5ecf4fb", 0, "70ceb6e6-9a79-4fb8-b325-93453e2021b1", "szabo.bianka@email.hu", true, "Szabó Bianka", false, null, "SZABO.BIANKA@EMAIL.HU", "SZABO.BIANKA@EMAIL.HU", "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==", null, false, "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO", false, "szabo.bianka@email.hu" },
                    { "95810441-4970-488c-afc7-d91a07256c76", 0, "70ceb6e6-9a79-4fb8-b325-93453e2021b1", "peter.nikoletta@email.hu", true, "Péter Nikoletta", false, null, "PETER.NIKOLETTA@EMAIL.HU", "PETER.NIKOLETTA@EMAIL.HU", "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==", null, false, "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO", false, "peter.nikoletta@email.hu" },
                    { "8480bf9e-9553-47b7-a57b-474715139a83", 0, "70ceb6e6-9a79-4fb8-b325-93453e2021b1", "kiss.aniko@email.hu", true, "Kiss Anikó", false, null, "KISS.ANIKO@EMAIL.HU", "KISS.ANIKO@EMAIL.HU", "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==", null, false, "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO", false, "kiss.aniko@email.hu" },
                    { "bc803e89-e8c0-4c5a-9467-e94cd5dd0300", 0, "70ceb6e6-9a79-4fb8-b325-93453e2021b1", "csonka.krisztina@email.hu", true, "Csonka Krisztina", false, null, "CSONKA.KRISZTINA@EMAIL.HU", "CSONKA.KRISZTINA@EMAIL.HU", "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==", null, false, "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO", false, "csonka.krisztina@email.hu" },
                    { "fef0a15c-42bb-4f2d-9a65-382d4d95f667", 0, "70ceb6e6-9a79-4fb8-b325-93453e2021b1", "orsos.jozsef@email.hu", true, "Orsós József", false, null, "ORSOS.JOZSEF@EMAIL.HU", "ORSOS.JOZSEF@EMAIL.HU", "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==", null, false, "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO", false, "orsos.jozsef@email.hu" },
                    { "6c364ea9-44b4-4726-9bef-ea83c375e761", 0, "70ceb6e6-9a79-4fb8-b325-93453e2021b1", "balazs.oliver@email.hu", true, "Balázs Olivér", false, null, "BALAZS.OLIVER@EMAIL.HU", "BALAZS.OLIVER@EMAIL.HU", "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==", null, false, "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO", false, "balazs.oliver@email.hu" },
                    { "0bf93af4-1769-49f8-9bf4-e977feef94b4", 0, "70ceb6e6-9a79-4fb8-b325-93453e2021b1", "fabian.barna@email.hu", true, "Fábián Barna", false, null, "FABIAN.BARNA@EMAIL.HU", "FABIAN.BARNA@EMAIL.HU", "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==", null, false, "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO", false, "fabian.barna@email.hu" },
                    { "cb35b922-5a91-4949-94e6-47a2d6f82d93", 0, "70ceb6e6-9a79-4fb8-b325-93453e2021b1", "bacs.imre@email.hu", true, "Bács Imre", false, null, "BACS.IMRE@EMAIL.HU", "BACS.IMRE@EMAIL.HU", "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==", null, false, "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO", false, "bacs.imre@email.hu" },
                    { "512dac39-94d2-429a-a258-7740ca64c50f", 0, "70ceb6e6-9a79-4fb8-b325-93453e2021b1", "peggy@email.hu", true, "Peggy Justice", false, null, "PEGGY@EMAIL.HU", "PEGGY@EMAIL.HU", "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==", null, false, "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO", false, "peggy@email.hu" },
                    { "7236dae3-7bad-4fe6-bb18-d13ff391939d", 0, "70ceb6e6-9a79-4fb8-b325-93453e2021b1", "budai.cintia@email.hu", true, "Budai Cintia", false, null, "BUDAI.CINTIA@EMAIL.HU", "BUDAI.CINTIA@EMAIL.HU", "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==", null, false, "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO", false, "budai.cintia@email.hu" },
                    { "475c5e32-049c-4d7b-a963-02ebdc15a94b", 0, "70ceb6e6-9a79-4fb8-b325-93453e2021b1", "carson@email.hu", true, "Carson Alexander", false, null, "CARSON@EMAIL.HU", "CARSON@EMAIL.HU", "AQAAAAEAACcQAAAAEAYhQeew7rP4OrFaPD7hY14miQgE+SY2grNxQ01VBp/7AGxnUtJLFZxVj+KLYk/2Rw==", null, false, "QWHJ3YA4ZZ7PH7QGYAB2IU7PLUCA3LBO", false, "carson@email.hu" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "g8aceb4d-b534-459e-8c4e-d13374f43b65", "fef0a15c-42bb-4f2d-9a65-382d4d95f667" },
                    { "rc95a82e-0abc-4d85-9877-4184177c3a7f", "bc803e89-e8c0-4c5a-9467-e94cd5dd0300" },
                    { "rc95a82e-0abc-4d85-9877-4184177c3a7f", "8480bf9e-9553-47b7-a57b-474715139a83" },
                    { "rc95a82e-0abc-4d85-9877-4184177c3a7f", "95810441-4970-488c-afc7-d91a07256c76" },
                    { "rc95a82e-0abc-4d85-9877-4184177c3a7f", "c5e189f0-7656-4304-b963-1581f5ecf4fb" },
                    { "rc95a82e-0abc-4d85-9877-4184177c3a7f", "3eba4364-6a33-459c-9871-5823a9aee62a" },
                    { "rc95a82e-0abc-4d85-9877-4184177c3a7f", "765c13fb-7f8c-4474-afb5-d3a9e72feef3" },
                    { "rc95a82e-0abc-4d85-9877-4184177c3a7f", "7236dae3-7bad-4fe6-bb18-d13ff391939d" },
                    { "rc95a82e-0abc-4d85-9877-4184177c3a7f", "5075d4b9-0ba6-4811-84ff-fed147c9c09a" },
                    { "rc95a82e-0abc-4d85-9877-4184177c3a7f", "e1eaafad-b9f7-4668-9efd-d8c4418c39ca" },
                    { "rc95a82e-0abc-4d85-9877-4184177c3a7f", "5f7e27c3-9398-4cd3-977d-dae625124808" },
                    { "rc95a82e-0abc-4d85-9877-4184177c3a7f", "512dac39-94d2-429a-a258-7740ca64c50f" },
                    { "rc95a82e-0abc-4d85-9877-4184177c3a7f", "93f49281-b3a5-41b5-972c-ff5910f26e56" },
                    { "rc95a82e-0abc-4d85-9877-4184177c3a7f", "77d8c466-d2a0-44cb-8a22-a228b6218f23" },
                    { "rc95a82e-0abc-4d85-9877-4184177c3a7f", "5b944a67-5751-423f-89fb-f0c4f0ace3fb" },
                    { "rc95a82e-0abc-4d85-9877-4184177c3a7f", "96494a5b-f58d-44dd-8428-6543ef5e5bd7" },
                    { "rc95a82e-0abc-4d85-9877-4184177c3a7f", "5c55f164-cb41-4453-a473-120af44e3493" },
                    { "rc95a82e-0abc-4d85-9877-4184177c3a7f", "27410ef4-fa83-45cd-872d-d350042dd8e4" },
                    { "rc95a82e-0abc-4d85-9877-4184177c3a7f", "acd5d503-90e3-475c-b700-8e96fbea9e60" },
                    { "rc95a82e-0abc-4d85-9877-4184177c3a7f", "4422d2ba-934c-4899-9195-d9872d1b4c63" },
                    { "g8aceb4d-b534-459e-8c4e-d13374f43b65", "475c5e32-049c-4d7b-a963-02ebdc15a94b" },
                    { "g8aceb4d-b534-459e-8c4e-d13374f43b65", "cb35b922-5a91-4949-94e6-47a2d6f82d93" },
                    { "g8aceb4d-b534-459e-8c4e-d13374f43b65", "0bf93af4-1769-49f8-9bf4-e977feef94b4" },
                    { "rc95a82e-0abc-4d85-9877-4184177c3a7f", "4e0a018f-ca12-448e-bda9-67ac1fce5a53" },
                    { "g8aceb4d-b534-459e-8c4e-d13374f43b65", "6c364ea9-44b4-4726-9bef-ea83c375e761" }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "CreatedAt", "PreferredDeliveryDate", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 9, 28, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(8998), new DateTime(2021, 10, 1, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(9555), 0, "475c5e32-049c-4d7b-a963-02ebdc15a94b" },
                    { 2, new DateTime(2021, 9, 27, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(9824), new DateTime(2021, 9, 29, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(9834), 1, "475c5e32-049c-4d7b-a963-02ebdc15a94b" },
                    { 3, new DateTime(2021, 9, 27, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(9837), new DateTime(2021, 9, 28, 20, 19, 53, 15, DateTimeKind.Local).AddTicks(9840), 2, "475c5e32-049c-4d7b-a963-02ebdc15a94b" },
                    { 4, new DateTime(2021, 9, 23, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(9853), new DateTime(2021, 9, 25, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(9855), 3, "475c5e32-049c-4d7b-a963-02ebdc15a94b" },
                    { 5, new DateTime(2021, 9, 28, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(9858), new DateTime(2021, 9, 30, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(9861), 0, "475c5e32-049c-4d7b-a963-02ebdc15a94b" },
                    { 6, new DateTime(2021, 9, 28, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(9863), new DateTime(2021, 9, 29, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(9866), 0, "475c5e32-049c-4d7b-a963-02ebdc15a94b" }
                });

            migrationBuilder.InsertData(
                table: "Restaurant",
                columns: new[] { "Id", "DetailedDescription", "ImagePath", "IsOrderAvailable", "Name", "OwnerId", "ShortDescription", "ShowForUsers", "Address_City", "Address_PhoneNumber", "Address_Street", "Address_ZipCode" },
                values: new object[,]
                {
                    { 16, "68 év után ismét megnyílt az egykori kertvendéglő Zuglóban. A múlt században Borház néven működő családi vendéglő, ma újra családi vállalkozás. Mint akkor, ma is az ősfák árnyékában hűsölhetünk, italozhatunk, falatozhatunk és megfeledkezhetünk a rohanó mindennapokról. Élvezhetjük a díjnyertes olasz kézműves kávéból készült különlegességeket, magyar kézműves csapolt söröket és a bisztró konyha remekeit.", "https://images.unsplash.com/photo-1613274554329-70f997f5789f?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=900&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudHx8fHx8fDE2MzI4MjY5Mzk&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=1600", true, "A KERT Bisztro", "96494a5b-f58d-44dd-8428-6543ef5e5bd7", "Magyar, Nemzetközi, Halételek, Tatár steak, Egészséges, Hús ételek", true, "Szeged", "06208765698", "Thököly út 57/b", 6721 },
                    { 1, "KING'S BUFFET Kft. Fix áron fogyaszthat a több mint 100 féle ételt felvonultató svédasztalunkról és ihat finom borokat, pezsgőt, csapolt sört, szénsavas és rostos üdítőket, ásványvizet és kávét. Használja ki a svédasztalos rendszer előnyeit és válogasson saját ízlése szerint a különböző ínyencségek között! Bőséges kínálatunkban a hideg és meleg előételektől kezdve levesek és főételek sokaságán át a desszertekig számtalan fogás megtalálható. A hagyományos magyaros ételek kedvelői éppúgy megtalálják kedvenceiket, mint a reformkonyha hívei és a vegetáriánusok. A svédasztal részeként tizenkét különböző pácban friss nyers húsok és zöldségek találhatók, amelyeket szakácsaink az Ön választása alapján látványkonyhánkban készítenek el. Kellemes hangulatban rendezhetik meg családi, baráti és céges összejöveteleiket vagy tölthetnek el egy egyszerű hétköznapi ebédet is. Várjuk Önöket szeretettel!", "https://images.unsplash.com/photo-1555396273-367ea4eb4db5?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=900&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudHx8fHx8fDE2MzI2ODY1ODM&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=1600", true, "Trófea Grill Étterem - Király", "512dac39-94d2-429a-a258-7740ca64c50f", "Olasz, Pizza, Hamburger, Amerikai, Magyaros", true, "Budapest", "06301234567", "Király utca 30", 1061 },
                    { 2, "Mindig friss péksütemények, gondos kezek által, minőségi alapanyagokból! Inditsd nálunk napjaidat, mert egy Princess mindig útba esik!", "https://images.unsplash.com/photo-1543007631-283050bb3e8c?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=900&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudHx8fHx8fDE2MzI2ODcwNDE&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=1600", true, "Princess Bakery&Bistro Örs vezér tér", "bc803e89-e8c0-4c5a-9467-e94cd5dd0300", "Pizza, Pékség", true, "Budapest", "06305412567", "Örs vezér tere 1", 1148 },
                    { 3, "A Twentysix Budapest egy hatalmas ősoázis tele növénnyel a belváros szívében, egy nagyon zöld, botanikus, tér, ahol a gasztronómia, a természet és a felelős vendéglátás filozófiája találkozik és kel életre a különböző terekben: GARDEN° – mediterrán étterem, SHOP° – no waste kávézó és csomagolásmentes delikátesz bolt, STUDIO° – jógastúdió és HOUSE° – lakásstúdió és rendezvényterem. Budapest legzöldebb kertje, ahol nincsenek évszakok, csak az igazi, mediterrán nyár, az év minden napján. Egy hely, ahol a természet, a gasztronómia és a tudatos lét találkozik.", "https://images.unsplash.com/photo-1551632436-cbf8dd35adfa?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=900&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudHx8fHx8fDE2MzI3NjMxNzc&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=1600", true, "Twentysix Budapest", "8480bf9e-9553-47b7-a57b-474715139a83", "Mediterrán, Olasz , Nemzetközi, Közép Keleti", true, "Budapest", "06301233456", "Király utca 26", 1011 },
                    { 15, "A Byblos Budapest egy libanoni étterem, mely a keleti és a mediterrán konyha házasságát képviseli. Erősen támaszkodik mind a hagyományos, mind a helyi alapanyagokra. A klasszikus és modern módszerek alkalmazásával ételeink bemutatják a Levantine-i konyha különlegességeit és ízét. A menü igazi utazás a mediterrán és a keleti ízek között. Byblos Budapest családias légkörben kínálja széles választékát a vegán ételeknek, melyek kizárólagosan halal forrásból származnak.", "https://images.unsplash.com/photo-1581954548122-4dff8989c0f7?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=900&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudHx8fHx8fDE2MzI4MjY3OTQ&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=1600", true, "Byblos Budapest", "5b944a67-5751-423f-89fb-f0c4f0ace3fb", "Arab, Libanoni, Halal, Tengeri ételek, Barbeque", true, "Budapest", "06307789631", "Semmelweis utca 1-3", 1028 },
                    { 5, "Aki ismer minket, tudja, hogy órákig tudunk mesélni az IKON-ról. De ha csak egy mondatunk van rá, tömören így fogalmazunk: fanatikus gasztro-műhely. Nálunk mindenki őrült egy kicsit, és bár különbözünk, a minőség iránti elkötelezettségünk eggyé kovácsol minket. Nem elégszünk meg a jóval, a tökéletességre törekszünk, hogy a legjobb helyi alapanyagokból, a legnagyobb szakértelemmel és állandó minőségben kerüljenek vendégeink elé az ételek. A friss nyersanyagokra, a modern technológiára helyezzük a hangsúlyt, és miközben rehabilitáljuk az elfeledett vagy mellőzött alapanyagokat, engedjük, hogy távoli országok hatásai is megérintsenek. Így kerülhet vörös márna, lazac és kagyló az étlapunkra. Az étterem berendezésének koncepciója is ezen alapul, ahol a hagyományos eleganciát ötvözzük otthonos, trendi elemekkel.", "https://images.unsplash.com/photo-1587574293340-e0011c4e8ecf?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=900&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudHx8fHx8fDE2MzI3NjM4MzY&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=1600", true, "IKON Restaurant Debrecen", "c5e189f0-7656-4304-b963-1581f5ecf4fb", "Fúziós konyha, Terasz és kert, Gyermekbarát", true, "Debrecen", "06202933472", "Piac u. 23", 4028 },
                    { 6, "A Kulacs Csárda Panzió Egerben, a tufába vájt borospincék sokaságáról híres Szépasszonyvölgy szívében helyezkedik el. Pince mulatót 1986-ban nyitották, melyet igazi magyaros ízei és jó borai miatt egyre többen kerestek meg az elmúlt évek alatt, így folyamatosan újabb és újabb pinceágakkal kellett bővíteni csárdát. A történelmi hangulatú pincemulató befogadóképessége 350 fő. Öt boltíves terme légkondicionált, hagyományőrzőén, ízlésesen berendezett, kitűnően alkalmas egyéni és csoportos vendégek kulturált kiszolgálására. Tavasztól őszig az országban egyedülálló 150 fő befogadására alkalmas szőlőlugassal fedett kerthelyiség is megkóstolhatják hal, vad, szárnyas ételeinken túl magyaros ételkülönlegességeinket is. Az egri borvidék legjobb borászainak széles kínálata mellett megízlelhetik kimért termelői borokat is. A vendégek jó hangulatáról a csárda virtuóz cigányzenekara gondoskodik.", "https://images.unsplash.com/photo-1569096651661-820d0de8b4ab?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=900&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudHx8fHx8fDE2MzI3NjU1OTg&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=1600", true, "Kulacs Csárda", "3eba4364-6a33-459c-9871-5823a9aee62a", "Élőzene, Ebéd, Csoportos rendezvény, Üzleti ebéd, Vacsora", true, "Eger", "06301933174", "Szépasszonyvölgy 1", 3300 },
                    { 4, "A söröző-étterem a Csokonai Színházzal szemben található, klimatizált pincehelyiség, ahol különböző méretű és hangulatú termek állnak rendelkezésre csoportok fogadsára, rendezvények lebonyolítására. Elkülönített, nemdohányzó helyiség is szolgálja a vendégek kényelmét. Az ételválasztékban nemzetközi, és hagyományos magyaros ételspecialitások gazdag kínálatát vonultatja fel az étterem. ", "https://images.unsplash.com/photo-1514933651103-005eec06c04b?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=900&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudHx8fHx8fDE2MzI3NjM1MDM&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=1600", true, "Csokonai Étterem", "95810441-4970-488c-afc7-d91a07256c76", "Terasz és kert, Privát helyiség, Gyermekbarát, Elvitel", true, "Debrecen", "06203433499", "Kossuth utca 21", 4025 },
                    { 8, "Hamburgerező Szegeden, a Kálvária téren. Ha bármilyen kérdésed van rendelés menetével, a kiszállítással vagy a termékeinkkel kapcsolatban, kérlek, keress minket a lenti elérhetőségeinken!", "https://images.unsplash.com/photo-1516062423079-7ca13cdc7f5a?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=900&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudHx8fHx8fDE2MzI4MjMzNTQ&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=1600", true, "Szegedi rostlaposok", "7236dae3-7bad-4fe6-bb18-d13ff391939d", "Burgerek, 5000 Ft alatt", true, "Szeged", "06302932179", "Kálvária tér 25.", 6725 },
                    { 14, "Egy gasztronómiai szakember 1839-ben elhangzott mondatát idézve, az olasz konyha meghatározó alapanyaga a paradicsom. A zseniális ötlet, hogy a paradicsomot hozzáadják a tésztához és a pizzához, nemcsak a nápolyiak több generációját tette boldoggá, hanem mindenkit, aki szereti és értékeli az olasz konyhát. Ezért is lett az étterem neve a Pomo D'oro, amely ebben a formában aranyalmát egyben írva, pedig paradicsomot jelent. Az étterem konyhafőnöke, Rosario az igazi tradicionális ételek mellett saját receptgyűjteményéből is rengeteg fogást elkészít. Híresek a vendégtérben készülő ételek, melyek nemcsak látványban nyűgözik le a vendégeket, de aki egyszer megkóstolta, az ízükre is sokáig emlékszik. Nap mint nap új ételekkel várja az étterem a vendégeit, hiszen valami érdekességet, kuriózumot mindig rejt a kínálatuk. Legyenek azok ritkán fellelhető gombák, friss halkülönlegességek vagy akár az évszakhoz igazodó idény zöldségek.", "https://images.unsplash.com/photo-1543007630-9710e4a00a20?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=900&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudHx8fHx8fDE2MzI4MjY0NjY&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=1600", true, "Trattoria Pomo D'Oro", "77d8c466-d2a0-44cb-8a22-a228b6218f23", "Mediterrán, Olasz, Halételek, Pizza, Tengeri ételek, Tészta, Hús ételek", true, "Debrecen", "06209972364", "Arany János utca 9", 4014 },
                    { 18, "2008-ban épült fel egy új szálloda (Hotel Castle Garden) a Budai Vár tövében a Bécsi Kapu lábánál, melynek részeként megnyílt a Bonfini Kert Étterem. \nAz akkori üzemeltetők szemlélete eltért a mi elképzelésünktől, amit 2011 nyara óta próbálunk eljuttatni a köztudatba, immáron Riso Ristorante & Terrace néven. A ’Terrace’ szó nem hiába került bele az elnevezésbe, hiszen a vendégek valóban úgy érezhetik, hogy egy másik világba, idilli környezetbe csöppentek, elég helyet foglalni a buja zöld növényzettel körülölelt terasz asztalainál. A kerthelyiség szinteltolásos építészeti kialakítása, a felső részen helyet kapott grillkonyha, a kényelmesen és tágasan elhelyezett bútorzat és a minden igényt kielégítő gyermekjátszótér intim és egyben otthonos hangulatot teremt. \nTermészetesen a szép terasz és a vidám friss érzést keltő belső tér kevés lenne a vendégek megnyeréséhez, de a nagy részt tradicionális olasz és hazai ízek mellett széles rizottóválaszték, házi tészták és kemencében sült pizza is szerepel a kínálatban!", "https://images.unsplash.com/photo-1554118811-1e0d58224f24?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=900&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudHx8fHx8fDE2MzI4Mjc1NTQ&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=1600", true, "Riso Ristorante & Terrace", "27410ef4-fa83-45cd-872d-d350042dd8e4", "Mediterrán, Terasz és kert, Ingyenes parkolás, WIFI, Gyermekbarát, Elvitel", true, "Debrecen", "06205872956", "Lovas út 41", 4007 }
                });

            migrationBuilder.InsertData(
                table: "Restaurant",
                columns: new[] { "Id", "DetailedDescription", "ImagePath", "IsOrderAvailable", "Name", "OwnerId", "ShortDescription", "ShowForUsers", "Address_City", "Address_PhoneNumber", "Address_Street", "Address_ZipCode" },
                values: new object[,]
                {
                    { 19, "Akademia Italia egy itáliai gasztronómiai központ Budapest szívében, a Szent István Bazilika tövében. Három az egyben: minőségi olasz étterem, autentikus delikátesz bolt és főzőiskola egy helyen. Az étterem várja mindazokat, akik az olasz konyha minőségi, kizárólag eredetvédett alapanyagaiból készülő fogásait keresik; azokat is, akik egy darab focacciáért érkeznek; de azokat is, akik autentikus olasz hozzávalókat vásárolnának egy nagyszabású, többfogásos családi vacsorához. Várják a munka előtt csak úgy betérő vendégeket egy tökéletes olasz espressóra, hogy jól induljon a napjuk; valamint azokat is, akik esetleg szeretnének belemélyedni a tortelloni-készítés rejtelmeibe a főzőiskola keretein belül.", "https://images.unsplash.com/photo-1602748828300-2843df3b3923?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=900&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudHx8fHx8fDE2MzI4Mjc2NjU&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=1600", true, "Akademia Italia", "acd5d503-90e3-475c-b700-8e96fbea9e60", "Olasz, Bár ételek, Halételek, Pizza, Tengeri ételek, Tészta", true, "Debrecen", "06308173984", "Szent István tér 12", 4001 },
                    { 20, "Egy cseppnyi hangulat Budapest szívében. Hangulat egy kávéra, egy finom pohár borra, egy könnyű ebédre, vagy egy vacsorára. A legfrissebb minőségi alapanyagok,gazdag íz választék, igazi vendégszeretet. Budapest legszebb kertjében, mely a téli hidegben fűtött pavillonban idézi fel bennűnk egy meghitt télikert hangulatát", "https://images.unsplash.com/photo-1600184894885-4066d2b92fda?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=900&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudHx8fHx8fDE2MzI4Mjc4OTg&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=1600", true, "Pavillon de Paris Francia Étterem", "4422d2ba-934c-4899-9195-d9872d1b4c63", "Angol, Francia, Terasz és kert, Angolul beszélünk, Fűtött terasz, Németül beszélünk, WIFI, Ebéd menü", true, "Budapest", "06208133946", "Fő utca 20", 1015 },
                    { 13, "A Stand25 Szulló Szabina és Széll Tamás lehető legkomolyabban vett örömkonyhája a a város budai oldalán, sétatávolságra a Lánchídtól és a Váralagúttól. A Stand25 alig egy évvel a nyitása után Bib Gourmand minősítést szerzett. Izgalmas kitérő a séfek számára a fine dining világából, ahol csupán egyetlen szabály van: a minőségben és az alapanyagban nem ismerni kompromisszumot. Szabad magyar konyha, egy laza, barátságos hangulatú bisztróban, ahol a Csahók Ibolya vezette szervíz ugyanolyan törődéssel kíséri végig a vendéget, mint egy csúcsétteremben, csak sokkal közvetlenebb stílusban.", "https://images.unsplash.com/photo-1485686531765-ba63b07845a7?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=900&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudHx8fHx8fDE2MzI4MjYyMjc&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=1600", true, "Stand25 Bisztró", "4e0a018f-ca12-448e-bda9-67ac1fce5a53", "Magyar konyha, Bisztró, Ebéd, Alkalmas üzleti tárgyalásokra, Vacsora", true, "Budapest", "06209977645", "Attila út 10", 1025 },
                    { 7, "A Macok Bisztró és Borbár könnyed és fiatalos lendületű hely, ahol kulináris élményt kínálunk igényes bisztró stílusban, helyi borászok bemutatásával és olyan borkülönlegességekkel, amelyek már csak a gyűjtők pincéjében találhatók meg. Az étterem a történelmi belvárosban az egri Vár bejáratánál helyezkedik el, a teraszon üldögélve a megelevenedő történelem részeseivé válhatunk.", "https://images.unsplash.com/photo-1416453072034-c8dbfa2856b5?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=900&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudHx8fHx8fDE2MzI4MjI3ODk&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=1600", true, "Macok Bisztró és Borbár", "765c13fb-7f8c-4474-afb5-d3a9e72feef3", "Borbár, Étterem, Terasz és kert", true, "Eger", "06201944175", "Tinódi Sebestyén tér 4", 3300 },
                    { 12, "Borús idő, derűs dél-amerikai hangulat - esténként már az étterem belső terében terítjük az asztalokat, öt órától ma is Tiétek a hacienda! ", "https://images.unsplash.com/photo-1533777419517-3e4017e2e15a?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=900&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudHx8fHx8fDE2MzI4MjYwNTc&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=1600", true, "Tereza", "93f49281-b3a5-41b5-972c-ff5910f26e56", "Mexikói konyha, Terasz és kert, Angolul beszélünk", true, "Budapest", "06301876756", "Nagymező utca 3", 1021 },
                    { 11, "A High Note SkyBar Budapest egyik legexkluzívabb helyszíne és egyben a város egyetlen, egész évben nyitva tartó tetőterasza. A friss, laza, új szemlélet a garancia rá, hogy itt nem csak a körpanoráma nyújt feledhetetlen élményt. Vendégeinket évszakonként megújuló koktélkínálattal és barfood-választékkal várjuk! Amennyiben szeretne ellátogatni hozzánk, kérjük, minél hamarabb foglalja le asztalát, hogy garantálni tudjuk az ülőhelyet Önöknek!", "https://images.unsplash.com/photo-1555396273-367ea4eb4db5?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=900&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudHx8fHx8fDE2MzI4MjU4NzY&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=1600", true, "High Note SkyBar", "5f7e27c3-9398-4cd3-977d-dae625124808", "Bár ételek, Tapas, Sütemények, Terasz és kert, Angolul beszélünk, Fűtött terasz, Közel tömegközlekedéshez, Légkondicionálás", true, "Budapest", "06203369867", "Hercegprímás utca 5", 1007 },
                    { 10, "A mazel tov étterem és bár 2014. Július végén nyitott egy igazi mediterrán hangulatú helyként, melyet évszaktól függetlenül szeretnénk megőrizni nyáron nyitott, télen pedig fűtött kerthelységgel. A mazel tov célja működése óta egy nyitott szemléletű, gasztrónómiai és kulturális szempontból meghatározó, fesztelen hangulatú origó megteremtése, ahol délutántól zárásig várnak szeretettel mindenkit, aki betér és kikapcsolódni vágyik, legyen szó kulturális vagy kulináris élvezetekről, vagy épp baráti fröccsözésekről. A mazel tov ötlete az adottságok és a számunkra fontos gondolatok kiemélésén alapszik; a hangulatos, városi kertek, a nyitott szemlélet valamint a sokszínű mediterrán konyha összekapcsolásán, ötvözetén. Az akácfa utcában nemrég nyílt mazel tov az első olyan szórakozókert, amely az ötödik kerületi magas szintű gasztro-vendéglátó infrastruktúrát az autentikus, romkocsmaközeli hetedik kerületbe hivatott beültetni, így erősítve a sokszínűséget és az új színt a budapesti palettán.", "https://images.unsplash.com/photo-1603055021980-7a6e8abd9bd5?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=900&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudHx8fHx8fDE2MzI4MjM2MjQ&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=1600", true, "Mazel Tov", "e1eaafad-b9f7-4668-9efd-d8c4418c39ca", "Zsidó konyha, Bár ételek, Angolul beszélünk, WIFI, Gyermekbarát, Elvitel", true, "Budapest", "06201733274", "Akácfa utca 47", 1017 },
                    { 9, "Ha Szegeden járva egy igazi magyaros kulináris kalandozásban szeretnénk részt venni, akkor bizony a Vendéglő a Régi Hídhoz ránk vár. Az étteremben magyar népies dekoráció, a szegedi paprikafüzérek és a kedves személyzet biztosít minket arról, hogy jó helyen járunk. Az étterem belsőhöz és a magyar tradicionális ételekhez illő kreatív teríték is megfűszerezi a hangulatot. Fenséges ízek, csodálatos adagokban, gusztusos terítéssel, baráti árakon.", "https://images.unsplash.com/photo-1544609499-d9b16fe50243?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=900&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudHx8fHx8fDE2MzI4MjMzOTQ&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=1600", true, "Vendéglő A Régi Hídhoz", "5075d4b9-0ba6-4811-84ff-fed147c9c09a", "Magyar konyha, Terasz és kert, Fizető parkoló, Gyermekbarát, Elvitel", true, "Szeged", "06204933175", "Oskola utca 4", 6725 },
                    { 17, "A magányos sütés és a titkos kísérletezés ideje lejárt, Franziska csodálatos otthonra lelt.\nTermészetes továbblépés ez, hiszen Franziska szerint a vendéglátásban rejtőzik valami igazi varázslat: a hozzávalók aprólékos kiválasztásában, egy hangulat térbe való átültetésében, egy maradandó íz létrehozásában, a régi könyvekből merített inspirációkban és természetesen egy közösség megteremtésében. \nMert azt szeretnénk, ha nálunk kapnátok fel reggel egy gőzölgő specialty kávét vagy egy friss életerő turmixot, harapnátok egyet mellé a még melegen roppanó szendvicsből, vagy ha végre egyszer igazán hosszan tarthatna a reggeli, kiélvezve a legcsodásabb étkezés minden percét...\nPersze minden a megszokott Franziska desszertekkel körítve, örökre belefeledkezve a kókusz, a datolya, a mandula vagy a pisztácia aromáinak bonyolult árnyalataiba. \nGyertek és legyetek a vendégeink, szeretettel várunk!", "https://images.unsplash.com/photo-1414235077428-338989a2e8c0?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=900&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudHx8fHx8fDE2MzI4MjczNjU&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=1600", true, "Franziska", "5c55f164-cb41-4453-a473-120af44e3493", "Kávézó, Étterem, Rendelhető ételek, Egészséges, Sütemények", true, "Szeged", "06208761985", "Iskola u. 29", 6711 }
                });

            migrationBuilder.InsertData(
                table: "UserAddress",
                columns: new[] { "Id", "UserId", "Address_City", "Address_PhoneNumber", "Address_Street", "Address_ZipCode" },
                values: new object[,]
                {
                    { 3, "0bf93af4-1769-49f8-9bf4-e977feef94b4", "Szeged", "06301455892", "Kálmán utca 2", 6725 },
                    { 1, "475c5e32-049c-4d7b-a963-02ebdc15a94b", "Budapest", "06201214561", "Kossuth utca 30", 1060 },
                    { 4, "6c364ea9-44b4-4726-9bef-ea83c375e761", "Debrecen", "06201351961", "Erdei utca 32", 4028 },
                    { 5, "fef0a15c-42bb-4f2d-9a65-382d4d95f667", "Eger", "06301451861", "Liget utca 11", 3300 },
                    { 2, "cb35b922-5a91-4949-94e6-47a2d6f82d93", "Budapest", "06301451567", "Petőfi utca 3", 1017 }
                });

            migrationBuilder.InsertData(
                table: "Food",
                columns: new[] { "Id", "Description", "ImagePath", "IsDeleted", "Name", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { 47, "Jemeni fűszerekkel főtt csirkeleves tépett csirkecombbal, citrommal és friss korianderrel", "https://images.unsplash.com/photo-1469307517101-0b99d8fb0c33?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8c291cHx8fHx8fDE2MzI4MjU0OTk&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Jemeni Csirkeleves", 1690, 10 },
                    { 53, "További kérdés esetén, rendelésed leadása előtt keresd az ügyfélszolgálatunkat bizalommal.", "https://images.unsplash.com/photo-1562847961-8f766d774a28?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8bWVhdHx8fHx8fDE2MzI2OTA1Njg&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Ropogós kacsacomb", 3700, 11 },
                    { 52, "További kérdés esetén, rendelésed leadása előtt keresd az ügyfélszolgálatunkat bizalommal.", "https://images.unsplash.com/photo-1518290943012-2c2bec0e54d2?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8Zm9vZCxtZWF0fHx8fHx8MTYzMjY5MDUwMQ&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Burgundi szarvasszelet", 3650, 11 },
                    { 51, "További kérdés esetén, rendelésed leadása előtt keresd az ügyfélszolgálatunkat bizalommal.", "https://images.unsplash.com/photo-1524081684693-1519036f3449?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8Zm9vZCxyZXN0YXVyYW50fHx8fHx8MTYzMjY5MDM4MA&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Libamáj pástétom házi lila hagyma lekvárral", 4750, 11 },
                    { 81, "grillezett libamájjal és gyümölcsökkel", "https://images.unsplash.com/photo-1467003909585-2f8a72700288?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8Zm9vZCxwbGF0ZXx8fHx8fDE2MzI3NzI0ODA&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Lávakövön sült pulykamell", 3700, 16 },
                    { 82, "roston bélszín, serpenyős cigánypecsenye, rántott csirkemell, kakastaréj, sült kockaburgonya, házi csalamádé", "https://images.unsplash.com/photo-1611315764615-3e788573f31e?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8ZGlzaHx8fHx8fDE2MzI3NzI5ODg&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Erdélyi fatányéros", 4200, 16 },
                    { 50, "Házi recept alapján készített, darált marha pogácsa", "https://images.unsplash.com/photo-1625937282844-4a0cb4665820?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8YmVlZnx8fHx8fDE2MzI4MjU1OTk&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Bárányzsíron sült petrezselymes marha kebab", 3590, 10 },
                    { 49, "Két fajta lencséből készült krémleves, sült padlizsán kockákkal és lime-chili mogyoróval", "https://images.unsplash.com/photo-1547308283-b74183c15032?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8c291cHx8fHx8fDE2MzI4MjU1MTk&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Vegán lencsekrémleves", 1590, 10 },
                    { 48, "Minden hummusz tálat friss, házi hummusszal, csicseriborsóval, tahinivel, petrezselyemmel és olívaolajjal tálalunk, mellé friss grillezett pitát adunk. Kérheted zhug csipős szósszal is!", "https://images.unsplash.com/photo-1622040806062-27ae4deb4a40?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8aHVtdXN8fHx8fHwxNjMyODI1NTcy&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Humusz Tahini tál", 1890, 10 },
                    { 100, "Házi recept alapján készített, darált marha pogácsa", "https://images.unsplash.com/photo-1625937282844-4a0cb4665820?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8YmVlZnx8fHx8fDE2MzI4MjU1OTk&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Bárányzsíron sült petrezselymes marha kebab", 3590, 20 },
                    { 46, "Joghurtból készült házi krémsajt, marinált paprikával és sült articsókával, friss pitával tálalva", "https://images.unsplash.com/photo-1565720490528-48e5be3d6a1f?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudCxmb29kfHx8fHx8MTYzMjgyNTI2OQ&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Labane", 1890, 10 },
                    { 83, "üstölt zellerpüré, padron paprika, vargányagomba", "https://images.unsplash.com/photo-1626509653291-18d9a934b9db?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8bWVhdCxwbGF0ZXx8fHx8fDE2MzI4MjM5MzM&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Bikavéres marhapofa", 4250, 17 },
                    { 45, "roston sült libamáj, gomba, egri barnamártás", "https://images.unsplash.com/photo-1598511726623-d2e9996892f0?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8bG9pbnx8fHx8fDE2MzI4MjUxMzI&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Bélszínjava egri módra", 5800, 9 },
                    { 44, "spenót, spárga, sajt", "https://images.unsplash.com/photo-1467003909585-2f8a72700288?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8ZmlzaCxwbGF0ZXx8fHx8fDE2MzI4MjUwOTg&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Besütött harcsa főszakács-módra", 3600, 9 },
                    { 43, "pirított kolbász, füstölt tarja, füstölt szalonna, vöröshagyma, savanyú uborka, tejföl", "https://images.unsplash.com/photo-1584932901306-a19fdf291cec?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cG9ya3x8fHx8fDE2MzI4MjQ5ODQ&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Bádogos csülök", 2900, 9 },
                    { 42, "szaftos, vaslapon sült karaj fokhagymával, sült szalonnával", "https://images.unsplash.com/photo-1624174503860-478619028ab3?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cG9ya3x8fHx8fDE2MzI4MjQ4OTQ&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Kishuszáros karaj", 2800, 9 },
                    { 41, "vaslapon sült pácolt karaj tejfölös, füstölt tarjás, savanyú uborkás, szalonnás raguval", "https://images.unsplash.com/photo-1605209971703-73c7ed7c923e?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cG9ya3x8fHx8fDE2MzI4MjQ4NzI&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Favágó karaj", 2800, 9 },
                    { 84, "szőlő chutney-val, dióval, házi brioche-sal", "https://images.unsplash.com/photo-1626200419199-391ae4be7a41?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8c291cHx8fHx8fDE2MzI4MjQwMTE&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Kacsamáj befőtt", 2890, 17 },
                    { 40, "szezámmagos buci, marhahúspogácsa 2 db (13 dkg-os), BBQ szósz, lila hagyma, paradicsom, kígyóuborka, cheddar sajt, füstölt sajt, trappista sajt, bacon, jalapeno", "https://images.unsplash.com/photo-1561043433-9265f73e685f?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8YnVyZ2VyfHx8fHx8MTYzMjgyNDYwMQ&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Zátony Burger", 1899, 8 },
                    { 39, "szezámmagos buci, marhahúspogácsa (13 dkg-os), BBQ szósz, jégsaláta, paradicsom, füstölt sajtchips, cheddar sajt, bacon, jalapeno", "https://images.unsplash.com/photo-1572802419224-296b0aeee0d9?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8YnVyZ2VyfHx8fHx8MTYzMjgyNDUwMg&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Rosti Burger", 1599, 8 },
                    { 38, "szezámmagos buci, marhahús pogácsa 1 db (13 dkg), ketchup, jégsaláta, kígyóuborka, pirított hagyma, bacon, jalapeno", "https://images.unsplash.com/photo-1585238341267-1cfec2046a55?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8YnVyZ2VyfHx8fHx8MTYzMjgyNDQxOQ&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Erős Anna", 1399, 8 },
                    { 37, "szezámmagos buci, marhahúspogácsa 1 db (13 dkg), hamburgerszósz, jégsaláta, csemege uborka, trappista sajt, pirított hagyma, bacon", "https://images.unsplash.com/photo-1623945359564-b8d01dd5cfe2?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8YnVyZ2VyfHx8fHx8MTYzMjgyNDMyNQ&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Taxi burger", 1399, 8 },
                    { 54, "További kérdés esetén, rendelésed leadása előtt keresd az ügyfélszolgálatunkat bizalommal.", "https://images.unsplash.com/photo-1583182332473-b31ba08929c8?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8ZG9udXR8fHx8fHwxNjMyNjkwNzA2&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Trófea burgonyafánk", 900, 11 },
                    { 85, "füstös velőmajonézzel, savanyított hagymákkal", "https://images.unsplash.com/photo-1514516345957-556ca7d90a29?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8dGF0YXIsbWVhdHx8fHx8fDE2MzI4MjQwOTU&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Angus marhatatár", 2890, 17 },
                    { 55, "marhahús (medium), ezersziget öntet, karamellizált hagyma, csemegeuborka A hamburger húspogácsák és a bucik nem tartalmaznak adalékanyagot és tartósítószert!", "https://images.unsplash.com/photo-1618219877887-442767be5d68?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8aGFtYnVyZ2VyfHx8fHx8MTYzMjY5MDc2MA&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Trófea Burger", 1090, 11 },
                    { 57, "marhahús (medium), grillezett cheddar sajt, karamellizált hagyma, csemegeuborka, bacon, BBQ szósz A hamburger húspogácsák és a bucik nem tartalmaznak adalékanyagot és tartósítószert!", "https://images.unsplash.com/photo-1491960693564-421771d727d6?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8aGFtYnVyZ2VyfHx8fHx8MTYzMjY5MDg0Ng&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Trófea BBQ burger", 1400, 11 },
                    { 77, "szarvasgomba, tanyasi csirke/garnéla/bélszín", "https://images.unsplash.com/photo-1482049016688-2d3e1b311543?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudCxmb29kfHx8fHx8MTYzMjc3MTY4MA&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Házi tagliatelle", 4690, 15 },
                    { 74, "ruccolás burgonyapürével, mentás mártással, toszkán zöldbabbal", "https://images.unsplash.com/photo-1514516345957-556ca7d90a29?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8bWVhdCxwbGF0ZXx8fHx8fDE2MzI3NzEyNzk&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Vasvári zoltán féle konfitált báránycsülök", 3990, 14 },
                    { 73, "rózsaborsos-citrusos mangó pürével, savoyai burgonyával", "https://images.unsplash.com/photo-1505253668822-42074d58a7c6?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8ZHVjayxmb29kfHx8fHx8MTYzMjc3MTEzNA&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Narancsos kacsa", 3690, 14 },
                    { 72, "Ahogy katalán chef barátunktól tanultuk", "https://images.unsplash.com/photo-1575932444877-5106bee2a599?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8Q2hpY2tlbiBicmVhc3R8fHx8fHwxNjMyNzcwOTk4&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Csirkemellből készült paella", 2990, 14 },
                    { 71, "konyakos-libamájas mártással, tepertős burgonyapürével, szőlővel", "https://images.unsplash.com/photo-1504472607343-a7fac413b524?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cGxhdGV8fHx8fHwxNjMyNzcwNzkx&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Bivaly", 3790, 14 },
                    { 70, "pirított pisztáciával, citromhéjas tejszínes udon tésztával", "https://images.unsplash.com/photo-1556269923-e4ef51d69638?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8c3RlYWt8fHx8fHwxNjMyNzcwNjYx&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Beluga steak limoncelloval flambírozva", 4390, 14 },
                    { 78, "füstölt saláta, boquerones", "https://images.unsplash.com/photo-1504973960431-1c467e159aa4?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8Zm9vZCxwbGF0ZXx8fHx8fDE2MzI3NzE5NzU&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Tanyasi csirke", 4990, 15 },
                    { 69, "menta, spárga ragu, pecorino, narancs", "https://images.unsplash.com/photo-1613478881426-deeadee06d78?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8ZWdncGxhbnR8fHx8fHwxNjMyNzY0OTg1&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Füstölt padlizsán tortelli", 3250, 13 },
                    { 68, "(220 g), rukkola, grana padano d.o.p., koktélparadicsom", "https://images.unsplash.com/photo-1607198179219-cd8b835fdda7?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8c3RlYWt8fHx8fHwxNjMyNzY0ODA2&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Rib-eye", 7650, 13 },
                    { 67, "grillezett füge, szója emulzió, retek", "https://images.unsplash.com/photo-1601565960311-8a7f4e1ab709?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cGFwcmlrYXx8fHx8fDE2MzI3NjQ2ODg&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Vegán csőben sült kaliforniai paprika", 2950, 13 },
                    { 66, "brokkoli, beluga lencse, édes-savanyú redukció, friss zöldfűszerek", "https://images.unsplash.com/photo-1485704686097-ed47f7263ca4?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8c3RlYWt8fHx8fHwxNjMyNzY0NDYw&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Lazac steak", 4950, 13 },
                    { 65, "zöldfűszeres gnocchi, zeller, kurkuma, shallot", "https://images.unsplash.com/photo-1501200291289-c5a76c232e5f?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8Y2hpY2tlbnx8fHx8fDE2MzI3NjQzNzU&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Balzsamecetben marinált csirke", 3550, 13 },
                    { 79, "ertéscomb, csirkemáj, gomba,zöldségek - tejszínes-kapros habarással készül", "https://images.unsplash.com/photo-1574484284002-952d92456975?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8c291cHx8fHx8fDE2MzI3NzIzOTc&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Legényfogó leves", 1660, 16 },
                    { 64, "paradicsomszósz, mozzarella sajt, szalámi, pepperoni, hagyma, Ajándék Xixo mojitoval (Pizzáink 100%-ban olasz alapanyagokból készülnek.)", "https://images.unsplash.com/photo-1589906493606-a6ca2a06078b?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cGl6emF8fHx8fHwxNjMyNjkxMDgy&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Szalámis pizza (32cm)", 2290, 12 },
                    { 63, "paradicsomszósz, mozzarella sajt, sonka, kukorica, Ajándék Xixo mojitoval (Pizzáink 100%-ban olasz alapanyagokból készülnek.)", "https://images.unsplash.com/photo-1605478371310-a9f1e96b4ff4?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cGl6emF8fHx8fHwxNjMyNjkxMDM4&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Sonkás-gombás pizza (32cm)", 2290, 12 },
                    { 62, "paradicsomszósz, mozzarella sajt, zöld olívabogyó, paradicsom, Ajándék Xixo mojitoval (Pizzáink 100%-ban olasz alapanyagokból készülnek.)", "https://images.unsplash.com/photo-1589375890993-7b568c0b8b1c?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cGl6emF8fHx8fHwxNjMyNjkxMDA4&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Olívás margarita pizza (32cm)", 2190, 12 }
                });

            migrationBuilder.InsertData(
                table: "Food",
                columns: new[] { "Id", "Description", "ImagePath", "IsDeleted", "Name", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { 61, "paradicsomszósz, mozzarella sajt, Ajándék Xixo mojitoval (Pizzáink 100%-ban olasz alapanyagokból készülnek.)", "https://images.unsplash.com/photo-1585505008861-a5c378857dcc?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cGl6emF8fHx8fHwxNjMyNjkwOTc4&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Margherita pizza (32cm)", 2190, 12 },
                    { 60, "paradicsomszósz, mozzarella sajt, feta sajt, hagyma, rukkola, paradicsom, Ajándék Xixo mojitoval (Pizzáink 100%-ban olasz alapanyagokból készülnek.)", "https://images.unsplash.com/photo-1516697073-419b2bd079db?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cGl6emF8fHx8fHwxNjMyNjkwOTQ0&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Bruschetta pizza (32cm)", 2390, 12 },
                    { 59, "paradicsomszósz, mozzarella sajt, füstölt sajt, BBQ csirkehús, paradicsom, lila hagyma, Ajándék Xixo mojitoval (Pizzáink 100%-ban olasz alapanyagokból készülnek.)", "https://images.unsplash.com/photo-1618213957768-7789409b9dd8?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cGl6emF8fHx8fHwxNjMyNjkwOTEy&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "BBQ pizza (32cm)", 2490, 12 },
                    { 80, "sonka, főtt-füstölt tarja, téli szalámi és paprikás szalámi, baconszalonna, parasztmájas, füstölt kolbász, sajtok, főtt tojás, friss zöldségek ", "https://images.unsplash.com/photo-1432139509613-5c4255815697?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8bWVhdCxmb29kfHx8fHx8MTYzMjc3MjY1OQ&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Magyaros hidegtál", 3000, 16 },
                    { 58, "ketchup, karamellizált hagyma, vegán pogácsa, uborka, mustár A hamburger húspogácsák és a bucik nem tartalmaznak adalékanyagot és tartósítószert!", "https://images.unsplash.com/photo-1470053053191-43e7bd267838?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8aGFtYnVyZ2VyfHx8fHx8MTYzMjY5MDg4MA&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Trófea Burger vegán pogácsával", 1250, 11 },
                    { 56, "10dkg marhahús (medium), karamellizált hagyma, csemegeuborka, cheddar sajt, ezersziget öntet A hamburger húspogácsák és a bucik nem tartalmaznak adalékanyagot és tartósítószert!", "https://images.unsplash.com/photo-1624348754836-743503fe9445?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8aGFtYnVyZ2VyfHx8fHx8MTYzMjY5MDgwOA&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Trófea Cheese Burger", 1250, 11 },
                    { 36, "parajlevél pestóval és sós dióval, aszalt paradicsommal", "https://images.unsplash.com/photo-1618163633808-dbd8a9f658ce?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cGFzdGF8fHx8fHwxNjMyODI0MTUz&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Házi hosszúmetélt", 2490, 7 },
                    { 35, "füstös velőmajonézzel, savanyított hagymákkal", "https://images.unsplash.com/photo-1514516345957-556ca7d90a29?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8dGF0YXIsbWVhdHx8fHx8fDE2MzI4MjQwOTU&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Angus marhatatár", 2890, 7 },
                    { 34, "szőlő chutney-val, dióval, házi brioche-sal", "https://images.unsplash.com/photo-1626200419199-391ae4be7a41?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8c291cHx8fHx8fDE2MzI4MjQwMTE&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Kacsamáj befőtt", 2890, 7 },
                    { 14, "paradicsomszósz, mozzarella sajt, szalámi, pepperoni, hagyma, Ajándék Xixo mojitoval (Pizzáink 100%-ban olasz alapanyagokból készülnek.)", "https://images.unsplash.com/photo-1589906493606-a6ca2a06078b?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cGl6emF8fHx8fHwxNjMyNjkxMDgy&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Szalámis pizza (32cm)", 2290, 2 },
                    { 13, "paradicsomszósz, mozzarella sajt, sonka, kukorica, Ajándék Xixo mojitoval (Pizzáink 100%-ban olasz alapanyagokból készülnek.)", "https://images.unsplash.com/photo-1605478371310-a9f1e96b4ff4?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cGl6emF8fHx8fHwxNjMyNjkxMDM4&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Sonkás-gombás pizza (32cm)", 2290, 2 },
                    { 12, "paradicsomszósz, mozzarella sajt, zöld olívabogyó, paradicsom, Ajándék Xixo mojitoval (Pizzáink 100%-ban olasz alapanyagokból készülnek.)", "https://images.unsplash.com/photo-1589375890993-7b568c0b8b1c?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cGl6emF8fHx8fHwxNjMyNjkxMDA4&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Olívás margarita pizza (32cm)", 2190, 2 },
                    { 11, "paradicsomszósz, mozzarella sajt, Ajándék Xixo mojitoval (Pizzáink 100%-ban olasz alapanyagokból készülnek.)", "https://images.unsplash.com/photo-1585505008861-a5c378857dcc?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cGl6emF8fHx8fHwxNjMyNjkwOTc4&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Margherita pizza (32cm)", 2190, 2 },
                    { 10, "paradicsomszósz, mozzarella sajt, feta sajt, hagyma, rukkola, paradicsom, Ajándék Xixo mojitoval (Pizzáink 100%-ban olasz alapanyagokból készülnek.)", "https://images.unsplash.com/photo-1516697073-419b2bd079db?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cGl6emF8fHx8fHwxNjMyNjkwOTQ0&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Bruschetta pizza (32cm)", 2390, 2 },
                    { 9, "paradicsomszósz, mozzarella sajt, füstölt sajt, BBQ csirkehús, paradicsom, lila hagyma, Ajándék Xixo mojitoval (Pizzáink 100%-ban olasz alapanyagokból készülnek.)", "https://images.unsplash.com/photo-1618213957768-7789409b9dd8?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cGl6emF8fHx8fHwxNjMyNjkwOTEy&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "BBQ pizza (32cm)", 2490, 2 },
                    { 93, "pirított kolbász, füstölt tarja, füstölt szalonna, vöröshagyma, savanyú uborka, tejföl", "https://images.unsplash.com/photo-1584932901306-a19fdf291cec?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cG9ya3x8fHx8fDE2MzI4MjQ5ODQ&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Bádogos csülök", 2900, 19 },
                    { 94, "spenót, spárga, sajt", "https://images.unsplash.com/photo-1467003909585-2f8a72700288?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8ZmlzaCxwbGF0ZXx8fHx8fDE2MzI4MjUwOTg&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Besütött harcsa főszakács-módra", 3600, 19 },
                    { 8, "ketchup, karamellizált hagyma, vegán pogácsa, uborka, mustár A hamburger húspogácsák és a bucik nem tartalmaznak adalékanyagot és tartósítószert!", "https://images.unsplash.com/photo-1470053053191-43e7bd267838?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8aGFtYnVyZ2VyfHx8fHx8MTYzMjY5MDg4MA&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Trófea Burger vegán pogácsával", 1250, 1 },
                    { 7, "marhahús (medium), grillezett cheddar sajt, karamellizált hagyma, csemegeuborka, bacon, BBQ szósz A hamburger húspogácsák és a bucik nem tartalmaznak adalékanyagot és tartósítószert!", "https://images.unsplash.com/photo-1491960693564-421771d727d6?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8aGFtYnVyZ2VyfHx8fHx8MTYzMjY5MDg0Ng&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Trófea BBQ burger", 1400, 1 },
                    { 6, "10dkg marhahús (medium), karamellizált hagyma, csemegeuborka, cheddar sajt, ezersziget öntet A hamburger húspogácsák és a bucik nem tartalmaznak adalékanyagot és tartósítószert!", "https://images.unsplash.com/photo-1624348754836-743503fe9445?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8aGFtYnVyZ2VyfHx8fHx8MTYzMjY5MDgwOA&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Trófea Cheese Burger", 1250, 1 },
                    { 5, "marhahús (medium), ezersziget öntet, karamellizált hagyma, csemegeuborka A hamburger húspogácsák és a bucik nem tartalmaznak adalékanyagot és tartósítószert!", "https://images.unsplash.com/photo-1618219877887-442767be5d68?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8aGFtYnVyZ2VyfHx8fHx8MTYzMjY5MDc2MA&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Trófea Burger", 1090, 1 },
                    { 4, "További kérdés esetén, rendelésed leadása előtt keresd az ügyfélszolgálatunkat bizalommal.", "https://images.unsplash.com/photo-1583182332473-b31ba08929c8?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8ZG9udXR8fHx8fHwxNjMyNjkwNzA2&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Trófea burgonyafánk", 900, 1 },
                    { 3, "További kérdés esetén, rendelésed leadása előtt keresd az ügyfélszolgálatunkat bizalommal.", "https://images.unsplash.com/photo-1562847961-8f766d774a28?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8bWVhdHx8fHx8fDE2MzI2OTA1Njg&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Ropogós kacsacomb", 3700, 1 },
                    { 2, "További kérdés esetén, rendelésed leadása előtt keresd az ügyfélszolgálatunkat bizalommal.", "https://images.unsplash.com/photo-1518290943012-2c2bec0e54d2?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8Zm9vZCxtZWF0fHx8fHx8MTYzMjY5MDUwMQ&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Burgundi szarvasszelet", 3650, 1 },
                    { 1, "További kérdés esetén, rendelésed leadása előtt keresd az ügyfélszolgálatunkat bizalommal.", "https://images.unsplash.com/photo-1524081684693-1519036f3449?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8Zm9vZCxyZXN0YXVyYW50fHx8fHx8MTYzMjY5MDM4MA&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Libamáj pástétom házi lila hagyma lekvárral", 4750, 1 },
                    { 95, "roston sült libamáj, gomba, egri barnamártás", "https://images.unsplash.com/photo-1598511726623-d2e9996892f0?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8bG9pbnx8fHx8fDE2MzI4MjUxMzI&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Bélszínjava egri módra", 5800, 19 },
                    { 96, "Joghurtból készült házi krémsajt, marinált paprikával és sült articsókával, friss pitával tálalva", "https://images.unsplash.com/photo-1565720490528-48e5be3d6a1f?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudCxmb29kfHx8fHx8MTYzMjgyNTI2OQ&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Labane", 1890, 20 },
                    { 97, "Jemeni fűszerekkel főtt csirkeleves tépett csirkecombbal, citrommal és friss korianderrel", "https://images.unsplash.com/photo-1469307517101-0b99d8fb0c33?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8c291cHx8fHx8fDE2MzI4MjU0OTk&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Jemeni Csirkeleves", 1690, 20 },
                    { 98, "Minden hummusz tálat friss, házi hummusszal, csicseriborsóval, tahinivel, petrezselyemmel és olívaolajjal tálalunk, mellé friss grillezett pitát adunk. Kérheted zhug csipős szósszal is!", "https://images.unsplash.com/photo-1622040806062-27ae4deb4a40?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8aHVtdXN8fHx8fHwxNjMyODI1NTcy&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Humusz Tahini tál", 1890, 20 },
                    { 99, "Két fajta lencséből készült krémleves, sült padlizsán kockákkal és lime-chili mogyoróval", "https://images.unsplash.com/photo-1547308283-b74183c15032?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8c291cHx8fHx8fDE2MzI4MjU1MTk&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Vegán lencsekrémleves", 1590, 20 },
                    { 92, "szaftos, vaslapon sült karaj fokhagymával, sült szalonnával", "https://images.unsplash.com/photo-1624174503860-478619028ab3?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cG9ya3x8fHx8fDE2MzI4MjQ4OTQ&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Kishuszáros karaj", 2800, 19 },
                    { 91, "vaslapon sült pácolt karaj tejfölös, füstölt tarjás, savanyú uborkás, szalonnás raguval", "https://images.unsplash.com/photo-1605209971703-73c7ed7c923e?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cG9ya3x8fHx8fDE2MzI4MjQ4NzI&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Favágó karaj", 2800, 19 },
                    { 15, "zöldfűszeres gnocchi, zeller, kurkuma, shallot", "https://images.unsplash.com/photo-1501200291289-c5a76c232e5f?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8Y2hpY2tlbnx8fHx8fDE2MzI3NjQzNzU&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Balzsamecetben marinált csirke", 3550, 3 },
                    { 16, "brokkoli, beluga lencse, édes-savanyú redukció, friss zöldfűszerek", "https://images.unsplash.com/photo-1485704686097-ed47f7263ca4?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8c3RlYWt8fHx8fHwxNjMyNzY0NDYw&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Lazac steak", 4950, 3 },
                    { 33, "üstölt zellerpüré, padron paprika, vargányagomba", "https://images.unsplash.com/photo-1626509653291-18d9a934b9db?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8bWVhdCxwbGF0ZXx8fHx8fDE2MzI4MjM5MzM&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Bikavéres marhapofa", 4250, 7 },
                    { 86, "parajlevél pestóval és sós dióval, aszalt paradicsommal", "https://images.unsplash.com/photo-1618163633808-dbd8a9f658ce?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cGFzdGF8fHx8fHwxNjMyODI0MTUz&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Házi hosszúmetélt", 2490, 17 },
                    { 32, "roston bélszín, serpenyős cigánypecsenye, rántott csirkemell, kakastaréj, sült kockaburgonya, házi csalamádé", "https://images.unsplash.com/photo-1611315764615-3e788573f31e?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8ZGlzaHx8fHx8fDE2MzI3NzI5ODg&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Erdélyi fatányéros", 4200, 6 },
                    { 31, "grillezett libamájjal és gyümölcsökkel", "https://images.unsplash.com/photo-1467003909585-2f8a72700288?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8Zm9vZCxwbGF0ZXx8fHx8fDE2MzI3NzI0ODA&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Lávakövön sült pulykamell", 3700, 6 },
                    { 30, "sonka, főtt-füstölt tarja, téli szalámi és paprikás szalámi, baconszalonna, parasztmájas, füstölt kolbász, sajtok, főtt tojás, friss zöldségek ", "https://images.unsplash.com/photo-1432139509613-5c4255815697?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8bWVhdCxmb29kfHx8fHx8MTYzMjc3MjY1OQ&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Magyaros hidegtál", 3000, 6 },
                    { 29, "ertéscomb, csirkemáj, gomba,zöldségek - tejszínes-kapros habarással készül", "https://images.unsplash.com/photo-1574484284002-952d92456975?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8c291cHx8fHx8fDE2MzI3NzIzOTc&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Legényfogó leves", 1660, 6 },
                    { 87, "szezámmagos buci, marhahúspogácsa 1 db (13 dkg), hamburgerszósz, jégsaláta, csemege uborka, trappista sajt, pirított hagyma, bacon", "https://images.unsplash.com/photo-1623945359564-b8d01dd5cfe2?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8YnVyZ2VyfHx8fHx8MTYzMjgyNDMyNQ&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Taxi burger", 1399, 18 },
                    { 28, "füstölt saláta, boquerones", "https://images.unsplash.com/photo-1504973960431-1c467e159aa4?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8Zm9vZCxwbGF0ZXx8fHx8fDE2MzI3NzE5NzU&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Tanyasi csirke", 4990, 5 }
                });

            migrationBuilder.InsertData(
                table: "Food",
                columns: new[] { "Id", "Description", "ImagePath", "IsDeleted", "Name", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { 27, "szarvasgomba, tanyasi csirke/garnéla/bélszín", "https://images.unsplash.com/photo-1482049016688-2d3e1b311543?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudCxmb29kfHx8fHx8MTYzMjc3MTY4MA&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Házi tagliatelle", 4690, 5 },
                    { 26, "bazsalikom, stracciatella (V)", "https://images.unsplash.com/photo-1460667450797-d71a56692010?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8Zm9vZCxwbGF0ZXx8fHx8fDE2MzI3NzE4OTI&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Paradicsom rizottó", 4490, 5 },
                    { 75, "vadas, szalvétagombóc", "https://images.unsplash.com/photo-1516685125522-3c528b8046ee?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8Zm9vZCxwbGF0ZXx8fHx8fDE2MzI3NzE4NjY&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Szarvasgerinc", 6990, 15 },
                    { 25, "vadas, szalvétagombóc", "https://images.unsplash.com/photo-1516685125522-3c528b8046ee?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8Zm9vZCxwbGF0ZXx8fHx8fDE2MzI3NzE4NjY&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Szarvasgerinc", 6990, 5 },
                    { 24, "ruccolás burgonyapürével, mentás mártással, toszkán zöldbabbal", "https://images.unsplash.com/photo-1514516345957-556ca7d90a29?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8bWVhdCxwbGF0ZXx8fHx8fDE2MzI3NzEyNzk&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Vasvári zoltán féle konfitált báránycsülök", 3990, 4 },
                    { 23, "rózsaborsos-citrusos mangó pürével, savoyai burgonyával", "https://images.unsplash.com/photo-1505253668822-42074d58a7c6?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8ZHVjayxmb29kfHx8fHx8MTYzMjc3MTEzNA&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Narancsos kacsa", 3690, 4 },
                    { 22, "Ahogy katalán chef barátunktól tanultuk", "https://images.unsplash.com/photo-1575932444877-5106bee2a599?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8Q2hpY2tlbiBicmVhc3R8fHx8fHwxNjMyNzcwOTk4&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Csirkemellből készült paella", 2990, 4 },
                    { 21, "konyakos-libamájas mártással, tepertős burgonyapürével, szőlővel", "https://images.unsplash.com/photo-1504472607343-a7fac413b524?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cGxhdGV8fHx8fHwxNjMyNzcwNzkx&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Bivaly", 3790, 4 },
                    { 20, "pirított pisztáciával, citromhéjas tejszínes udon tésztával", "https://images.unsplash.com/photo-1556269923-e4ef51d69638?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8c3RlYWt8fHx8fHwxNjMyNzcwNjYx&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Beluga steak limoncelloval flambírozva", 4390, 4 },
                    { 89, "szezámmagos buci, marhahúspogácsa (13 dkg-os), BBQ szósz, jégsaláta, paradicsom, füstölt sajtchips, cheddar sajt, bacon, jalapeno", "https://images.unsplash.com/photo-1572802419224-296b0aeee0d9?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8YnVyZ2VyfHx8fHx8MTYzMjgyNDUwMg&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Rosti Burger", 1599, 18 },
                    { 90, "szezámmagos buci, marhahúspogácsa 2 db (13 dkg-os), BBQ szósz, lila hagyma, paradicsom, kígyóuborka, cheddar sajt, füstölt sajt, trappista sajt, bacon, jalapeno", "https://images.unsplash.com/photo-1561043433-9265f73e685f?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8YnVyZ2VyfHx8fHx8MTYzMjgyNDYwMQ&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Zátony Burger", 1899, 18 },
                    { 19, "menta, spárga ragu, pecorino, narancs", "https://images.unsplash.com/photo-1613478881426-deeadee06d78?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8ZWdncGxhbnR8fHx8fHwxNjMyNzY0OTg1&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Füstölt padlizsán tortelli", 3250, 3 },
                    { 18, "(220 g), rukkola, grana padano d.o.p., koktélparadicsom", "https://images.unsplash.com/photo-1607198179219-cd8b835fdda7?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8c3RlYWt8fHx8fHwxNjMyNzY0ODA2&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Rib-eye", 7650, 3 },
                    { 17, "grillezett füge, szója emulzió, retek", "https://images.unsplash.com/photo-1601565960311-8a7f4e1ab709?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cGFwcmlrYXx8fHx8fDE2MzI3NjQ2ODg&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Vegán csőben sült kaliforniai paprika", 2950, 3 },
                    { 88, "szezámmagos buci, marhahús pogácsa 1 db (13 dkg), ketchup, jégsaláta, kígyóuborka, pirított hagyma, bacon, jalapeno", "https://images.unsplash.com/photo-1585238341267-1cfec2046a55?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8YnVyZ2VyfHx8fHx8MTYzMjgyNDQxOQ&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Erős Anna", 1399, 18 },
                    { 76, "bazsalikom, stracciatella (V)", "https://images.unsplash.com/photo-1460667450797-d71a56692010?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8Zm9vZCxwbGF0ZXx8fHx8fDE2MzI3NzE4OTI&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800", false, "Paradicsom rizottó", 4490, 15 }
                });

            migrationBuilder.InsertData(
                table: "Invoice",
                columns: new[] { "Id", "OrderId", "RestaurantName", "UserFullName", "RestaurantAddress_City", "RestaurantAddress_PhoneNumber", "RestaurantAddress_Street", "RestaurantAddress_ZipCode", "UserAddress_City", "UserAddress_PhoneNumber", "UserAddress_Street", "UserAddress_ZipCode" },
                values: new object[,]
                {
                    { 1, 1, "Trófea Grill Étterem - Király", "Carson Alexander", "Budapest", "06301234567", "Király utca 30", 1061, "Budapest", "06201214561", "Kossuth utca 30", 1060 },
                    { 2, 2, "Trófea Grill Étterem - Király", "Carson Alexander", "Budapest", "06301234567", "Király utca 30", 1061, "Budapest", "06201214561", "Kossuth utca 30", 1060 },
                    { 3, 3, "Trófea Grill Étterem - Király", "Carson Alexander", "Budapest", "06301234567", "Király utca 30", 1061, "Budapest", "06201214561", "Kossuth utca 30", 1060 },
                    { 4, 4, "Trófea Grill Étterem - Király", "Carson Alexander", "Budapest", "06301234567", "Király utca 30", 1061, "Budapest", "06201214561", "Kossuth utca 30", 1060 },
                    { 5, 5, "Princess Bakery&Bistro Örs vezér tér", "Carson Alexander", "Budapest", "06305412567", "Örs vezér tere 1", 1148, "Budapest", "06201214561", "Kossuth utca 30", 1060 },
                    { 6, 6, "Twentysix Budapest", "Carson Alexander", "Budapest", "06301233456", "Király utca 26", 1011, "Budapest", "06201214561", "Kossuth utca 30", 1060 }
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "Id", "CreatedAt", "Description", "Rating", "RestaurantId", "Title", "UserId" },
                values: new object[,]
                {
                    { 11, new DateTime(2021, 9, 8, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(3302), "Összességében azt mondhatom, igazán remek, kiváló ár - érték arányú ebédet hoztak össze.Szívesen jövünk még újabb finomságokat kóstolni.", 4.0999999999999996, 13, "Kiváló ár-érték arány", "cb35b922-5a91-4949-94e6-47a2d6f82d93" },
                    { 22, new DateTime(2021, 7, 30, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(3334), "Megérkezdtünk. Nem kisértek az asztalunkhoz, azt mondták, üljünk ahová akarunk. Majd 10 percen keresztül a kutya sem szòlt hozzánk. Akkor megkérdeztük, hogy mikor veszik fel legalább az italrendelést, azt mondták rögtön. Újabb 5 perc után, mivel senki sem jött az asztalunkhoz, távoztunk. Senki nem kérdezte meg, hogy miért megyünk el. Az étlap, amit más asztalokon láttunk, gyürött ès koszos volt. A pincèrnö ruhàja àpolatlan. Senkinek nem ajànlom a helyet. ", 2.0, 19, "Nem ajánlom", "6c364ea9-44b4-4726-9bef-ea83c375e761" },
                    { 1, new DateTime(2021, 7, 30, 17, 19, 53, 12, DateTimeKind.Local).AddTicks(1314), "Ízletes fogások, kiváló kiszolgálás.", 5.0, 1, "Nagyon ajánlom", "475c5e32-049c-4d7b-a963-02ebdc15a94b" },
                    { 2, new DateTime(2021, 8, 29, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(3169), "Remek hely, de a pincérek egy kicsit túl voltak terhelve, a hétköznap délutáni teltház persze nem segített a helyzeten. Tavasszal a lezárások alatt egy vendégre 3 felszolgáló jutott, az jobban tetszett. :D.", 4.5, 1, "Remek hely", "cb35b922-5a91-4949-94e6-47a2d6f82d93" },
                    { 3, new DateTime(2021, 8, 29, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(3207), "Kellemes hely. Olyan hely, ahol a legjobb ételek és borok mellett önfeledten beszélgethetsz barátaiddal . Az alaphangszint (vagy inkább zaj) kicsit szokatlan lehet, de viszonylag könnyen hozzá lehet szokni. A felszolgálás ugyanolyan fesztelen, mint maga a hely. ", 4.2000000000000002, 2, "Kellemes hely", "475c5e32-049c-4d7b-a963-02ebdc15a94b" },
                    { 4, new DateTime(2021, 8, 29, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(3277), "Remek hely, de a pincérek egy kicsit túl voltak terhelve, a hétköznap délutáni teltház persze nem segített a helyzeten. Tavasszal a lezárások alatt egy vendégre 3 felszolgáló jutott, az jobban tetszett. :D.", 4.5, 2, "Remek hely", "cb35b922-5a91-4949-94e6-47a2d6f82d93" },
                    { 21, new DateTime(2021, 9, 8, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(3331), "Bár az előétel és a desszert remek volt, a többi fogás nem varázsolt el. Kicsit olyan érzésem volt, hogy ennek az étteremnek nagyobb a füstje, mint a lángja. Átlagon felüli, de nem hibátlan. Többet vártam.", 3.7999999999999998, 18, "Átlagon felüli, de nem hibátlan", "6c364ea9-44b4-4726-9bef-ea83c375e761" },
                    { 5, new DateTime(2021, 8, 9, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(3282), "Itt az étkezés nem kizárólag étkezés, sokkal inkább egy különleges szertartás. A kiszolgálás másodpercre pontosan kiszámolt, mérnöki pontosságú.", 4.7000000000000002, 3, "Több mint étkezés", "475c5e32-049c-4d7b-a963-02ebdc15a94b" },
                    { 20, new DateTime(2021, 9, 8, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(3328), "Bár az előétel és a desszert remek volt, a többi fogás nem varázsolt el. Kicsit olyan érzésem volt, hogy ennek az étteremnek nagyobb a füstje, mint a lángja. Átlagon felüli, de nem hibátlan. Többet vártam.", 3.8999999999999999, 14, "Átlagon felüli, de nem hibátlan", "6c364ea9-44b4-4726-9bef-ea83c375e761" },
                    { 6, new DateTime(2021, 8, 29, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(3285), "Remek hely, de a pincérek egy kicsit túl voltak terhelve, a hétköznap délutáni teltház persze nem segített a helyzeten. Tavasszal a lezárások alatt egy vendégre 3 felszolgáló jutott, az jobban tetszett. :D.", 4.2000000000000002, 3, "Remek hely", "cb35b922-5a91-4949-94e6-47a2d6f82d93" },
                    { 19, new DateTime(2021, 9, 8, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(3325), "Bár az előétel és a desszert remek volt, a többi fogás nem varázsolt el. Kicsit olyan érzésem volt, hogy ennek az étteremnek nagyobb a füstje, mint a lángja. Átlagon felüli, de nem hibátlan. Többet vártam.", 4.0, 5, "Átlagon felüli, de nem hibátlan", "6c364ea9-44b4-4726-9bef-ea83c375e761" },
                    { 17, new DateTime(2021, 9, 8, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(3320), "Egy friss, fiatalos, üde étterem, ez a szemlélet, lendület visszaköszön ételeiken is. Akár déli, akár esti ajánlatra térsz be, nem fogsz csalódni; remek ár-érték arányú hely. Viszont ha jól szeretnél lakni, nem ez a számodra megfelelő hely. Az ételek bár ízletesek, az adagok kicsik. .", 3.3999999999999999, 17, "Ízléses, de kis adagok", "0bf93af4-1769-49f8-9bf4-e977feef94b4" },
                    { 23, new DateTime(2021, 8, 19, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(3337), "Érdemes megkóstolni a különböző finomságokat, igazán jó konyhát visznek. Az ételeik kifinomultak, harmonikusak, mondjuk nem az a hely, ahol tele fogod enni magad - de nem is ez a cél.", 4.2000000000000002, 6, "Kifinomult, harmonikus ételek", "fef0a15c-42bb-4f2d-9a65-382d4d95f667" },
                    { 24, new DateTime(2021, 8, 19, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(3340), "Érdemes megkóstolni a különböző finomságokat, igazán jó konyhát visznek. Az ételeik kifinomultak, harmonikusak, mondjuk nem az a hely, ahol tele fogod enni magad - de nem is ez a cél.", 4.2999999999999998, 7, "Kifinomult, harmonikus ételek", "fef0a15c-42bb-4f2d-9a65-382d4d95f667" },
                    { 14, new DateTime(2021, 9, 8, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(3311), "Egy friss, fiatalos, üde étterem, ez a szemlélet, lendület visszaköszön ételeiken is. Akár déli, akár esti ajánlatra térsz be, nem fogsz csalódni; remek ár-érték arányú hely. Viszont ha jól szeretnél lakni, nem ez a számodra megfelelő hely. Az ételek bár ízletesek, az adagok kicsik. .", 3.7000000000000002, 8, "Ízléses, de kis adagok", "0bf93af4-1769-49f8-9bf4-e977feef94b4" },
                    { 15, new DateTime(2021, 9, 8, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(3313), "Egy friss, fiatalos, üde étterem, ez a szemlélet, lendület visszaköszön ételeiken is. Akár déli, akár esti ajánlatra térsz be, nem fogsz csalódni; remek ár-érték arányú hely. Viszont ha jól szeretnél lakni, nem ez a számodra megfelelő hely. Az ételek bár ízletesek, az adagok kicsik. .", 3.5, 9, "Ízléses, de kis adagok", "0bf93af4-1769-49f8-9bf4-e977feef94b4" },
                    { 16, new DateTime(2021, 9, 8, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(3317), "Egy friss, fiatalos, üde étterem, ez a szemlélet, lendület visszaköszön ételeiken is. Akár déli, akár esti ajánlatra térsz be, nem fogsz csalódni; remek ár-érték arányú hely. Viszont ha jól szeretnél lakni, nem ez a számodra megfelelő hely. Az ételek bár ízletesek, az adagok kicsik. .", 3.6000000000000001, 16, "Ízléses, de kis adagok", "0bf93af4-1769-49f8-9bf4-e977feef94b4" },
                    { 7, new DateTime(2021, 9, 8, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(3288), "Összességében azt mondhatom, igazán remek, kiváló ár - érték arányú ebédet hoztak össze.Szívesen jövünk még újabb finomságokat kóstolni.", 4.5, 10, "Kiváló ár-érték arány", "475c5e32-049c-4d7b-a963-02ebdc15a94b" },
                    { 8, new DateTime(2021, 8, 29, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(3291), "Remek hely, de a pincérek egy kicsit túl voltak terhelve, a hétköznap délutáni teltház persze nem segített a helyzeten. Tavasszal a lezárások alatt egy vendégre 3 felszolgáló jutott, az jobban tetszett. :D.", 4.0999999999999996, 10, "Remek hely", "cb35b922-5a91-4949-94e6-47a2d6f82d93" },
                    { 9, new DateTime(2021, 9, 8, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(3294), "Összességében azt mondhatom, igazán remek, kiváló ár - érték arányú ebédet hoztak össze.Szívesen jövünk még újabb finomságokat kóstolni.", 4.0, 11, "Kiváló ár-érték arány", "cb35b922-5a91-4949-94e6-47a2d6f82d93" }
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "Id", "CreatedAt", "Description", "Rating", "RestaurantId", "Title", "UserId" },
                values: new object[,]
                {
                    { 10, new DateTime(2021, 9, 8, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(3298), "Összességében azt mondhatom, igazán remek, kiváló ár - érték arányú ebédet hoztak össze.Szívesen jövünk még újabb finomságokat kóstolni.", 3.8999999999999999, 12, "Kiváló ár-érték arány", "cb35b922-5a91-4949-94e6-47a2d6f82d93" },
                    { 12, new DateTime(2021, 9, 8, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(3305), "Összességében azt mondhatom, igazán remek, kiváló ár - érték arányú ebédet hoztak össze.Szívesen jövünk még újabb finomságokat kóstolni.", 3.7999999999999998, 15, "Kiváló ár-érték arány", "cb35b922-5a91-4949-94e6-47a2d6f82d93" },
                    { 18, new DateTime(2021, 9, 8, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(3322), "Bár az előétel és a desszert remek volt, a többi fogás nem varázsolt el. Kicsit olyan érzésem volt, hogy ennek az étteremnek nagyobb a füstje, mint a lángja. Átlagon felüli, de nem hibátlan. Többet vártam.", 4.0999999999999996, 4, "Átlagon felüli, de nem hibátlan", "6c364ea9-44b4-4726-9bef-ea83c375e761" },
                    { 13, new DateTime(2021, 9, 18, 17, 19, 53, 15, DateTimeKind.Local).AddTicks(3308), "Megérkezdtünk. Nem kisértek az asztalunkhoz, azt mondták, üljünk ahová akarunk. Majd 10 percen keresztül a kutya sem szòlt hozzánk. Akkor megkérdeztük, hogy mikor veszik fel legalább az italrendelést, azt mondták rögtön. Újabb 5 perc után, mivel senki sem jött az asztalunkhoz, távoztunk. Senki nem kérdezte meg, hogy miért megyünk el. Az étlap, amit más asztalokon láttunk, gyürött ès koszos volt. A pincèrnö ruhàja àpolatlan. Senkinek nem ajànlom a helyet.", 1.8999999999999999, 20, "Nem ajánlom", "cb35b922-5a91-4949-94e6-47a2d6f82d93" }
                });

            migrationBuilder.InsertData(
                table: "OrderFood",
                columns: new[] { "Id", "Amount", "FoodId", "OrderId", "Price" },
                values: new object[,]
                {
                    { 1, 3, 1, 1, 4750 },
                    { 22, 2, 16, 6, 4950 },
                    { 21, 1, 15, 6, 3550 },
                    { 20, 1, 12, 5, 2190 },
                    { 19, 4, 11, 5, 2190 },
                    { 18, 2, 10, 5, 2390 },
                    { 17, 3, 9, 5, 2490 },
                    { 13, 2, 7, 4, 1400 },
                    { 14, 2, 6, 4, 1250 },
                    { 10, 2, 6, 3, 1250 },
                    { 9, 1, 5, 3, 1090 },
                    { 16, 1, 4, 4, 900 },
                    { 12, 1, 4, 3, 900 },
                    { 8, 1, 4, 2, 900 },
                    { 4, 1, 4, 1, 900 },
                    { 15, 4, 3, 4, 3700 },
                    { 11, 4, 3, 3, 3700 },
                    { 7, 4, 3, 2, 3700 },
                    { 3, 4, 3, 1, 3700 },
                    { 6, 2, 2, 2, 3650 },
                    { 2, 2, 2, 1, 3650 },
                    { 5, 1, 1, 2, 4750 },
                    { 23, 1, 17, 6, 2950 },
                    { 24, 2, 18, 6, 7650 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "g8aceb4d-b534-459e-8c4e-d13374f43b65", "0bf93af4-1769-49f8-9bf4-e977feef94b4" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "rc95a82e-0abc-4d85-9877-4184177c3a7f", "27410ef4-fa83-45cd-872d-d350042dd8e4" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "rc95a82e-0abc-4d85-9877-4184177c3a7f", "3eba4364-6a33-459c-9871-5823a9aee62a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "rc95a82e-0abc-4d85-9877-4184177c3a7f", "4422d2ba-934c-4899-9195-d9872d1b4c63" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "g8aceb4d-b534-459e-8c4e-d13374f43b65", "475c5e32-049c-4d7b-a963-02ebdc15a94b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "rc95a82e-0abc-4d85-9877-4184177c3a7f", "4e0a018f-ca12-448e-bda9-67ac1fce5a53" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "rc95a82e-0abc-4d85-9877-4184177c3a7f", "5075d4b9-0ba6-4811-84ff-fed147c9c09a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "rc95a82e-0abc-4d85-9877-4184177c3a7f", "512dac39-94d2-429a-a258-7740ca64c50f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "rc95a82e-0abc-4d85-9877-4184177c3a7f", "5b944a67-5751-423f-89fb-f0c4f0ace3fb" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "rc95a82e-0abc-4d85-9877-4184177c3a7f", "5c55f164-cb41-4453-a473-120af44e3493" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "rc95a82e-0abc-4d85-9877-4184177c3a7f", "5f7e27c3-9398-4cd3-977d-dae625124808" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "g8aceb4d-b534-459e-8c4e-d13374f43b65", "6c364ea9-44b4-4726-9bef-ea83c375e761" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "rc95a82e-0abc-4d85-9877-4184177c3a7f", "7236dae3-7bad-4fe6-bb18-d13ff391939d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "rc95a82e-0abc-4d85-9877-4184177c3a7f", "765c13fb-7f8c-4474-afb5-d3a9e72feef3" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "rc95a82e-0abc-4d85-9877-4184177c3a7f", "77d8c466-d2a0-44cb-8a22-a228b6218f23" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "rc95a82e-0abc-4d85-9877-4184177c3a7f", "8480bf9e-9553-47b7-a57b-474715139a83" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "rc95a82e-0abc-4d85-9877-4184177c3a7f", "93f49281-b3a5-41b5-972c-ff5910f26e56" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "rc95a82e-0abc-4d85-9877-4184177c3a7f", "95810441-4970-488c-afc7-d91a07256c76" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "rc95a82e-0abc-4d85-9877-4184177c3a7f", "96494a5b-f58d-44dd-8428-6543ef5e5bd7" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "rc95a82e-0abc-4d85-9877-4184177c3a7f", "acd5d503-90e3-475c-b700-8e96fbea9e60" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "rc95a82e-0abc-4d85-9877-4184177c3a7f", "bc803e89-e8c0-4c5a-9467-e94cd5dd0300" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "rc95a82e-0abc-4d85-9877-4184177c3a7f", "c5e189f0-7656-4304-b963-1581f5ecf4fb" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "g8aceb4d-b534-459e-8c4e-d13374f43b65", "cb35b922-5a91-4949-94e6-47a2d6f82d93" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "rc95a82e-0abc-4d85-9877-4184177c3a7f", "e1eaafad-b9f7-4668-9efd-d8c4418c39ca" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "g8aceb4d-b534-459e-8c4e-d13374f43b65", "fef0a15c-42bb-4f2d-9a65-382d4d95f667" });

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Invoice",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "OrderFood",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "UserAddress",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserAddress",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserAddress",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserAddress",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserAddress",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "g8aceb4d-b534-459e-8c4e-d13374f43b65");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "rc95a82e-0abc-4d85-9877-4184177c3a7f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0bf93af4-1769-49f8-9bf4-e977feef94b4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6c364ea9-44b4-4726-9bef-ea83c375e761");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb35b922-5a91-4949-94e6-47a2d6f82d93");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fef0a15c-42bb-4f2d-9a65-382d4d95f667");

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27410ef4-fa83-45cd-872d-d350042dd8e4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3eba4364-6a33-459c-9871-5823a9aee62a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4422d2ba-934c-4899-9195-d9872d1b4c63");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "475c5e32-049c-4d7b-a963-02ebdc15a94b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4e0a018f-ca12-448e-bda9-67ac1fce5a53");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5075d4b9-0ba6-4811-84ff-fed147c9c09a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5b944a67-5751-423f-89fb-f0c4f0ace3fb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5c55f164-cb41-4453-a473-120af44e3493");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5f7e27c3-9398-4cd3-977d-dae625124808");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7236dae3-7bad-4fe6-bb18-d13ff391939d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "765c13fb-7f8c-4474-afb5-d3a9e72feef3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "77d8c466-d2a0-44cb-8a22-a228b6218f23");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93f49281-b3a5-41b5-972c-ff5910f26e56");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "95810441-4970-488c-afc7-d91a07256c76");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "96494a5b-f58d-44dd-8428-6543ef5e5bd7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "acd5d503-90e3-475c-b700-8e96fbea9e60");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c5e189f0-7656-4304-b963-1581f5ecf4fb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e1eaafad-b9f7-4668-9efd-d8c4418c39ca");

            migrationBuilder.DeleteData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "512dac39-94d2-429a-a258-7740ca64c50f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8480bf9e-9553-47b7-a57b-474715139a83");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bc803e89-e8c0-4c5a-9467-e94cd5dd0300");
        }
    }
}
