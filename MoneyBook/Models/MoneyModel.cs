using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MoneyBook.Models
{
    [DataContract]
    public class MoneyModel
    {
        /// <summary>
        /// 入账、出账
        /// </summary>
        [DataMember]
        public bool IsSpend { get; set; } = true;

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
        /// 是否在前台删除
        /// </summary>
        [DataMember]
        public bool IsDelete { get; set; } = false;

        /// <summary>
        /// 所占当日开销百分比
        /// </summary>
        [DataMember]
        public double Percent { get; set; }
    }
}
