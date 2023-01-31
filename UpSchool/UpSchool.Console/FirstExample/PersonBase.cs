using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpSchool.Console.FirstExample
{
    //Baska siniflarda da kullanilan ozellikleri bir base sinifta tanimlayip base siniftan kalitim aliriz.
    //Base classs'lara ondan turettigimiz butun classlarda kullanacagimiz property'leri tanimlariz
    public class PersonBase
    {
        //class icinde yazilmis kod parcaciklarina fonksiyon denir.
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
