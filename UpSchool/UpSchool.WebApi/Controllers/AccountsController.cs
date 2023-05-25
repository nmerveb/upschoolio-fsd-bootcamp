﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using UpSchool.Domain.Dtos;
using UpSchool.Domain.Entities;
using UpSchool.Domain.Utilities;
using UpSchool.Persistance.EntityFramework.Contexts;
using UpSchool.WebApi.Hubs;

namespace UpSchool.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly  IMapper _mapper;
        private readonly UpStorageDbContext _dbContext;
        private readonly IHubContext<AccountsHub> _accountsHubContext;

        public AccountsController(IMapper mapper, UpStorageDbContext dbContext, IHubContext<AccountsHub> accountsHubContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _accountsHubContext = accountsHubContext;
        }
        
        [HttpGet]
        public IActionResult GetAll(bool isAscending, string? searchKeyword)
        {
            //Queryable yuku db'ye birakir.
            IQueryable<Account> accountsQuery = _dbContext.Accounts.AsQueryable(); //Veritabaniyla bir kopru olusturmayi saglar, verdigimiz islemleri sirasiyla veritabani uzerinde gerceklestirir.

            if(!string.IsNullOrEmpty(searchKeyword))
            {
                accountsQuery = accountsQuery.Where(x => x.Title.Contains(searchKeyword) || x.UserName.Contains(searchKeyword));
            }
            
            accountsQuery = isAscending? accountsQuery.OrderBy(x => x.Title) : accountsQuery.OrderByDescending(x => x.Title);

            var accounts = accountsQuery.ToList(); //islemleri birlestirip db'ye gondermis gibi dusunebilirsin.

            #region Query olusturmadan once
            //var accounts = string.IsNullOrEmpty(searchKeyword)
            //    ? 
            //    _dbContext
            //        .Accounts
            //        .ToList()
            //    : 
            //    _dbContext
            //        .Accounts
            //         .Where(x => x.Title.Contains(searchKeyword) || x.UserName.Contains(searchKeyword)) //bu gibi sorgularda 2 syi birlikte aradigimizda birinin indexlenmesi digeri indexlenmediyse performansi artttirmayi saglamayacaktir.
            //         //Bu nedenle composite keys kullaniriz.
            //         .ToList();
            #endregion

            var accountDtos = accounts.Select(account => AccountDto.MapFromAccount(account)); //Automapper performans yiyor?

  
            return Ok(accountDtos);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            var account = _dbContext.Accounts.FirstOrDefault(x=>x.Id == id);

            if(account is null) return NotFound("The selected account was not found");

            return Ok(AccountDto.MapFromAccount(account));
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AccountAddDto accountAddDto, CancellationToken cancellationToken)
        {
            var account = new Account()
            {
                Id = Guid.NewGuid(),
                Title = accountAddDto.Title,
                UserName = accountAddDto.UserName,
                Password = accountAddDto.Password,
                IsFavourite= accountAddDto.IsFavourite,
                CreatedOn = DateTimeOffset.Now,
                Url = accountAddDto.Url,
            }; 
  
            await _dbContext.Accounts.AddAsync(account);
            await _dbContext.SaveChangesAsync();
            
            var accountDto = AccountDto.MapFromAccount(account);

            await _accountsHubContext.Clients.AllExcept(accountAddDto.ConnectionId).SendAsync(SignalRMethodKeys.Accounts.Added, accountDto, cancellationToken);

            return Ok(accountDto);
        }

        [HttpPut]
        public  IActionResult Edit(AccountEditDto accountEditDto)
        {
            //var accountIndex = _accounts.FindIndex(x => x.Id == accountEditDto.Id);
            var account = _dbContext.Accounts.FirstOrDefault(x => x.Id == accountEditDto.Id);

            if (account is null) return NotFound("The selected account was not found");

            var updatedAccount = _mapper.Map<AccountEditDto, Account>(accountEditDto, account); //Map<Hangi tipe donusecek>(Ne donusecek)

            _dbContext.Accounts.Update(updatedAccount);
            _dbContext.SaveChanges();

            return Ok(_mapper.Map<AccountDto>(updatedAccount));
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var account = _dbContext.Accounts.FirstOrDefault(x => x.Id == id);

            if(account is null)
            {
                return NotFound("The selected account was not found. ");
            }

            _dbContext.Accounts.Remove(account);
            _dbContext.SaveChanges();

            return NoContent();
        }
    }

    
}

