
//sinif icerisinde tanimlanmayan belli bir isi yapmak icin yazilmis kod parcaciklarina fonk denir.

using UpSchool.Console.Domain;
using UpSchool.Console.FirstExample;

Student student = new Student();
student.FirstName = "Merve";
student.LastName = "Bacak";
student.TCID = "8327465732";

//$"" icersinde {} acip istedigimiz degiskeni kullanabiliriz.
Console.WriteLine(student.FullName); //daha kounakli va az maliyetli?

Teacher teacher = new Teacher();
teacher.FirstName = "Alper";
teacher.LastName = "Tunga";

var colour=Colour.Blue;
if (colour==Colour.Blue)
{
    Console.WriteLine("Blue");
}
Console.ReadLine();

