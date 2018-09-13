using MoneyBook.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MoneyBook.Models
{
    [DataContract]
    public class IOModel
    {
        [DataMember]
        [JsonConverter(typeof(StringEnumConverter))]
        public IOEnum IOFlag { get; set; }

        [DataMember]
        public string IOFlagShow
        {
            get
            {
                switch (this.IOFlag)
                {
                    case IOEnum.O:
                        return "出账";
                    case IOEnum.I:
                        return "入账";
                    default:
                        return string.Empty;
                }
            }
        }
    }
}
