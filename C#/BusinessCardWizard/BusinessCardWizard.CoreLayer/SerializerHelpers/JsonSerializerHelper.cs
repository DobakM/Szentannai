using BusinessCardWizard.CoreLayer.Loggers;
using BusinessCardWizard.CoreLayer.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCardWizard.CoreLayer.SerializerHelpers
{
    public class JsonSerializerHelper : SerializerHelper
    {
        public JsonSerializerHelper(Serializer serializer, Logger logger) : base(serializer, logger)
        {
            this.serializer = serializer;
            this.logger = logger;
        }

        public override void Serialize<T>(object obj, params object[] parameters) where T : class
        {
            logger.Debug("Serialize");

            try
            {
                serializer.Serialize<T>(obj, parameters);

                logger.Debug("Succeed");
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }
        }

        public override object Deserialize<T>(params object[] parameters) where T : class
        {
            object obj = null;

            logger.Debug("Deserialize");

            try
            {
                obj = serializer.Deserialize<T>(parameters);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);

                return null;
            }

            logger.Debug("Succeed");

            return obj;
        }
    }
}
