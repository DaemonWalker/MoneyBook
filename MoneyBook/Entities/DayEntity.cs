﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MoneyBook.Entities
{
    [DataContract]
    public class DayEntity
    {
        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public bool IsSpend { get; set; }

        [DataMember]
        public string UseWay { get; set; }

        [DataMember]
        public double UseAmount { get; set; }

        [DataMember]
        public string MoneyID { get; set; }
    }
}
