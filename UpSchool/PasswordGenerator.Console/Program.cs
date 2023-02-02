using PasswordGenerator.Console;

Console.WriteLine("*********************************************************");
Console.WriteLine("Welcome to the B E S T   P A S S W O R D   M A N A G E R ");
Console.WriteLine("*********************************************************");

var passwordGenerate = new PasswordGenerate();

Console.WriteLine("Do you want to include numbers?(Y/N)");
var includeNumbers = Console.ReadKey().KeyChar.ToString();
passwordGenerate.AddPasswordBase(includeNumbers, Constants.Numbers);

Console.WriteLine("\n Do you want to include capital letters?(Y/N)");
var includeCapitalLetters = Console.ReadKey().KeyChar.ToString();
passwordGenerate.AddPasswordBase(includeCapitalLetters, Constants.CapitalLetters);

Console.WriteLine("\n Do you want to include small letters?(Y/N)");
var includeSmallLetters = Console.ReadKey().KeyChar.ToString();
passwordGenerate.AddPasswordBase(includeSmallLetters, Constants.SmallLetters);

Console.WriteLine("\n Do you want to include special characters?(Y/N)");
var includeSpecialCharacters = Console.ReadKey().KeyChar.ToString();
passwordGenerate.AddPasswordBase(includeSpecialCharacters, Constants.SpecialCharacter);

Console.WriteLine("\n How do you want to keep your password length?");
var passwordLength =Convert.ToInt32(Console.ReadLine());
passwordGenerate.GeneratePassword(passwordLength);

Console.WriteLine("*********************************************************");
Console.WriteLine("G E N E R A T E D   P A S S W O R D: ");
Console.WriteLine(passwordGenerate.GetPassword());


