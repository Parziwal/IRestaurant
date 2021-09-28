using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace IRestaurant.DAL.Data.EntityTypeConfigurations
{
    public class UserRolesSeedConfig : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    UserId = "475c5e32-049c-4d7b-a963-02ebdc15a94b",
                    RoleId = "g8aceb4d-b534-459e-8c4e-d13374f43b65"
                },
                new IdentityUserRole<string>
                {
                    UserId = "512dac39-94d2-429a-a258-7740ca64c50f",
                    RoleId = "rc95a82e-0abc-4d85-9877-4184177c3a7f"
                },
                new IdentityUserRole<string>
                {
                    UserId = "cb35b922-5a91-4949-94e6-47a2d6f82d93",
                    RoleId = "g8aceb4d-b534-459e-8c4e-d13374f43b65"
                },
                new IdentityUserRole<string>
                {
                    UserId = "0bf93af4-1769-49f8-9bf4-e977feef94b4",
                    RoleId = "g8aceb4d-b534-459e-8c4e-d13374f43b65"
                },
                new IdentityUserRole<string>
                {
                    UserId = "6c364ea9-44b4-4726-9bef-ea83c375e761",
                    RoleId = "g8aceb4d-b534-459e-8c4e-d13374f43b65"
                },
                new IdentityUserRole<string>
                {
                    UserId = "fef0a15c-42bb-4f2d-9a65-382d4d95f667",
                    RoleId = "g8aceb4d-b534-459e-8c4e-d13374f43b65"
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
                },
                new IdentityUserRole<string>
                {
                    UserId = "95810441-4970-488c-afc7-d91a07256c76",
                    RoleId = "rc95a82e-0abc-4d85-9877-4184177c3a7f"
                },
                new IdentityUserRole<string>
                {
                    UserId = "c5e189f0-7656-4304-b963-1581f5ecf4fb",
                    RoleId = "rc95a82e-0abc-4d85-9877-4184177c3a7f"
                },
                new IdentityUserRole<string>
                {
                    UserId = "3eba4364-6a33-459c-9871-5823a9aee62a",
                    RoleId = "rc95a82e-0abc-4d85-9877-4184177c3a7f"
                },
                new IdentityUserRole<string>
                {
                    UserId = "765c13fb-7f8c-4474-afb5-d3a9e72feef3",
                    RoleId = "rc95a82e-0abc-4d85-9877-4184177c3a7f"
                },
                new IdentityUserRole<string>
                {
                    UserId = "7236dae3-7bad-4fe6-bb18-d13ff391939d",
                    RoleId = "rc95a82e-0abc-4d85-9877-4184177c3a7f"
                },
                new IdentityUserRole<string>
                {
                    UserId = "5075d4b9-0ba6-4811-84ff-fed147c9c09a",
                    RoleId = "rc95a82e-0abc-4d85-9877-4184177c3a7f"
                },
                new IdentityUserRole<string>
                {
                    UserId = "e1eaafad-b9f7-4668-9efd-d8c4418c39ca",
                    RoleId = "rc95a82e-0abc-4d85-9877-4184177c3a7f"
                },
                new IdentityUserRole<string>
                {
                    UserId = "5f7e27c3-9398-4cd3-977d-dae625124808",
                    RoleId = "rc95a82e-0abc-4d85-9877-4184177c3a7f"
                },
                new IdentityUserRole<string>
                {
                    UserId = "93f49281-b3a5-41b5-972c-ff5910f26e56",
                    RoleId = "rc95a82e-0abc-4d85-9877-4184177c3a7f"
                },
                new IdentityUserRole<string>
                {
                    UserId = "4e0a018f-ca12-448e-bda9-67ac1fce5a53",
                    RoleId = "rc95a82e-0abc-4d85-9877-4184177c3a7f"
                },
                new IdentityUserRole<string>
                {
                    UserId = "77d8c466-d2a0-44cb-8a22-a228b6218f23",
                    RoleId = "rc95a82e-0abc-4d85-9877-4184177c3a7f"
                },
                new IdentityUserRole<string>
                {
                    UserId = "5b944a67-5751-423f-89fb-f0c4f0ace3fb",
                    RoleId = "rc95a82e-0abc-4d85-9877-4184177c3a7f"
                },
                new IdentityUserRole<string>
                {
                    UserId = "96494a5b-f58d-44dd-8428-6543ef5e5bd7",
                    RoleId = "rc95a82e-0abc-4d85-9877-4184177c3a7f"
                },
                new IdentityUserRole<string>
                {
                    UserId = "5c55f164-cb41-4453-a473-120af44e3493",
                    RoleId = "rc95a82e-0abc-4d85-9877-4184177c3a7f"
                },
                new IdentityUserRole<string>
                {
                    UserId = "27410ef4-fa83-45cd-872d-d350042dd8e4",
                    RoleId = "rc95a82e-0abc-4d85-9877-4184177c3a7f"
                },
                new IdentityUserRole<string>
                {
                    UserId = "acd5d503-90e3-475c-b700-8e96fbea9e60",
                    RoleId = "rc95a82e-0abc-4d85-9877-4184177c3a7f"
                },
                new IdentityUserRole<string>
                {
                    UserId = "4422d2ba-934c-4899-9195-d9872d1b4c63",
                    RoleId = "rc95a82e-0abc-4d85-9877-4184177c3a7f"
                }
            );
        }
    }
}
