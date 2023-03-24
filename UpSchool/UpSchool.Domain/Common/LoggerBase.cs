namespace UpSchool.Domain.Common
{
    public abstract class LoggerBase 
    {
        private readonly string _apiUrl;
        public LoggerBase(string titanicFluteUrl)
        {
            _apiUrl= titanicFluteUrl;
        }
        public virtual void Log(string message) 
        {
            Console.WriteLine(message);
            Console.WriteLine(_apiUrl);
        } 
    }
}
