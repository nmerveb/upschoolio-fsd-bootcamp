using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext
    {
        public DbSet<Account> Accounts { get; set; }
    }
}
