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
            return Convert.ToDateTime(dateStr);
        }
    }
}
