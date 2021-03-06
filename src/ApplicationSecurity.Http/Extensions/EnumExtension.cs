﻿namespace ApplicationSecurity.Http.Extensions
{
    using System;
    using System.ComponentModel;

    public static class EnumExtension
    {
        public static string GetDescription<T>(this T enumerationValue)
            where T : struct
        {
            var type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException("EnumerationValue must be of Enum type", nameof(enumerationValue));
            }

            var memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo.Length <= 0) return enumerationValue.ToString();
            
            var attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attrs.Length <= 0 ? enumerationValue.ToString() : ((DescriptionAttribute)attrs[0]).Description;
        }
    }
}
