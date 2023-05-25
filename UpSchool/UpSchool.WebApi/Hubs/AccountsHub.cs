using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using UpSchool.Domain.Utilities;
using UpSchool.Persistance.EntityFramework.Contexts;

namespace UpSchool.WebApi.Hubs
{
    public class AccountsHub:Hub
    {
        //aplication tarafindan service /repository cagirarak da bu islem yapilabilir.
        private readonly UpStorageDbContext _dbContext;

        public AccountsHub(UpStorageDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Fe tarafindan cagirabilecegimiz fonksiyonlari burada yazariz.
        public async Task<bool> DeleteAsync(Guid accountId)
        {
            var account = await _dbContext.Accounts.FirstOrDefaultAsync(x => x.Id == accountId);

            if (account is null) return false;

            _dbContext.Accounts.Remove(account);

            await _dbContext.SaveChangesAsync();

            await Clients.AllExcept(Context.ConnectionId).SendAsync(SignalRMethodKeys.Accounts.Deleted, accountId);

            return true;
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
