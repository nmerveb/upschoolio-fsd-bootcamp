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

        //private static List<Account> _accounts = new()
        //{
        //    new Account()
        //    {
        //        Id = new Guid("508f233c-52cc-4ac0-ba07-4ef5a2b066ed"),
        //        UserName = "mrpickle",
        //        Password = StringHelper.Base64Encode("123pickle123"),
        //        IsFavourite = false,
        //        CreatedOn = DateTimeOffset.Now,
        //        Title = "UpSchool",
        //        Url = "https://www.upschool.com"
        //     },

        //    new Account()
        //    {
        //        Id = new Guid("94fe5cb4-2667-4c3b-9fd4-9d70c16c60fa"),
        //        UserName = "fullspeed@gmail.com",
        //        Password = StringHelper.Base64Encode("123fullspeed123"),
        //        IsFavourite = true,
        //        CreatedOn = DateTimeOffset.Now,
        //        Title = "Gmail",
        //        Url = "https://www.google.com/intl/tr/gmail/about/"
        //     },

        //    new Account()
        //    {
        //        Id = new Guid("22fa4f12-0288-43d0-bde1-2bf62122201b"),
        //        UserName = "movieguy",
        //        Password = StringHelper.Base64Encode("123movieguy123"),
        //        IsFavourite = false,
        //        CreatedOn = DateTimeOffset.Now,
        //        Title = "Sinemalar",
        //        Url = "https://www.sinemalar.com"
        //    }
        //};
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var accounts = _dbContext.Accounts.ToList();

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

