using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MoneyBook.Models
{
    [DataContract]
    public class MonthModel
    {

        [DataMember]
        public string UseWay { get; set; }

        [DataMember]
        public double TotalMoney { get; set; }

        [DataMember]
        public double Percent { get; set; }

        [DataMember]
        public bool IsSum { get; set; }
    }
}
