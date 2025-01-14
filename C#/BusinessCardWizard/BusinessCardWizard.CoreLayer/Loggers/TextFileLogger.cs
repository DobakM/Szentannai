using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCardWizard.CoreLayer.Loggers
{
    public class TextFileLogger : Logger
    {

        private DateTime date;

        public TextFileLogger(string directoryPath) : base(directoryPath)
        {

        }

        public override void Debug(string text)
        {
            File.AppendAllText(this.filePath, String.Format("{0}|{1}|{2}\r", "Debug", $"{DateTime.Now:yyyy-MM-dd-HH:mm:ss}", text));
        }

        public override void Error(string text)
        {
            File.AppendAllText(this.filePath, String.Format("{0}|{1}|{2}\r", "Error", $"{DateTime.Now:yyyy-MM-dd-HH:mm:ss}", text));
        }

        public override void Fatal(string text)
        {

            File.AppendAllText(this.filePath, String.Format("{0}|{1}|{2}\r", "Fatal", $"{DateTime.Now:yyyy-MM-dd-HH:mm:ss}", text));
        }

        public override void Info(string text)
        {

            File.AppendAllText(this.filePath, String.Format("{0}|{1}|{2}\r", "Info", $"{DateTime.Now:yyyy-MM-dd-HH:mm:ss}", text));

        }

        public override void Warning(string text)
        {

            File.AppendAllText(this.filePath, String.Format("{0}|{1}|{2}\r", "Warning", $"{DateTime.Now:yyyy-MM-dd-HH:mm:ss}", text));
        }

        public override void Configure()
        {

        }
    }
}
