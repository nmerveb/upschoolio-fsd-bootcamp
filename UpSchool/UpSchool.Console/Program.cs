using UpSchool.Console.Domain;
using UpSchool.Console.Enums;
using UpSchool.Console.FirstExample;

//okumak istedigin dosya yoluna gore degistir.
const string filePath = "C:\\Users\\W10\\Documents\\Projects\\FSD-bootcamp\\UpSchool\\ExampleData\\Access_Control_Logs.txt";

var logsText = File.ReadAllText(filePath);

// \n stringi satirlara gore bolmeyi saglar
var splitLines=logsText.Split('\n', StringSplitOptions.RemoveEmptyEntries);

List<AccessControlLog> logs = new List<AccessControlLog>();

foreach (var line in splitLines.Skip(1)) //skip fonksiyornu icine verdigimiz index degeri kadar ogeden sonra calismaya baslar.
{
    var logFields = line.Replace(" ",string.Empty)
        .Split("---",StringSplitOptions.RemoveEmptyEntries);
    var accessControlLog = new AccessControlLog()
    {
        UserId = Convert.ToInt32(logFields[0]),
        DeviceSerialNo = logFields[1],
        AccessType = AccessControlLog.ConvertToAccessType(logFields[2]),
        Date = Convert.ToDateTime(logFields[3]),
    };
    logs.Add(accessControlLog);
}

/*var cardLogs = logs.Where(x => x.AccessType == AccessType.CARD && x.DeviceSerialNo == "X01X2500S").ToList();*/ //LINQ sorgusu

var cardLogs = logs
    .Where(x => x.AccessType == AccessType.CARD)
    .Where(x => x.DeviceSerialNo == "X01X2500S")
    .ToList();

cardLogs.ForEach(log => Console.WriteLine($"{log.UserId} - {log.DeviceSerialNo} - {log.AccessType} - {log.Date}"));
 
Console.ReadLine();

#region Ilk ders notlari
////sinif icerisinde tanimlanmayan belli bir isi yapmak icin yazilmis kod parcaciklarina fonk denir.

//using UpSchool.Console.Domain;
//using UpSchool.Console.FirstExample;

//Student student = new Student();
//student.FirstName = "Merve";
//student.LastName = "Bacak";
//student.TCID = "8327465732";

////$"" icersinde {} acip istedigimiz degiskeni kullanabiliriz.
//Console.WriteLine(student.FullName); //daha kounakli va az maliyetli?

//Teacher teacher = new Teacher();
//teacher.FirstName = "Alper";
//teacher.LastName = "Tunga";

//var colour=Colour.Blue;
//if (colour==Colour.Blue)
//{
//    Console.WriteLine("Blue");
//}
//Console.ReadLine();
#endregion

#region Ucuncu ders baslangic notlari
////referans tipler heapte deger tipler stack'te saklanir
////stack statik oldugu icin heapten daha hizlidir.
////string pole?
//int sayi1 = 15;
//int sayi2 = sayi1;
//sayi1 = 25;
//Console.WriteLine(sayi1);
//Console.WriteLine(sayi2);

//Student student1= new Student();
//student1.FirstName = "Alper Tunga";
////Student student2 = student1; //referans tiplerde direkt atama olmaz, bu yuzden student1 ve student2 ayni yeri gosterir.
//Student student2= new Student(student1.FirstName);
//student1.FirstName = "Armagan Tunga";

//Console.WriteLine(student1.FirstName);
//Console.WriteLine(student2.FirstName);

//Console.ReadLine();

//var accessControlLog = new AccessControlLog();
//if (accessControlLog.AccessType == AccessType.FACE)
//{

//}
#endregion