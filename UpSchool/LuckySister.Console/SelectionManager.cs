using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpSchool.Domain.Entities; //Dependencies kismindan proje referansini ekle

namespace LuckySister.Console
{
    public class SelectionManager
    {
        private List<Attendee> Attendees { get; set; }
        private List<Attendee> SelectedAttendees { get; set; }
        private Random _random;

        //bir class'i newledigimiz zaman ilk calisan bolum constructor'dir.
        //ayni isimde iki fonk tanimlamak overloading'tir
        public SelectionManager(List<Attendee> initialAttendees)
        {
            if (initialAttendees.Any()) //constructor icerisinde genelde kontrol islemleri yapmayiz.
            {
                Attendees=new List<Attendee>();
                Attendees.AddRange(initialAttendees);
                SelectedAttendees=new List<Attendee>();
                _random=new Random();
               // Attendees = initialAttendees; //ref tipli degiskenlerde direkt atama yapamayiz.
            }
            
        }
        public SelectionManager()
        {
            Attendees = new List<Attendee>(); //olusturdugumuz sinif degiskenlerini initialize etmeden kullanamayiz.
            SelectedAttendees = new List<Attendee>();
            _random= new Random();
        }

        public void MakeSlection(int selectCount)
        {
            for(int i = 0; i < selectCount; i++)
            {
                SelectedAttendees.Add(GetRandomAttendee());
            }
        }
        public List<Attendee> GetSelectedAttendees()
        {
            return SelectedAttendees;
        }
        private Attendee GetRandomAttendee()
        {
            var randomIndex = _random.Next(Attendees.Count - 1);
            var attendee = Attendees[randomIndex];
            if (SelectedAttendees.Any(x => x.Id == attendee.Id))
            {
                return GetRandomAttendee();
            }
            return attendee;
        }
        public void AddAttendee(Attendee attendee)
        {
            System.Console.WriteLine("Yeni bir katilimci eklendi.");
            Attendees.Add(attendee);    
        }

        public void AddAttendee(string fullName)
        {
            Attendee attendee = new Attendee()
            {
                Id= Guid.NewGuid(),
                FullName= fullName,
                CreatedOn=DateTimeOffset.Now
            };
            Attendees.Add(attendee); 
        }

        public int GetAttendeesCount()
        {
            return Attendees.Count;
        }

        #region clean code ornegi icin
        //public void Connect(string ip)
        //{
        //}
        //public void CalculateTotalBalance(decimal lastBalance,int taxRate, decimal amount)
        //{
        //}
        #endregion
    }
}
