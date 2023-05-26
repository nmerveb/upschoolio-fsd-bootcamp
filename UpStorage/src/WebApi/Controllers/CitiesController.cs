using Application.Features.Cities.Commands.Add;
using Application.Features.Cities.Queries.GetAll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [Authorize]
    [ValidationFilter]  //Attributelar bu sekilde tanimlanir 
    public class CitiesController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddAsync(CityAddCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("GetAll")] //Get kullandigimizda fonksiyon param alamaz
        public async Task<IActionResult> GetAllAsync(CityGetAllQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await Mediator.Send(new CityGetAllQuery(id, null)));
        }
    }
}
