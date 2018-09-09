using MoneyBook.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MoneyBook.Utils
{
    [AttributeUsage(AttributeTargets.Method)]
    public class NotImplementedAttribute : Attribute
    {
        private static Dictionary<string, bool> info = new Dictionary<string, bool>();
        static NotImplementedAttribute()
        {
            foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (type.IsSubclassOf(typeof(DataAccess)))
                {
                    var attr = Attribute.GetCustomAttribute(
                        type.GetMethod("CreateDataAdapter", BindingFlags.NonPublic | BindingFlags.Instance),
                        typeof(NotImplementedAttribute)) as NotImplementedAttribute;
                    if (attr != null && attr.IsNotImplemented)
                    {
                        info.Add($"{type.Name}.CreateDataAdapter", true);
                    }
                    attr = Attribute.GetCustomAttribute(
                        type.GetMethod("CreateDataReader", BindingFlags.NonPublic | BindingFlags.Instance),
                        typeof(NotImplementedAttribute)) as NotImplementedAttribute;

                    if (attr != null && attr.IsNotImplemented)
                    {
                        info.Add($"{type.Name}.CreateDataReader", true);
                    }
                }
                if (typeof(IDataRelation<>).IsAssignableFrom(type))
                {
                    var attr = Attribute.GetCustomAttribute(
                        type.GetMethod("DataRowToEntity"), typeof(NotImplementedAttribute)) as NotImplementedAttribute;
                    if (attr != null && attr.IsNotImplemented)
                    {
                        info.Add($"{type.Name}.DataRowToEntity", true);
                    }
                    attr = Attribute.GetCustomAttribute(
                        type.GetMethod("DataReaderToEntity"), typeof(NotImplementedAttribute)) as NotImplementedAttribute;

                    if (attr != null && attr.IsNotImplemented)
                    {
                        info.Add($"{type.Name}.DataReaderToEntity", true);
                    }
                }
            }
        }
        public static bool IsMethodNotImplemented(string className, string methodName)
        {
            if (info.ContainsKey($"{className}.{methodName}"))
            {
                return info[$"{className}.{methodName}"];
            }
            else
            {
                return false;
            }
        }
        public bool IsNotImplemented { get; set; }
        public NotImplementedAttribute(bool isNotImplemented = true)
        {
            this.IsNotImplemented = isNotImplemented;
        }
    }
}
