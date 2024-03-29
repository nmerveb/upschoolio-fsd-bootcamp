﻿using Application.Common.Models.Excel;

namespace Application.Common.Interfaces
{
    public interface IExcelService
    {
        List<ExcelCityDto> ReadCitiesAsync(ExcelBase64Dto excelDto);
        List<ExcelCountryDto> ReadCountries(ExcelBase64Dto excelDto);
    }
}
