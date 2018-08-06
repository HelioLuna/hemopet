using System;
using Xamarin.Forms;

namespace hemopet.Core.Converters
{
    public class SuspensionPointsConverter : IValueConverter
    {
        private string originalTexto;
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string texto = originalTexto = value as string;
            string numeroCaracteres = parameter as string;

            if (!string.IsNullOrEmpty(texto) && !string.IsNullOrEmpty(numeroCaracteres))
            {
                if (texto.Length > int.Parse(numeroCaracteres))
                {
                    return String.Concat(texto.Substring(0, int.Parse(numeroCaracteres)), "...");
                }
                else
                {
                    return texto;
                }
            }

            return originalTexto;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return originalTexto;
        }

    }
}
