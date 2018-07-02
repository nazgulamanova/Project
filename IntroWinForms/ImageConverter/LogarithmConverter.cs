using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroWinForms.Image;

namespace IntroWinForms.ImageConverter
{
    public class LogarithmConverter<T> : MyImageConverter<T>,
        IMyImageConverterWithParam<T, double> where T : IMyImage

    {
        public LogarithmConverter()
        {
            NumberOfParams = 1;
            TypeOfParams = typeof(double);
        }

        public T Convert(T source, double c)
        {
            var dst = new MyImage(source.Width, source.Height); ;
            for (int i = 0; i < dst.Width; i++)
            for (int j = 0; j < dst.Height; j++)
            {
                double dR = c * Math.Log(1 + source[i, j].R);
                double dG = c * Math.Log(1 + source[i, j].G);
                double dB = c * Math.Log(1 + source[i, j].B);
                dst[i, j] = Color.FromArgb(Norm(dR), Norm(dG), Norm(dB));
            }

            object img = dst;
            return (T)img;
        }
    }
}
