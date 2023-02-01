using LuckySister.Console;
using UpSchool.Domain.Entities;

var selectionManager = new SelectionManager();

selectionManager.AddAttendee("Ayfer Yildirim");
selectionManager.AddAttendee("Aybike Boran");
selectionManager.AddAttendee("Oznur Fidan");
selectionManager.AddAttendee("Merve Albayram");
selectionManager.AddAttendee("Dilara Demirhan");

int selectionCount = 3;

selectionManager.MakeSlection(selectionCount);

var selectedAttendees = selectionManager.GetSelectedAttendees();

selectedAttendees.ForEach(x=>Console.WriteLine(x.FullName));

Console.ReadLine();

#region Denemeler
//List<Attendee> attendees=new List<Attendee>();
//SelectionManager selection =new SelectionManager(attendees);

//selection.AddAttendee("Alper Tunga");

//var attendee = new Attendee()
//{
//    Id = Guid.NewGuid(), //yeni guid olusturur.
//    FullName = "Merve Bacak",
//    CreatedOn=DateTimeOffset.Now,
//};


//selection.AddAttendee(attendee);
//selection.AddAttendee(attendee); 
//selection.AddAttendee(attendee); 
//selection.AddAttendee(attendee);

//var count = selection.GetAttendeesCount();
//Console.WriteLine(count);
#endregion

#region clean code ornegi
//var clientIp = "192.168.1.37";
//selection.Connect(clientIp);
//selection.CalculateTotalBalance(lastBalance: 600, 15, 225);
#endregion