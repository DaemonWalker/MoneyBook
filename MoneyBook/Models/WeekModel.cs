using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MoneyBook.Models
{
    [DataContract]
    public class WeekModel
    {
        [DataMember]
        public string Week { get; set; }

        [DataMember]
        public double UseAmount { get; set; }

        [DataMember]
        public double Percent { get; set; }

        [DataMember]
        public string WeekIndex { get; set; }

        [DataMember]
        public List<MoneyModel> Detail { get; set; }

        [DataMember]
        public bool IsSum { get; set; }

        [DataMember]
        public bool ShowDetail { get; set; }
    }
}
