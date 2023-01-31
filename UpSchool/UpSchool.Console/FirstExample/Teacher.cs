using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpSchool.Console.FirstExample
{
    public class Teacher : PersonBase, ITurkishPerson
    {
        public string TCID { get; set; }
    }
}
