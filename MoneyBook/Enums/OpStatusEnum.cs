using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MoneyBook.Enums
{
    [DataContract]
    public enum OpStatusEnum
    {
        [DataMember]
        Error = 0,

        [DataMember]
        Success = 1
    }
}
