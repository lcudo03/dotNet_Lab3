namespace DotNetLab3_ImgFilters;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    private PictureBox pictureBoxOriginal;
    private PictureBox pictureBoxGray;
    private PictureBox pictureBoxNegative;
    private PictureBox pictureBoxThreshold;
    private PictureBox pictureBoxMirror;
    private Button buttonLoad;
    private Button buttonProcess;
    private Label labelTime;
    private OpenFileDialog openFileDialog1;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        pictureBoxOriginal = new PictureBox();
        pictureBoxGray = new PictureBox();
        pictureBoxNegative = new PictureBox();
        pictureBoxThreshold = new PictureBox();
        pictureBoxMirror = new PictureBox();
        buttonLoad = new Button();
        buttonProcess = new Button();
        labelTime = new Label();
        openFileDialog1 = new OpenFileDialog();

        ((System.ComponentModel.ISupportInitialize)pictureBoxOriginal).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxGray).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxNegative).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxThreshold).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxMirror).BeginInit();

        SuspendLayout();

        pictureBoxOriginal.BorderStyle = BorderStyle.FixedSingle;
        pictureBoxOriginal.Location = new Point(20, 20);
        pictureBoxOriginal.Name = "pictureBoxOriginal";
        pictureBoxOriginal.Size = new Size(350, 300);
        pictureBoxOriginal.SizeMode = PictureBoxSizeMode.Zoom;

        pictureBoxGray.BorderStyle = BorderStyle.FixedSingle;
        pictureBoxGray.Location = new Point(400, 20);
        pictureBoxGray.Name = "pictureBoxGray";
        pictureBoxGray.Size = new Size(220, 140);
        pictureBoxGray.SizeMode = PictureBoxSizeMode.Zoom;

        pictureBoxNegative.BorderStyle = BorderStyle.FixedSingle;
        pictureBoxNegative.Location = new Point(650, 20);
        pictureBoxNegative.Name = "pictureBoxNegative";
        pictureBoxNegative.Size = new Size(220, 140);
        pictureBoxNegative.SizeMode = PictureBoxSizeMode.Zoom;

        pictureBoxThreshold.BorderStyle = BorderStyle.FixedSingle;
        pictureBoxThreshold.Location = new Point(400, 180);
        pictureBoxThreshold.Name = "pictureBoxThreshold";
        pictureBoxThreshold.Size = new Size(220, 140);
        pictureBoxThreshold.SizeMode = PictureBoxSizeMode.Zoom;

        pictureBoxMirror.BorderStyle = BorderStyle.FixedSingle;
        pictureBoxMirror.Location = new Point(650, 180);
        pictureBoxMirror.Name = "pictureBoxMirror";
        pictureBoxMirror.Size = new Size(220, 140);
        pictureBoxMirror.SizeMode = PictureBoxSizeMode.Zoom;

        buttonLoad.Location = new Point(20, 340);
        buttonLoad.Name = "buttonLoad";
        buttonLoad.Size = new Size(150, 35);
        buttonLoad.Text = "Wczytaj obraz";
        buttonLoad.UseVisualStyleBackColor = true;
        buttonLoad.Click += buttonLoad_Click;

        buttonProcess.Location = new Point(190, 340);
        buttonProcess.Name = "buttonProcess";
        buttonProcess.Size = new Size(180, 35);
        buttonProcess.Text = "Przetwórz równolegle";
        buttonProcess.UseVisualStyleBackColor = true;
        buttonProcess.Click += buttonProcess_Click;

        labelTime.AutoSize = true;
        labelTime.Location = new Point(400, 350);
        labelTime.Name = "labelTime";
        labelTime.Size = new Size(37, 15);
        labelTime.Text = "Czas:";

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(900, 400);
        Controls.Add(pictureBoxOriginal);
        Controls.Add(pictureBoxGray);
        Controls.Add(pictureBoxNegative);
        Controls.Add(pictureBoxThreshold);
        Controls.Add(pictureBoxMirror);
        Controls.Add(buttonLoad);
        Controls.Add(buttonProcess);
        Controls.Add(labelTime);
        Name = "Form1";
        Text = "Przetwarzanie obrazów";

        ((System.ComponentModel.ISupportInitialize)pictureBoxOriginal).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxGray).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxNegative).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxThreshold).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxMirror).EndInit();

        ResumeLayout(false);
        PerformLayout();
    }
}