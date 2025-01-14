using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Imaging;
using BusinessCardWizard.Configuration;
using Application = System.Windows.Application;

namespace BusinessCardWizard
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Builder.Initialize();
            LoggerConfig.GetInstance().logger.SetFilePath(0);
            SerializerConfig.GetInstance().serializer.FileName = "contacts";

            AppDomain.CurrentDomain.UnhandledException += ScreenShot;

        }

        private static void ScreenShot(object sender, UnhandledExceptionEventArgs e)
        {
            Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics graphics = Graphics.FromImage(bitmap);

            graphics.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);

            string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports");
            string path = Path.Combine(dir, string.Format("{0:yyyyMMddhhmmss}.jpg", DateTime.Now));

            if(!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            bitmap.Save(path, ImageFormat.Jpeg);
        }
    }
}
