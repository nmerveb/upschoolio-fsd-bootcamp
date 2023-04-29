using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UpSchool.Domain.Dtos;
using UpSchool.Domain.Entities;
using UpSchool.Domain.Utilities;
using UpSchool.Persistance.EntityFramework.Contexts;

namespace UpSchool.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly  IMapper _mapper;
        private readonly UpStorageDbContext _dbContext;

        public AccountsController(IMapper mapper, UpStorageDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        
        [HttpGet]
        public IActionResult GetAll(string? searchKeyword)
        {
            var accounts = string.IsNullOrEmpty(searchKeyword)
                ? 
                _dbContext
                    .Accounts
                    .ToList()
                : 
                _dbContext
                    .Accounts
                     .Where(x => x.Title.Contains(searchKeyword))
                     .ToList();

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
        public IActionResult Add(AccountAddDto accountAddDto)
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
  
            _dbContext.Accounts.Add(account);
            _dbContext.SaveChanges();

            return Ok(AccountDto.MapFromAccount(account));
        }

        [HttpPut]
        public IActionResult Edit(AccountEditDto accountEditDto)
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

