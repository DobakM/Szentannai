using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCardWizard.CoreLayer.SerializerHelpers
{
    public interface ISerializerHelper
    {
        void Serialize<T>(object obj, params object[] parameters) where T : class, new();
        object Deserialize<T>(params object[] parameters) where T : class, new();
    }
}
