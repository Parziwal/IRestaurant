using IRestaurant.DAL.Models;
using IRestaurant.Test.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.Test.Data.EntityTypeConfigurations
{
    public class TestApplicationUserSeedConfig : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(TestSeedService.Users);
        }
    }
}
