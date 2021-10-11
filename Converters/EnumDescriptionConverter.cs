using System;
using System.Globalization;
using System.Windows.Data;
using System.Reflection;
using System.ComponentModel;

namespace TrinusBank.Converters
{
    public class EnumDescriptionConverter : IValueConverter
    {
        public bool Uppercase { get; set; } = false;
        public static string GetEnumDescription(Enum enumObj)
        {
            FieldInfo fieldInfo = enumObj.GetType().GetField(enumObj.ToString());

            object[] attribArray = fieldInfo.GetCustomAttributes(false);

            if (attribArray.Length == 0)
            {
                return enumObj.ToString();
            }
            else
            {
                DescriptionAttribute attrib = attribArray[0] as DescriptionAttribute;
                return attrib.Description;
            }
        }

        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            if (string.IsNullOrEmpty(value.ToString())) return null;
            Enum myEnum = (Enum)value;
            string description = GetEnumDescription(myEnum);
            if (Uppercase) return description.ToUpper();
            else return description;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Empty;
        }
    }
}
