using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroWinForms.Image;

namespace IntroWinForms.ImageConverter
{
    public class NonLinearConverter<T> : MyImageConverter<T>,
        IMyImageConverterWithParams<T, double> where T : IMyImage

    {
        public NonLinearConverter()
        {
            NumberOfParams = 2;
            TypeOfParams = typeof(double);
        }
        public T Convert(T source, params double[] prms)
        {
            var dst = new MyImage(source.Width, source.Height); ;
            for (int i = 0; i < dst.Width; i++)
            for (int j = 0; j < dst.Height; j++)
            {
                double dR = prms[0] * Math.Pow(source[i, j].R, prms[1]);
                double dG = prms[0] * Math.Pow(source[i, j].G, prms[1]);
                double dB = prms[0] * Math.Pow(source[i, j].B, prms[1]);
                dst[i, j] = Color.FromArgb(Norm(dR), Norm(dG), Norm(dB));
            }

            object img = dst;
            return (T)img;
        }
    }
}
