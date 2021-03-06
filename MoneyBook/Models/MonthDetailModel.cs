﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MoneyBook.Models
{
    [DataContract]
    public class MonthDetailModel
    {
        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public double UseAmount { get; set; }

        [DataMember]
        public double Percent { get; set; }

        [DataMember]
        public string UseWay { get; set; }
    }
}
