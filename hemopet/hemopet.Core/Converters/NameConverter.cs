using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;

namespace hemopet.Core.Converters
{
    public class NameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string fullName = value as string;
            if (!String.IsNullOrEmpty(fullName))
            {

                List<string> names = fullName.Split(' ').ToList();
                string firstName = names.First();
                string lastName = names.Last();

                if (firstName == lastName || String.IsNullOrEmpty(firstName) || String.IsNullOrEmpty(lastName))
                    return String.IsNullOrEmpty(firstName) ? lastName : firstName;

                return firstName + " " + lastName;
            }

            return fullName;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value as string;
        }
    }
}
