using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroWinForms.Image;

namespace IntroWinForms.ImageConverter
{
    public class GrayWorldConverter<T> : MyImageConverter<T>, IMyImageConverterDefault<T> where T : IMyImage
    {
        public GrayWorldConverter()
        {
            NumberOfParams = 0;
            TypeOfParams = null;
        }
        public T Convert(T source)
        {
            var dist = new MyImage(source.Width, source.Height);
            double Ra = 0, Ba = 0, Ga = 0;
            double Avg = 0;
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    Color color = source[i, j];
                    Ra += color.R;
                    Ba += color.B;
                    Ga += color.G;
                }
            }

            Ra = Ra / (source.Width * source.Height);
            Ba = Ba / (source.Width * source.Height);
            Ga = Ga / (source.Width * source.Height);

            Avg = (Ra + Ba + Ga) / 3;

            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    Color color = source[i, j];
                    Color newcolor =
                        Color.FromArgb(
                            Norm(color.R * Avg / Ra),
                            Norm(color.G * Avg / Ga),
                            Norm(color.B * Avg / Ba));
                    dist[i, j] = newcolor;
                }
            }
            object img = dist;
            return (T)img;
        }
    }
}
