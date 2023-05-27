namespace UpSchool.Domain.Dtos
{
    public class SeleniumLogDto //GONDERILEN LOG MODELI
    {
        public string Message { get; set; }
        public DateTimeOffset SendOn { get; set; }

        public SeleniumLogDto(string message)
        {
            Message = message;
            SendOn = DateTimeOffset.Now;
        }

    }
}
