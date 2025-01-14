using BusinessCardWizard.CoreLayer.Loggers;
using BusinessCardWizard.CoreLayer.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCardWizard.CoreLayer.SerializerHelpers
{
    public abstract class SerializerHelper : ISerializerHelper
    {
        public Serializer serializer { get; set; }
        public Logger logger { get; set; }

        public SerializerHelper(Serializer serializer, Logger logger)//
        {
            this.serializer = serializer;
            this.logger = logger;
        }

        public abstract void Serialize<T>(object obj, params object[] parameters) where T : class, new();
        public abstract object Deserialize<T>(params object[] parameters) where T : class, new();
    }
}
