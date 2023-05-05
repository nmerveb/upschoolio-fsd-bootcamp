using Domain.Entities;
using Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Application
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            //Enum maplemek addresstype enum olarak tutulur ama int olarak db'ye yazilir.
            builder.Property(x => x.AddressType).IsRequired();
            builder.Property(x => x.AddressType).HasConversion<int>();

            //Relationships
            builder.HasOne<User>().WithMany()
                .HasForeignKey(x => x.UserId);
        }
    }
}
