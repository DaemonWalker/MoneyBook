using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MoneyBook.Entities
{
    [DataContract]
    public class MonthEntity
    {
        [DataMember]
        public string UseWay { get; set; }

        [DataMember]
        public double TotalMoney { get; set; }
    }
}
