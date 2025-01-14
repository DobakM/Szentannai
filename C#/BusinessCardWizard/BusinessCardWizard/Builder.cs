using BusinessCardWizard.Configuration;
using BusinessCardWizard.CoreLayer.Loggers;
using BusinessCardWizard.CoreLayer.SerializerHelpers;
using BusinessCardWizard.CoreLayer.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BusinessCardWizard
{

    // logger ="TextFileLogger" serializer ="JsonSerializer" serializerHelper ="JsonSerializerHelper"  loggerDirectoryFilePath="Logs"
    public static class Builder
    {
        public static void Initialize()
        {
           
            Type loggerType = Type.GetType($"BusinessCardWizard.CoreLayer.Loggers.{AppDataSection.Settings.Logger}, BusinessCardWizard.CoreLayer");
            Type serializerType = Type.GetType($"BusinessCardWizard.CoreLayer.Serializers.{AppDataSection.Settings.Serializer}, BusinessCardWizard.CoreLayer");
            Type serializerHelperType = Type.GetType($"BusinessCardWizard.CoreLayer.SerializerHelpers.{AppDataSection.Settings.SerializerHelper}, BusinessCardWizard.CoreLayer");

            LoggerConfig.GetInstance().logger = (Logger)Activator.CreateInstance(loggerType, new object[] {AppDataSection.Settings.LoggerDirectoryFilePath });
            SerializerConfig.GetInstance().serializer = (Serializer)Activator.CreateInstance(serializerType, new object[] {0});
            SerializerHelperConfig.GetInstance().serializerHelper = (SerializerHelper)Activator.CreateInstance(serializerHelperType, new object[] { SerializerConfig.GetInstance().serializer, LoggerConfig.GetInstance().logger });
        }
    }
}
