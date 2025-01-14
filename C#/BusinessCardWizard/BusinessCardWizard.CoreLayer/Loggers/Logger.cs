using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCardWizard.CoreLayer.Loggers
{
    public abstract class Logger : ILogger
    {
        protected string directoryPath;
        public string filePath { get; set; }

        public Logger(string directoryPath)
        {
            this.directoryPath = directoryPath;
        }

        public abstract void Configure();
        public abstract void Debug(string text);
        public abstract void Error(string text);
        public abstract void Fatal(string text);
        public abstract void Info(string text);
        public abstract void Warning(string text);

        public void SetFilePath(int userId)
        {
            DateTime date = DateTime.Now;

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string fileName = $"{date:yyyyMMddHHmmss}_{userId}";
            string filePath = Path.Combine( directoryPath, fileName + ".txt");

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            this.filePath = filePath;

        }

    }
}
