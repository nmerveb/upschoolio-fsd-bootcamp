using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations.Application
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            //Relationships
            //Bire cok
            //builder.HasOne<Country>(x => x.Country)
            //    .WithMany(x => x.Cities)
            //    .HasForeignKey(x => x.CountryId);
        }
    }
}
