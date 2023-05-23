namespace Domain.Extensions
{
    public static class StringExtensions //Bu sekilde statik tanimlamalarla .'dan sonra cikan fonklar yazariz.
    {
       public static bool IsContainsChar(this string text) 
       {
            var results =  text.Select(x => char.IsLetter(x));
            
            if (results.Any(x => x == true)) 
            {
                return true;
            }
            
            return false;
       }
    }
}
