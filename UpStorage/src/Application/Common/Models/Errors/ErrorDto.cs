namespace Application.Common.Models.Errors
{
    public class ErrorDto
    {
        public string PropertyName { get; set; }
        public List<string> ErrorMessage { get; set; }

        public ErrorDto(string propertyName,List<string> errorMessage)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
        }
    }
}
