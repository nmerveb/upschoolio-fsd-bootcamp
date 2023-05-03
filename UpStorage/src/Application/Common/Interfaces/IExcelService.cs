using Application.Common.Models.Excel;

namespace Application.Common.Interfaces
{
    public interface IExcelService
    {
        List<ExcelCityDto> ReadCitiesAsync(ExcelBase64Dto excelDto);
    }
}
