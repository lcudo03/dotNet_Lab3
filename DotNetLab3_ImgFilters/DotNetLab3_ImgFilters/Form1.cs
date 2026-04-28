using System.Diagnostics;

namespace DotNetLab3_ImgFilters;

public partial class Form1 : Form
{
    private Bitmap? originalImage;

    public Form1()
    {
        InitializeComponent();
    }

    private void buttonLoad_Click(object sender, EventArgs e)
    {
        openFileDialog1.Filter = "Image files (*.jpg;*.png;*.bmp)|*.jpg;*.png;*.bmp|All files (*.*)|*.*";

        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            originalImage = new Bitmap(openFileDialog1.FileName);
            pictureBoxOriginal.Image = originalImage;

            pictureBoxGray.Image = null;
            pictureBoxNegative.Image = null;
            pictureBoxThreshold.Image = null;
            pictureBoxMirror.Image = null;

            labelTime.Text = "Czas:";
        }
    }
    private void buttonProcess_Click(object sender, EventArgs e)
    {
        if (originalImage == null)
        {
            MessageBox.Show("Najpierw wczytaj obraz.");
            return;
        }

        Bitmap copyGray = new Bitmap(originalImage);
        Bitmap copyNegative = new Bitmap(originalImage);
        Bitmap copyThreshold = new Bitmap(originalImage);
        Bitmap copyMirror = new Bitmap(originalImage);

        Bitmap? gray = null;
        Bitmap? negative = null;
        Bitmap? threshold = null;
        Bitmap? mirror = null;

        Stopwatch stopwatch = Stopwatch.StartNew();

        Thread t1 = new Thread(() =>
        {
            gray = ImageProcessor.ToGrayScale(copyGray);
        });

        Thread t2 = new Thread(() =>
        {
            negative = ImageProcessor.ToNegative(copyNegative);
        });

        Thread t3 = new Thread(() =>
        {
            threshold = ImageProcessor.Threshold(copyThreshold);
        });

        Thread t4 = new Thread(() =>
        {
            mirror = ImageProcessor.Mirror(copyMirror);
        });

        t1.Start();
        t2.Start();
        t3.Start();
        t4.Start();

        t1.Join();
        t2.Join();
        t3.Join();
        t4.Join();

        stopwatch.Stop();

        pictureBoxGray.Image = gray;
        pictureBoxNegative.Image = negative;
        pictureBoxThreshold.Image = threshold;
        pictureBoxMirror.Image = mirror;

        labelTime.Text = $"Czas: {stopwatch.ElapsedMilliseconds} ms";
    }
}