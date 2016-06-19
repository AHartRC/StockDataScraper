#region Using Directives

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using StockDataScraper.Attributes;

#endregion

namespace StockDataScraper.Extensions
{
    public static class EnumExtensions
    {
        public static IEnumerable<T> GetEnums<T>(this T source, bool includeHidden = false)
        {
            var type = typeof (T);
            if (type.IsEnum)
            {
                return Enum.GetValues(type).Cast<T>().Where(w => IsHidden(w) == includeHidden);
            }
            return null;
        }

        public static DisplayAttribute GetDisplayAttribute<T>(this T source)
        {
            var type = typeof (T);
            var field = type.GetField(source.ToString());
            var result = field.GetCustomAttributes(typeof (DisplayAttribute), false) as DisplayAttribute[];
            if (result == null)
                throw new ArgumentNullException(string.Format("{0} has no display attribute!", source));
            return result[0];
        }

        public static HiddenAttribute GetHiddenAttribute<T>(this T source)
        {
            var type = typeof (T);
            return type.GetCustomAttribute<HiddenAttribute>();
        }

        public static bool IsHidden<T>(this T source)
        {
            var attribute = GetHiddenAttribute(source);
            return attribute != null && attribute.IsHidden;
        }

        public static string GetShortName<T>(this T source) where T : struct, IComparable, IConvertible, IFormattable
        {
            var attribute = GetDisplayAttribute(source);

            return attribute == null || attribute.ShortName.IsNullOrWhiteSpace()
                ? null
                : attribute.ShortName;
        }

        public static string GetName<T>(this T source) where T : struct, IComparable, IConvertible, IFormattable
        {
            var attribute = GetDisplayAttribute(source);

            return attribute == null || attribute.Name.IsNullOrWhiteSpace()
                ? null
                : attribute.Name;
        }

        public static string GetDescription<T>(this T source) where T : struct, IComparable, IConvertible, IFormattable
        {
            var attribute = GetDisplayAttribute(source);

            return attribute == null || attribute.Description.IsNullOrWhiteSpace()
                ? null
                : attribute.Description;
        }

        public static string GetGroupName<T>(this T source) where T : struct, IComparable, IConvertible, IFormattable
        {
            var attribute = GetDisplayAttribute(source);

            return attribute == null || attribute.GroupName.IsNullOrWhiteSpace()
                ? null
                : attribute.GroupName;
        }

        public static string GetPrompt<T>(this T source) where T : struct, IComparable, IConvertible, IFormattable
        {
            var attribute = GetDisplayAttribute(source);

            return attribute == null || attribute.Prompt.IsNullOrWhiteSpace()
                ? null
                : attribute.Prompt;
        }

        public static int GetOrder<T>(this T source) where T : struct, IComparable, IConvertible, IFormattable
        {
            var attribute = GetDisplayAttribute(source);

            if (attribute == null)
                return 0;

            var order = attribute.GetOrder();

            if (order == null || attribute.Order <= 0)
            {
                attribute.Order = 0;
            }

            return attribute.Order;
        }

        public static T SetShortName<T>(this T source, string value)
            where T : struct, IComparable, IConvertible, IFormattable
        {
            var attribute = GetDisplayAttribute(source);
            attribute.ShortName = value;
            return source;
        }

        public static T SetName<T>(this T source, string value)
            where T : struct, IComparable, IConvertible, IFormattable
        {
            var attribute = GetDisplayAttribute(source);
            attribute.Name = value;
            return source;
        }

        public static T SetDescription<T>(this T source, string value)
            where T : struct, IComparable, IConvertible, IFormattable
        {
            var attribute = GetDisplayAttribute(source);
            attribute.Description = value;
            return source;
        }

        public static T SetGroupName<T>(this T source, string value)
            where T : struct, IComparable, IConvertible, IFormattable
        {
            var attribute = GetDisplayAttribute(source);
            attribute.GroupName = value;
            return source;
        }

        public static T SetPrompt<T>(this T source, string value)
            where T : struct, IComparable, IConvertible, IFormattable
        {
            var attribute = GetDisplayAttribute(source);
            attribute.Prompt = value;
            return source;
        }

        public static T SetOrder<T>(this T source, int value) where T : struct, IComparable, IConvertible, IFormattable
        {
            var attribute = GetDisplayAttribute(source);
            attribute.Order = value;
            return source;
        }
    }
}