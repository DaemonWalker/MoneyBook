using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MoneyBook.Models
{
    [DataContract]
    public class DayModel
    {
        /// <summary>
        /// 产生时间
        /// </summary>
        [DataMember]
        public DateTime Date { get; set; }

        /// <summary>
        /// 变动信息
        /// </summary>
        [DataMember]
        public List<MoneyModel> Detail { get; set; }
    }
}
