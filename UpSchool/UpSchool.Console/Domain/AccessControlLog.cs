using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpSchool.Console.Enums;

namespace UpSchool.Console.Domain
{
    public class AccessControlLog
    {
        public int UserId { get; set; }
        public string DeviceSerialNo { get; set; }
        public AccessType AccessType { get; set; }
        public DateTimeOffset Date { get; set; }

        //statik olarak olusturdugumuz fonk'lar uygulamada bir kez olusturulur ve  cagrilir, classi dinlememize ihtiyac kalmaz.
        public static AccessType ConvertToAccessType(string accessType)
        {
            //3'ten fazla case oldugunda switch case kullan
            switch(accessType)
            {
                case "FACE" : return AccessType.FACE;

                case "FP": return AccessType.FINGERPRINT;

                case "CARD": return AccessType.CARD;

                default:
                    throw new Exception("AccessType couldn't identified.");
            }
        }
    }
}
