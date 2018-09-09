using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MoneyBook.Models
{
    [DataContract]
    public class ResultModel
    {
        [DataMember]
        public int OpStatus { get; set; }

        [DataMember]
        public string Message { get; set; }

        public static ResultModel Success(string message)
        {
            return new ResultModel()
            {
                OpStatus = 1,
                Message = message
            };
        }

        public static ResultModel Error(string message)
        {
            return new ResultModel()
            {
                OpStatus = 0,
                Message = message
            };
        }
    }
}
