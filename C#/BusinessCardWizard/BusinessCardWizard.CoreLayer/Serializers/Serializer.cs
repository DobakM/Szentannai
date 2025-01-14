using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCardWizard.CoreLayer.Serializers
{
    public abstract class Serializer : ISerializer
    {
        public Serializer(int Id)
        {
            this.Id = Id;
        }

        public string FilePath
        {
            get { return Path.GetFullPath(Assembly.GetEntryAssembly().Location + $@"../../../../Json\{FileName}.txt"); }
            set { throw new NotImplementedException(); }
        }

        public int Id { get; set; }
        public string FileName { get; set; }
        public abstract void Serialize<T>(object obj, params object[] parameters) where T : class, new();
        public abstract object Deserialize<T>(params object[] parameters) where T : class, new();
    }
}
