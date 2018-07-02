using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using IntroWinForms.Image;

namespace IntroWinForms.ImageConverter
{
    public class BinaryConverter<T> : MyImageConverter<T>, IMyImageConverterWithParam<T, int> where T:IMyImage
    {
        public BinaryConverter()
        {
            NumberOfParams = 1;
            TypeOfParams = typeof(int);
        }
        public T Convert(T source, int bound)
        {
            var converter = new GrayscaleConverter<T>();
            var dst = new MyImage(source.Width, source.Height);
            object img = dst;
            img = converter.Convert(source);
            dst = (MyImage)img;
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    int rescolor = dst[i, j].R > bound ? 255 : 0;
                    dst[i, j] = Color.FromArgb(rescolor, rescolor, rescolor);
                }
            }
            img = dst;
            return (T)img;
        }
    }
}
