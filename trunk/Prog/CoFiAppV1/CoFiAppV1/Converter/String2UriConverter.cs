using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CoFiAppV1.Converter
{
    class String2UriConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string imageName = value as string;
            if (string.IsNullOrWhiteSpace(imageName)) throw new ArgumentException("le nom de l'image doit être différent de null, vide ou blanc, et doit être un string.");

            Uri uri = new Uri(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\cofiapp\\trunk\\Prog\\CoFiAppV1\\CoFiAppV1\\img\\" + $"{imageName}", UriKind.RelativeOrAbsolute);
            return uri;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
