using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyBook.Utils
{
    public class AppSettings
    {
        public static string DataBase { get; set; }
        public static string SQLite { get; set; }
        public static string MySql { get; set; }
        public static string MSSQL { get; set; }
        public static string Oracle { get; set; }
        public static string MonthFormat { get; set; }
        public static string DayFormat { get; set; }
    }
}
