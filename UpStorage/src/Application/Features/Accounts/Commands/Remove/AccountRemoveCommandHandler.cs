using Application.Common.Interfaces;
using Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Accounts.Commands.Remove
{
    public class AccountRemoveCommandHandler : IRequestHandler<AccountRemoveCommand, Response<Guid>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IAccountHubService _accountHubService;
        //LOCALIZER
        //private readonly IStringLocalzer _stringLocalzer;

        public AccountRemoveCommandHandler(IApplicationDbContext applicationDbContext, IAccountHubService accountHubService)
        {
            _applicationDbContext = applicationDbContext;
            _accountHubService = accountHubService;
        }
        public async Task<Response<Guid>> Handle(AccountRemoveCommand request, CancellationToken cancellationToken)
        {
            var account = await _applicationDbContext.Accounts
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            _applicationDbContext.Accounts.Remove(account);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            await _accountHubService.RemovedAsync(request.Id, cancellationToken);

            //LOCALIZER -->Common localization keys kismina da ekleme yapildi.
            //return new Response<Guid>(_localizer[CommonLocalizationKeys.HandlerMessage.Delete],request.Id);
            return new Response<Guid>("HandlerDelete",request.Id);
        }
    }
}
