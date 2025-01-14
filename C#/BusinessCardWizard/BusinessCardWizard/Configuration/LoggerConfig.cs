using BusinessCardWizard.CoreLayer.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCardWizard.Configuration
{
    //Singleton
    public class LoggerConfig
    {
        private static LoggerConfig loggerConfig;

        public Logger logger { get; set; }

        private LoggerConfig()
        {

        }

        public static LoggerConfig GetInstance()
        {

            if (loggerConfig == null)
            {
                loggerConfig = new LoggerConfig();
            }

            return loggerConfig;
        }
    }
}
