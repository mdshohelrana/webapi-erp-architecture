using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace EMS.Core.Helpers
{
    public static class EnumHelper
    {
        public static string Description(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[]) fi.GetCustomAttributes(typeof (DescriptionAttribute), false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            return value.ToString();
        }

        public static List<object> GetEnumList(this Type enumType)
        {
            List<object> enumTypeList = new List<object>();

            foreach (var item in Enum.GetValues(enumType))
            {
                string description = enumType.GetField(Enum.GetName(enumType, item))
                    .GetCustomAttributes(typeof (DescriptionAttribute), false)
                    .OfType<DescriptionAttribute>()
                    .FirstOrDefault().Description;

                var result = new {Id = item, Name = description};
                enumTypeList.Add(result);
            }
            return enumTypeList;
        }
    }
}