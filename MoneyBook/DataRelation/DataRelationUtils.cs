using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyBook.DataRelation
{
    public static class DataRelationUtils
    {
        public static DateTime ConvertToDateTime(this string dateStr)
        {
            var num = Convert.ToInt32(dateStr);
            return new DateTime(num / 10000, num % 10000 / 100, num % 100);
        }
    }
}
