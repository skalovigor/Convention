using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Convention.BLL.Infrastructure.Helpers
{
    public static class EnumHelper
    {
        public static List<TEnum> GetEnumDescription<TEnum>(List<string> stringValues)
            where TEnum : Enum
        {
            if (stringValues == null || !stringValues.Any()) return new List<TEnum>();
            
            var result = new List<TEnum>();
            foreach (TEnum val in Enum.GetValues(typeof(TEnum)))
            {
                var description = GetEnumDescription(val);
                if (stringValues.Contains(description))
                {
                    result.Add(val);
                }
            }
            return result;
        }
        
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }
    }
}