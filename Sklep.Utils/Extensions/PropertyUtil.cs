using System.Reflection;
using System;
using System.Linq;


namespace Sklep.Utils.Extensions
{
    public static class PropertyUtil
    {
        /// <summary>
        /// This is method to copy properties from one type to another.
        /// In order to be copied, propeties need to be the same type and have the same name.
        /// </summary>
        /// <typeparam name="T">Target type</typeparam>
        /// <typeparam name="T2">Source type</typeparam>
        /// <param name="targetObject">Target object</param>
        /// <param name="sourceObject">Source object</param>
        public static void CopyProperties<T, T2>(T targetObject, T2 sourceObject)
        {
            /*
             p => p.CanWrite

             anon(parametr p)
            {
                return p.CanWrite            
            }
            Func<TSource,bool>
            */
            foreach (var property in typeof(T).GetProperties().Where(p => p.CanWrite))
            {
                Func<PropertyInfo, bool> CheckIfPropertyExistInSource =
                    prop =>
                    string.Equals(property.Name, prop.Name, StringComparison.InvariantCultureIgnoreCase)
                    && prop.PropertyType.Equals(property.PropertyType);
                /*
                 bool CheckIfPropertyExistInSource(PropertyInfo prop)
                 {
                    return string.Equals(property.Name,prop.Name, StringComparison.InvariantCultureIgnoreCase)
                    && prop.PropertyType.Equals(property.PropertyType);
                 }
                 */
                if (sourceObject.GetType().GetProperties().Any(CheckIfPropertyExistInSource))
                {
                    property.SetValue(targetObject, sourceObject.GetPropertyValue(property.Name), null);
                }
            }
        }
        /// <summary>
        /// This is method to copy properties from one type to another.
        /// In order to be copied, propeties need to be the same type and have the same name.
        /// </summary>
        /// <typeparam name="T">Target type</typeparam>
        /// <typeparam name="T2">Source type</typeparam>
        /// <param name="targetObject">Target object</param>
        /// <param name="sourceObject">Source object</param>
        public static void CopyPropertiesExtension<T, T2>(this T targetObject, T2 sourceObject)
        {
            CopyProperties(targetObject, sourceObject);
        }
        /// <summary>
        /// This is method to copy properties from one type to another.
        /// In order to be copied, propeties need to be the same type and have the same name.
        /// </summary>
        /// <typeparam name="T">Target type</typeparam>
        /// <typeparam name="T2">Source type</typeparam>
        /// <param name="targetObject">Target object</param>
        /// <param name="sourceObject">Source object</param>
        public static T CopyPropertiesReturnExtension<T, T2>(this T targetObject, T2 sourceObject)
        {
            CopyProperties(targetObject, sourceObject);
            return targetObject;
        }

        private static object GetPropertyValue<T>(this T source, string propertyName)
        {
            return source.GetType().GetProperty(propertyName).GetValue(source, null);
        }

    }
}
