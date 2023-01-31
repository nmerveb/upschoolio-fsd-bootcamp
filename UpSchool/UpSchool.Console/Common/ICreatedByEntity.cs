using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpSchool.Console.Common
{
    public interface ICreatedByEntity
    {
        public string CreatedByUserId { get; set; }
        //zamani ve zaminin oldugu zaman dilimini tutar.
        public DateTimeOffset CreatedOn { get; set; }
    }
}
