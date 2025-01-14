using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCardWizard.ApplicationLayer.Services
{
    public interface IDataService<T>
    {
        void Save(T entity);
        void Delete(T entity);
        void Serialize();
        void Deserialize();

        List<T> FindAll();
        List<T> Find(string LookupName);
    }
}
