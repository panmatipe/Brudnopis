using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Brudnopis
{
    internal static class Extensions
    {
        public static string GetEnumDescription(this Enum obj)
        {
            try
            {
                FieldInfo fieldInfo = obj.GetType().GetField(obj.ToString());

                object[] attribArray = fieldInfo.GetCustomAttributes(false);

                if (attribArray.Length > 0)
                {
                    var attrib = attribArray[0] as DescriptionAttribute;

                    if (attrib != null)
                        return attrib.Description;
                }
                return obj.ToString();
            }
            catch (NullReferenceException ex)
            {
                return "Unknown";
            }
        }
    }
}
