using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UpSchool.Domain.Entities;

namespace UpSchool.Persistance.EntityFramework.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        //Veritabani configlerini burada yapariz
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            //ID --> bu alanlar unique
            builder.HasKey(x => x.Id);

            //Title
            builder.Property(x => x.Title).IsRequired();  
            builder.Property(x => x.Title).HasMaxLength(150);

            //UserName
            builder.Property(x => x.UserName).IsRequired();  
            builder.Property(x => x.UserName).HasMaxLength(100);

            //Password
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(100);

            //Url
            builder.Property(x => x.Url).IsRequired(false); //zorunlu olmayan alanlarda false degeri veririz
            builder.Property(x => x.Url).HasMaxLength(100);

            //IsFavourite
            builder.Property(x => x.IsFavourite).IsRequired();

            //CreatedOn
            builder.Property(x => x.CreatedOn).IsRequired();

            //LastModifiedOn
            builder.Property(x => x.LastModifiedOn).IsRequired(false);

            //Olusturulan tablo adi
            builder.ToTable("Accounts");
        }
    }
}
