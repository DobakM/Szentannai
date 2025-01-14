using BusinessCardWizard.CoreLayer.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCardWizard.Configuration
{
    public class SerializerConfig
    {
        private static SerializerConfig serializerConfig;

        public Serializer serializer { get; set; }

        private SerializerConfig()
        {

        }

        public static SerializerConfig GetInstance()
        {
            if (serializerConfig == null)
            {
                serializerConfig = new SerializerConfig();
            }

            return serializerConfig;
        }

    }
}
