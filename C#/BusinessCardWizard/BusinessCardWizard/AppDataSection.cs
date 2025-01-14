using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessCardWizard
{
    public class AppDataSection : ConfigurationSection
    {
        private static AppDataSection settings = ConfigurationManager.GetSection("AppDataSettings") as AppDataSection;

        public static AppDataSection Settings
        {
            get { return AppDataSection.settings; }
        }


        [ConfigurationProperty("logger", IsRequired = true)]
        public string Logger
        {
            get
            {
                return this["logger"] as string;
            }
            set
            {
                this["logger"] = value;
            }
        }

        [ConfigurationProperty("loggerDirectoryFilePath", IsRequired = true)]
        public string LoggerDirectoryFilePath
        {
            get
            {
                return this["loggerDirectoryFilePath"] as string;
            }
            set
            {
                this["loggerDirectoryFilePath"] = value;
            }
        }

        [ConfigurationProperty("serializer", IsRequired = true)]
        public string Serializer
        {
            get
            {
                return this["serializer"] as string;
            }
            set
            {
                this["serializer"] = value;
            }
        }

        [ConfigurationProperty("serializerHelper", IsRequired = true)]
        public string SerializerHelper
        {
            get
            {
                return this["serializerHelper"] as string;
            }
            set
            {
                this["serializerHelper"] = value;
            }
        }
    }
}
