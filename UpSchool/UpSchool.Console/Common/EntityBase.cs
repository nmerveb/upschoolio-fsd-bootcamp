using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpSchool.Console.Common
{
    //Entitybase icinde private tanimlama genelde kullanilmaz.
    public class EntityBase : IEntityBase
    {
        public string Id { get; set; }
        public bool IsDeleted { get; set; }
        //genelde db uzerinde yapilan islemlerde o islemi kimin ne zaman yaptigi gibi bilgileri tutariz.
    }
}
