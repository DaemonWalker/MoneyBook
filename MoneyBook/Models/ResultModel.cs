using MoneyBook.Enums;
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
        public OpStatusEnum OpStatus { get; private set; }

        [DataMember]
        public string Message { get; private set; }

        public static ResultModel Success(string message)
        {
            return new ResultModel()
            {
                OpStatus = OpStatusEnum.Success,
                Message = message
            };
        }

        public static ResultModel Error(string message)
        {
            return new ResultModel()
            {
                OpStatus = OpStatusEnum.Error,
                Message = message
            };
        }
    }
}
