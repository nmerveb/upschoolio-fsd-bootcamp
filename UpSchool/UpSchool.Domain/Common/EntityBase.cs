using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpSchool.Domain.Common
{
    public class EntityBase
    {
        //Essiz id tutar.
        public Guid Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }  
    }
}
