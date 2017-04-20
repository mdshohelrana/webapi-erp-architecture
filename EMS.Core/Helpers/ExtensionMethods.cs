using System;
using System.Data;
using System.Globalization;
using EMS.Core.Domain.Entities;

namespace EMS.Core.Helpers
{
    public static class ExtensionMethods
    {
        public static T To<T>(this IConvertible obj)
        {
            Type t = typeof (T);
            Type u = Nullable.GetUnderlyingType(t);

            if (u != null)
            {
                if (obj == null)
                    return default(T);

                return (T) Convert.ChangeType(obj, u);
            }
            return (T) Convert.ChangeType(obj, t);
        }

        public static string ToStringOrDefault(this DateTime? source, string format, string defaultValue)
        {
            if (source != null)
            {
                return source.Value.ToString(format);
            }
            return String.IsNullOrEmpty(defaultValue) ? String.Empty : defaultValue;
        }

        public static Object IfEmptyThenNull(this String str)
        {
            if (String.IsNullOrEmpty(str))
                return null;
            return str;
        }

        public static int? IfEmptyOrNullThenNull(this String str)
        {
            if (String.IsNullOrEmpty(str))
                return null;
            return str.ToInt();
        }

        public static Boolean NotEquals(this Object val, Object compVal)
        {
            return val != compVal;
        }

        public static Boolean NotEquals(this String val, String compVal)
        {
            return val != compVal;
        }

        public static Boolean NotEquals(this Decimal val, Decimal compVal)
        {
            return val != compVal;
        }

        public static Boolean NotEquals(this Double val, Double compVal)
        {
            return val != compVal;
        }

        public static Boolean NotEquals(this Int32 val, Int32 compVal)
        {
            return val != compVal;
        }

        public static Boolean NotEquals(this Int16 val, Int16 compVal)
        {
            return val != compVal;
        }

        public static Boolean NotEquals(this Int64 val, Int64 compVal)
        {
            return val != compVal;
        }

        public static Boolean NotEquals(this DateTime val, DateTime compVal)
        {
            return val != compVal;
        }

        public static Boolean NotEquals(this Boolean val, Boolean compVal)
        {
            return val != compVal;
        }

        public static Boolean IsNullOrEmpty(this String str)
        {
            return String.IsNullOrEmpty(str);
        }

        public static Boolean IsNotNullOrEmpty(this String str)
        {
            return !String.IsNullOrEmpty(str);
        }

        public static Boolean IsZero(this Decimal val)
        {
            return val.Equals(Decimal.Zero);
        }

        public static Boolean IsNotZero(this Decimal val)
        {
            return !val.Equals(Decimal.Zero);
        }

        public static Boolean IsZero(this Double val)
        {
            return val.Equals(0);
        }

        public static Boolean IsNotZero(this Double val)
        {
            return !val.Equals(0);
        }

        public static Boolean IsZero(this int val)
        {
            return val.Equals(0);
        }

        public static Boolean IsNotZero(this int val)
        {
            return !val.Equals(0);
        }

        public static Boolean IsTrue(this Boolean val)
        {
            return val;
        }

        public static Boolean IsFalse(this Boolean val)
        {
            return !val;
        }

        public static Boolean IsNull(this IAggregateRoot obj)
        {
            return obj == null;
        }

        public static Boolean IsNotNull(this IAggregateRoot obj)
        {
            return obj != null;
        }

        public static Boolean IsNull(this Object obj)
        {
            return obj == null;
        }

        public static Boolean IsNotNull(this Object obj)
        {
            return obj != null;
        }

        public static String IfEmptyThenZero(this String str)
        {
            if (String.IsNullOrEmpty(str))
                return "0";
            return str;
        }

        public static Boolean IsNumber(this String str)
        {
            return IsNumber(str, false);
        }

        public static Boolean IsNumber(this String str, Boolean negativeCheck)
        {
            if (str.Trim().Length > 0)
            {
                try
                {
                    Double.Parse(str.Trim());
                    if (negativeCheck)
                    {
                        if (Double.Parse(str.Trim()) < 0)
                            return false;
                    }
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return str.Trim() != String.Empty;
        }

        public static Boolean IsDate(this String strDate)
        {
            DateTime dt;
            Boolean isdate = true;
            try
            {
                dt = DateTime.Parse(strDate);
            }
            catch
            {
                isdate = false;
            }
            return isdate;
        }

        public static Decimal ToDecimal(this String str)
        {
            if (str.Trim().Length > 0)
            {
                try
                {
                    return Decimal.Parse(str.Trim());
                }
                catch
                {
                    return 0;
                }
            }
            return 0;
        }

        public static Double ToDouble(this String str)
        {
            if (str.Trim().Length > 0)
            {
                try
                {
                    return Double.Parse(str.Trim());
                }
                catch
                {
                    return 0;
                }
            }
            return 0;
        }

        public static int ToInt(this String str)
        {
            if (str.Trim().Length > 0)
            {
                try
                {
                    return int.Parse(str.Trim());
                }
                catch
                {
                    return -1;
                }
            }
            return -1;
        }

        public static Boolean ToBoolean(this String str)
        {
            if (str.Trim().Length > 0)
            {
                try
                {
                    return Boolean.Parse(str.Trim());
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        public static DateTime ToDateTime(this String str)
        {
            if (str.Trim().Length > 0)
            {
                try
                {
                    return DateTime.Parse(str.Trim());
                }
                catch
                {
                    return DateTime.MinValue;
                }
            }
            return DateTime.MinValue;
        }

        public static DateTime ToDateTime(this String str, String DateFormat)
        {
            if (str.Trim().Length > 0)
            {
                try
                {
                    CultureInfo provider = CultureInfo.InvariantCulture;
                    return DateTime.ParseExact(str.Trim(), DateFormat, provider);
                }
                catch
                {
                    return DateTime.MinValue;
                }
            }
            return DateTime.MinValue;
        }

        public static Object Value(this DateTime dateTime, String format)
        {
            return dateTime.Equals(DateTime.MinValue) ? null : dateTime.ToString(format);
        }

        public static String StringValue(this DateTime dateTime)
        {
            return dateTime.Equals(DateTime.MinValue) ? String.Empty : dateTime.ToShortDateString();
        }

        public static Boolean GetBoolean(this IDataRecord reader, String columnName)
        {
            return reader[columnName].Equals(DBNull.Value) ? false : (Boolean) reader[columnName];
        }

        public static Byte[] GetBytes(this IDataRecord reader, String columnName)
        {
            return reader[columnName].Equals(DBNull.Value) ? null : (Byte[]) reader[columnName];
        }

        public static DateTime GetDateTime(this IDataRecord reader, String columnName)
        {
            return reader[columnName].Equals(DBNull.Value)
                ? DateTime.MinValue
                : DateTime.Parse(reader[columnName].ToString());
        }

        public static Decimal GetDecimal(this IDataRecord reader, String columnName)
        {
            return reader[columnName].Equals(DBNull.Value) ? 0.0m : (Decimal) reader[columnName];
        }

        public static Double GetDouble(this IDataRecord reader, String columnName)
        {
            return reader[columnName].Equals(DBNull.Value) ? 0.0d : (Double) reader[columnName];
        }

        public static Int16 GetInt16(this IDataRecord reader, String columnName)
        {
            return reader[columnName].Equals(DBNull.Value) ? (Int16) 0 : Convert.ToInt16(reader[columnName]);
        }

        public static Int32 GetInt32(this IDataRecord reader, String columnName)
        {
            return reader[columnName].Equals(DBNull.Value) ? 0 : (Int32) reader[columnName];
        }

        public static Int64 GetInt64(this IDataRecord reader, String columnName)
        {
            return reader[columnName].Equals(DBNull.Value) ? 0 : (Int64) reader[columnName];
        }

        public static Int64? GetNulableInt64(this IDataRecord reader, String columnName)
        {
            return reader[columnName].Equals(DBNull.Value) ? null : (Int64?) reader[columnName];
        }

        public static Int32? GetNulableInt32(this IDataRecord reader, String columnName)
        {
            return reader[columnName].Equals(DBNull.Value) ? null : (Int32?) reader[columnName];
        }

        public static String GetString(this IDataRecord reader, String columnName)
        {
            return reader[columnName].ToString();
        }

        public static TimeSpan? GetTimeSpan(this IDataRecord reader, String columnName)
        {
            return reader[columnName].Equals(DBNull.Value) ? null : (TimeSpan?) reader[columnName];
        }

        public static DateTime? GetNullableDateTime(this IDataRecord reader, String columnName)
        {
            return reader[columnName].Equals(DBNull.Value)
                ? null
                : (DateTime?) DateTime.Parse(reader[columnName].ToString());
        }
    }
}