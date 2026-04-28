using System;
using System.Windows.Forms;

namespace DotNetLab3_ImgFilters
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}