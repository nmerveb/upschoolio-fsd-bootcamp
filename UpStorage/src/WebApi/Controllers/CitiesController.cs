using Application.Features.Cities.Commands.Add;
using Application.Features.Cities.Queries.GetAll;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class CitiesController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddAsync(CityAddCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost] //Get kullandigimizda fonksiyon param alamaz
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
