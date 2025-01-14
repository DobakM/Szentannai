using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCardWizard.CoreLayer.Serializers
{
    public class JsonSerializer : Serializer
    {
        public JsonSerializer(int id) : base(id)
        {
        }

        public override void Serialize<T>(object obj, params object[] parameters) where T : class
        {
            string data = JsonConvert.SerializeObject(obj, Formatting.Indented,

            new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,

                ReferenceLoopHandling = ReferenceLoopHandling.Serialize
            });

            //FileName = parameters[0] as string;
            File.WriteAllText(FilePath, data);
        }

        public override object Deserialize<T>(params object[] parameters) where T : class
        {
            string data = File.ReadAllText(FilePath);

            return JsonConvert.DeserializeObject<IEnumerable<T>>(data);
        }
    }
}
