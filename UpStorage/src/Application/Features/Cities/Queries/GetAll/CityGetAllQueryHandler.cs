using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Features.Cities.Queries.GetAll
{
    public class CityGetAllQueryHandler : IRequestHandler<CityGetAllQuery, List<CityGetAllDto>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMemoryCache _memoryCache;
        private readonly MemoryCacheEntryOptions _cacheOptions;
        private const string CITIES_KEY = "CitiesList";

        public CityGetAllQueryHandler(IApplicationDbContext applicationDbContext, IMemoryCache memoryCache)
        {
            _applicationDbContext = applicationDbContext;
            _memoryCache = memoryCache;

            _cacheOptions = new MemoryCacheEntryOptions()
            {
                Priority = CacheItemPriority.Normal,
                AbsoluteExpiration = DateTimeOffset.Now.AddHours(6)
            };
        }
        public async Task<List<CityGetAllDto>> Handle(CityGetAllQuery request, CancellationToken cancellationToken)
        {
            if(_memoryCache.TryGetValue(CITIES_KEY, out List<CityGetAllDto> cachedCities))
            {
                return cachedCities;
            }

            var dbquery = _applicationDbContext.Cities.AsQueryable();

            //dbquery = dbquery.Where(x => x.CountryId == request.CountryId);

            if(request.IsDeleted.HasValue) dbquery = dbquery.Where(x => x.IsDeleted == request.IsDeleted.Value); //Hem silinmis hem silinmemis valuelari istedigimizde calismaz.

            dbquery = dbquery.Include(x => x.Country);
            var cities = await dbquery
                .Take(2000)
                .Select(x => MapToDto(x))
                .ToListAsync(cancellationToken);

            _memoryCache.Set(CITIES_KEY, cities, _cacheOptions);

            return cities.ToList();
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
                    CountryName = city?.Country?.Name,
                    Name = city.Name,
                    IsDeleted = city.IsDeleted,
                    Longitude = city.Longitude,
                    Latitude = city.Latitude,
                };
            }
        }

        private static CityGetAllDto MapToDto(City city)
        {
            return new CityGetAllDto()
            {
                Id = city.Id,
                CountryId = city.CountryId,
                CountryName = city?.Country?.Name,
                Name = city.Name,
                IsDeleted = city.IsDeleted,
                Longitude = city.Longitude,
                Latitude = city.Latitude,
            };
        }
    }
}
