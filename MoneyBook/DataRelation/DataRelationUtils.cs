﻿using MoneyBook.Enums;
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

        public static IOEnum ConvertToIOEnum(this string ioEnum)
        {
            return Enum.Parse<IOEnum>(ioEnum);
        }
        public static double FormatDouble(this double num)
        {
            return Math.Round(num, 2);
        }
    }
}
