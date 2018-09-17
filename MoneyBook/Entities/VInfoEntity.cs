using MoneyBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MoneyBook.Entities
{
    [DataContract]
    public class VInfoEntity
    {
        [DataMember]
        public IOEnum IOFlag { get; set; }

        [DataMember]
        public string UseWay { get; set; }

        [DataMember]
        public double UseAmount { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public string TypeID { get; set; }

        [DataMember]
        public string DayID { get; set; }

        [DataMember]
        public string MoneyID { get; set; }

        [DataMember]
        public string TypeName { get; set; }
        
    }
}
