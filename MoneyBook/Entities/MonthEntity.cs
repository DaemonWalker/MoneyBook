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
        public string UseType { get; set; }

        [DataMember]
        public double TotalMoney { get; set; }

        [DataMember]
        public string UseTypeID { get; set; }
    }
}
