using MoneyBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MoneyBook.Models
{
    [DataContract]
    public class TypeModel : IOModel
    {
        [DataMember]
        public string ID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public bool IsModify { get; set; }

        [DataMember]
        public bool IsDelete { get; set; }
    }
}
