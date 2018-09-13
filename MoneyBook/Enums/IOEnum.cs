using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MoneyBook.Enums
{
    [DataContract]
    public enum IOEnum
    {
        [DataMember]
        [JsonConverter(typeof(StringEnumConverter))]
        I = 0,

        [DataMember]
        [JsonConverter(typeof(StringEnumConverter))]
        O = 1
    }
}
