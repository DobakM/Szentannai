using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCardWizard.Configuration
{
    //Singleton
    public class LoggerDirectoryFilePathConfig
    {
        private static LoggerDirectoryFilePathConfig loggerDirectoryFilePathConfig;

        public string loggerDirectoryFilePath{ get; set; }

        private LoggerDirectoryFilePathConfig()
        {

        }

        public static LoggerDirectoryFilePathConfig GetInstance()
        {

            if (loggerDirectoryFilePathConfig == null)
            {
                loggerDirectoryFilePathConfig = new LoggerDirectoryFilePathConfig();
            }

            return loggerDirectoryFilePathConfig;
        }
    }

}
