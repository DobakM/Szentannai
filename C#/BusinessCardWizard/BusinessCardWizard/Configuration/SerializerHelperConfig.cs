using BusinessCardWizard.CoreLayer.SerializerHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCardWizard.Configuration
{
    public class SerializerHelperConfig
    {
        private static SerializerHelperConfig serializerHelperConfig;

        public SerializerHelper serializerHelper { get; set; }

        private SerializerHelperConfig()
        {

        }

        public static SerializerHelperConfig GetInstance()
        {
            if (serializerHelperConfig == null)
            {
                serializerHelperConfig = new SerializerHelperConfig();
            }
            return serializerHelperConfig;
        }
    }
}
