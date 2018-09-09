using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MoneyBook.Models
{
    [DataContract]
    public class MoneyShowModel : MoneyModel
    {
        /// <summary>
        /// 流向显示文字
        /// </summary>
        [DataMember]
        public string IsSpendShow
        {
            get
            {
                if (this.IsSpend)
                {
                    return "出账";
                }
                else
                {
                    return "入账";
                }
            }
        }
    }
}
