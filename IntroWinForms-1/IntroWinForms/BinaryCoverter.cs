using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing; 

namespace IntroWinForms
{
    public class BinaryCoverter<T> : MyImageConverter<T>,
                     IMyImageConverterWithParam<T, int> where T : IMyImage
    {
        public T Convert(T source, int bound)
        {
            var converter = new GrayscaleConverter<T>();
            var dst = new MyImage(source.Width, source.Height);
            object img = dst;
            img = converter.Convert(source);
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    int recolor = dst[i, j].R > bound ? 255 : 0;
                    dst[i, j] = Color.FromArgb(recolor, recolor, recolor);
                }
            }
            return (T)img;


        }



    }
}
