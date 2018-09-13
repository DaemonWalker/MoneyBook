using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MoneyBook.Models
{
    [DataContract]
    public class WeekDetailModel : IOModel
    {
        /// <summary>
        /// 变动原因
        /// </summary>
        [DataMember]
        public string UseWay { get; set; }

        /// <summary>
        /// 变动金额
        /// </summary>
        [DataMember]
        public double UseAmount { get; set; }

        /// <summary>
        /// 记录ID
        /// </summary>
        [DataMember]
        public string ID { get; set; }

        /// <summary>
        /// 所占当日开销百分比
        /// </summary>
        [DataMember]
        public double Percent { get; set; }

        [DataMember]
        public string UseType { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

    }
}
