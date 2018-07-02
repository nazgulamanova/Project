using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroWinForms.Image;

namespace IntroWinForms.ImageConverter
{
    public interface IMyImageConverterWithParam<T, in T1> where T : IMyImage

    {
        T Convert(T source, T1 c);
    }
}
