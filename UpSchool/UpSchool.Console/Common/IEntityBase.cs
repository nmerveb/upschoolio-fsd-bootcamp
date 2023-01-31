using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpSchool.Console.Common
{
    
    public interface IEntityBase:IEntity
    {
        string Id { get; set; }
    }
}
