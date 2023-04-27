using Microsoft.EntityFrameworkCore;
using UpSchool.Domain.Entities;
using UpSchool.Persistance.EntityFramework.Configurations;

namespace UpSchool.Persistance.EntityFramework.Contexts
{
    //Contextleri tablolarin bulundugu obje gibi duusnebilirsin.
    public  class UpStorageDbContext:DbContext
    {
        public DbSet<Account>  Accounts { get; set; } //Tablo adi

        public UpStorageDbContext(DbContextOptions<UpStorageDbContext> options):base(options)
        {
            
        }

        //Tablo olusturulurken Config icine yazdigimiz configlerin dikkate alinmasini soyledigimiz kisim
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());

            base.OnModelCreating(modelBuilder);
        }


    }
}
