using System;
using System.Reflection;
using System.Resources;
using System.Runtime.Serialization;

namespace Domain.Extensions
{
    public static class EnumHelper
    {
        /// <summary>
        /// Metoda pobiera enum na podstawie nazwy
        /// </summary>
        /// <typeparam name="TResult">Typ enumeratora</typeparam>
        /// <param name="source">Szukany enum</param>
        /// <returns></returns>
        public static TResult ToEnum<TResult>(this string source)
            where TResult : struct, IComparable, IFormattable, IConvertible
        {
            TResult result;

            if (Enum.TryParse<TResult>(source, out result))
            {
                return result;
            }

            throw new NotSupportedException(string.Format("Use of an unsupported Enum: {0}", source));
        }

        /// <summary>
        /// Metoda pobiera enum na podstawie zdefionwanego kodu w atrybucie EnumMember
        /// </summary>
        /// <typeparam name="TResult">Typ enumeratora</typeparam>
        /// <param name="source">Kod atrybutu EnumMember</param>
        /// <returns></returns>
        public static TResult ToEnumByEnumMember<TResult>(this string source)
            where TResult : struct, IComparable, IFormattable, IConvertible
        {
            foreach (TResult item in Enum.GetValues(typeof(TResult)))
            {
                if (item.GetStringValue() == source)
                {
                    return item;
                }
            }

            throw new NotSupportedException(string.Format("Use of an unsupported EnumMember: {0}", source));
        }

        /// <summary>
        /// Metoda pobiera wartość atrybutu EnumMember 
        /// </summary>
        /// <typeparam name="TResult">Typ enumeratora</typeparam>
        /// <param name="value">element enumeratora</param>
        /// <returns></returns>
        public static string GetStringValue<TResult>(this TResult value)
            where TResult : struct, IComparable, IFormattable, IConvertible
        {
            string output = null;
            Type type = value.GetType();

            FieldInfo fi = type.GetField(value.ToString());
            var attrs = fi.GetCustomAttributes(typeof(EnumMemberAttribute), false) as EnumMemberAttribute[];

            if (attrs.Length > 0)
            {
                output = attrs[0].Value;
            }

            return output;
        }

        /// <summary>
        /// Metoda pobiera treść komunikatu z resource'ów dla wykonanej operacji (DML)
        /// </summary>
        /// <typeparam name="TEnum">Typ enumeratora</typeparam>
        /// <param name="value">Wartość enumeratora</param>
        /// <param name="resourceType">Klasa resource'ów</param>
        /// <returns></returns>
        public static string GetMessage<TEnum>(this TEnum value, Type resourceType)
            where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            string messageCode = GetStringValue(value);
            var resourceManager = new ResourceManager(resourceType);
            string message = resourceManager.GetString(messageCode);

            if (!string.IsNullOrEmpty(message))
            {
                return message;
            }

            throw new ArgumentNullException(string.Format("Message has not been defined for: {0}", value.ToString()));
        }
    }
}
