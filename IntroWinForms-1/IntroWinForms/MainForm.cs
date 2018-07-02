using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntroWinForms
{
    public partial class MainForm : Form
    {
        private readonly Dictionary<string, MyImageConverter<IMyImage>> _converters =
                                        new Dictionary<string, MyImageConverter<IMyImage>>();
        public MainForm()
        {
            InitializeComponent();
            ListLoad();
        }

        private void ListLoad()
        {
            lstConverts.Items.Add("Оттенки серого");
            _converters.Add("Оттенки серого", new GrayscaleConverter<IMyImage>());
            lstConverts.Items.Add("Серый мир");
            _converters.Add("Серый мир", new GrayWorldConverter<IMyImage>());
            lstConverts.Items.Add("Нелинейная коррекция");
            _converters.Add("Нелинейная коррекция", new NonLinearConverter<IMyImage>());

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pbcSource.Load(openFileDialog.FileName);
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (lstConverts.SelectedIndex < 0)
            {
                MessageBox.Show("Надо выбрать конвертер");
                return;
            }

            var converter = _converters[lstConverts.SelectedItem.ToString()];

            double c;
            double gamma;
            Double.TryParse(txtC.Text, out c);
            Double.TryParse(txtC.Text, out gamma);

            if (converter is IMyImageConverterWithParams<IMyImage>)
            {
                
                if (c <= 0 || gamma <= 0)
                {
                    MessageBox.Show("Надо заполнить C и Gamma");
                    return;
                }
            }

            using (Bitmap bitmap = new Bitmap(pbcSource.Image))
            {

                var dstbitmap = new Bitmap(pbcSource.Image);

                if (converter is IMyImageConverterDefault<IMyImage> @default)
                {
                    var dst = @default.Convert(new MyImage(bitmap));
                    dst.ConvertToBitmap(dstbitmap);
                }

                if (converter is IMyImageConverterWithParams<IMyImage> @params)
                {
                    var dst = @params.Convert(new MyImage(bitmap), c, gamma);
                    dst.ConvertToBitmap(dstbitmap);
                }

                pbxDest.Image?.Dispose();
                pbxDest.Image = dstbitmap;
            }
        }

    }
}
