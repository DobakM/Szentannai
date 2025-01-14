using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCardWizard.CoreLayer.Loggers
{
    public interface ILogger
    {
        void SetFilePath(int UserId);
        void Configure();
        void Debug(string text);
        void Info(string text);
        void Warning(string text);
        void Error(string text);
        void Fatal(string text);

    }
}
