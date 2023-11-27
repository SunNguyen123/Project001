using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.IO;
using System.Windows.Media.Imaging;
using System.Drawing.Imaging;
using System.Windows.Media;
using System.Drawing;

namespace Resource
{
    public class ConvertImg : IValueConverter
    {
        public static byte[] cvimg(string path)
        {
            Image img = Image.FromFile(path);
            byte[] bf;
            using (MemoryStream memory = new MemoryStream()) 
            {
                img.Save(memory, System.Drawing.Imaging.ImageFormat.Jpeg);
                 bf= memory.ToArray();               
                return bf;
            }
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            byte[] imgsrc = (byte[])value;

            var image = new BitmapImage();
            using (var mem = new MemoryStream(imgsrc))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;



        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
