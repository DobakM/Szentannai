using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCardWizard.CoreLayer.Serializers
{
    public interface ISerializer
    {
        int Id { get; set; }
        string FileName { get; set; }
        string FilePath { get; set; }

        void Serialize<T>(object obj, params object[] parameters) where T : class, new();
        object Deserialize<T>(params object[] parameters) where T : class, new();
    }
}
