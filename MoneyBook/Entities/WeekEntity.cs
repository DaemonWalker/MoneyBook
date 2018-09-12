using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MoneyBook.Entities
{
    [DataContract]
    public class WeekEntity
    {
        public int Week { get; set; }
        public double UseAmount { get; set; }
    }
}
