using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cities.Queries.GetAll
{
    public class CityGetAllQueryHandler : IRequestHandler<CityGetAllQuery, List<CityGetAllDto>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public CityGetAllQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<List<CityGetAllDto>> Handle(CityGetAllQuery request, CancellationToken cancellationToken)
        {
            var dbquery = _applicationDbContext.Cities.AsQueryable();

            dbquery = dbquery.Where(x => x.CountryId == request.CountryId);

            if(request.IsDeleted.HasValue) dbquery = dbquery.Where(x => x.IsDeleted == request.IsDeleted.Value); //Hem silinmis hem silinmemis valuelari istedigimizde calismaz.

            dbquery = dbquery.Include(x => x.Country);
            var cities = await dbquery.ToListAsync(cancellationToken);
            var cityDtos = MapCityToGetAllDto(cities);

            return cityDtos.ToList();
        }

        private IEnumerable<CityGetAllDto> MapCityToGetAllDto(List<City> cities)
        {
            List<CityGetAllDto> cityGetAllDtos = new List<CityGetAllDto>();

            foreach(var city in cities)
            {
                yield return new CityGetAllDto()
                {
                    Id = city.Id,
                    CountryId = city.CountryId,
                    CountryName = city.Country.Name,
                    Name = city.Name,
                    IsDeleted = city.IsDeleted,
                    Longitude = city.Longitude,
                    Latitude = city.Latitude,
                };
            }
        }
    }
}
