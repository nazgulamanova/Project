using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroWinForms
{
    public interface IMyImage
    {
        int Width { get; }
        int Height { get; }
        Color this[int row, int column] { get; set; }
        Color Min { get; }
        Color Max { get; }
        void ConvertToBitmap(Bitmap bitmap);
    }
    
    public class MyImage : IMyImage
    {
        private readonly Color[,] _image;
        private Color _max = Color.FromArgb(0,0,0);
        private Color _min = Color.FromArgb(0,0,0);
        
        private void CheckMinMax(Color color)
        {
            int maxR = _max.R, minR = _min.R, maxG = _max.G, minG = _min.G, maxB = _max.B, minB = _min.B;
            if (color.R > _max.R)
                maxR = color.R;
            if (color.B > _max.B)
                maxB = color.B;
            if (color.G > _max.G)
                maxG = color.G;
            if (color.R < _min.R)
                minR = color.R;
            if (color.G < _min.G)
                minG = color.G;
            if (color.B < _min.B)
                minB = color.B;
            _max = Color.FromArgb(maxR, maxG, maxB);
            _min = Color.FromArgb(minR, minG, minB);
        }

        private void SetPixel(int x, int y, Color color)
        {
            _image[x, y] = color;
            CheckMinMax(color);
        }
        public MyImage(int width, int height)
        {
            Width = width;
            Height = height;
            _image = new Color[Width, Height];
        }
        public MyImage(Bitmap bitmap) : this(bitmap.Width, bitmap.Height) 
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    SetPixel(i, j, bitmap.GetPixel(i, j));
                }
            }
        }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Color this[int row, int column]
        {
            get => _image[row, column];
            set => SetPixel(row, column, value);
        }
        public Color Max => _max;
        public Color Min => _min;

        public void ConvertToBitmap(Bitmap bitmap)
        {
            for (int i = 0; i < bitmap.Width; i++)
                for (int j = 0; j < bitmap.Height; j++)
                    bitmap.SetPixel(i, j, _image[i, j]);
        }

        
    }

    public interface IMyImageConverterDefault<T> where T : IMyImage
    {
        T Convert(T source);
    }

    public interface IMyImageConverterWithParams<T> where T : IMyImage
    {
        T Convert(T source, double c, double gamma);
    }
    public abstract class MyImageConverter<T> where T : IMyImage
    {
        //public abstract T Convert(T source);
    }

    public class GrayscaleConverter<T>  
                    : MyImageConverter<T>,
                     IMyImageConverterDefault<T> where T : IMyImage
                    
    {
        public T Convert(T source)
        {
            var dist = new MyImage(source.Width, source.Height);
            for (int i = 0; i< dist.Width;i++)
                for (int j = 0; j < dist.Height; j++)
                {
                    int newcolor = (int) (0.299 * source[i, j].R + 
                                          0.587 * source[i, j].G + 
                                          0.114 * source[i, j].B);
                    dist[i, j] = Color.FromArgb(newcolor, newcolor, newcolor);
                }
            object img = dist;
            return (T) img;
        }

    }

    public class GrayWorldConverter<T>
                    : MyImageConverter<T>,
                     IMyImageConverterDefault<T> where T : IMyImage
    {
        public T Convert(T source)
        {
            var dist = new MyImage(source.Width, source.Height);
            double Ra = 0, Ba = 0, Ga = 0;
            double Avg = 0;
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    Color color = source[i,j];
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
                            (int)(color.R * Avg / Ra),
                            (int)(color.G * Avg / Ga),
                            (int)(color.B * Avg / Ba));
                    dist[i,j] = newcolor;
                }
            }
            object img = dist;
            return (T)img;
        }
    }

    public class NonLinearConverter<T>
                    : MyImageConverter<T>,
                    IMyImageConverterWithParams<T> where T : IMyImage
    {
        private int Norm(double x)
        {
            return x > 255 ? 255 : (int) x;
        }

        public T Convert(T source, double c, double gamma)
        {
            var dist = new MyImage(source.Width, source.Height);
            for (int i = 0; i < dist.Width; i++)
                for (int j = 0; j < dist.Height; j++)
                {
                    double dr = c * Math.Pow(source[i, j].R, gamma);
                    double dg = c * Math.Pow(source[i, j].G, gamma);
                    double db = c * Math.Pow(source[i, j].B, gamma);
                    dist[i, j] = Color.FromArgb(Norm(dr), Norm(dg), Norm(db));
                }
            object img = dist;
            return (T)img;
        
        
             
        }


    }
}
