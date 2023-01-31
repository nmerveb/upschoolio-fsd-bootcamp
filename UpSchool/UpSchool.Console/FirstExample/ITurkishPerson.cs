using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpSchool.Console.FirstExample
{
    //Bir class birden fazla classtan kalitim alamaz, bu durumda interface'ler devreye girer.
    public interface ITurkishPerson
    {
        public string TCID { get; set; }
    }
}
