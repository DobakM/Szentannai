using BusinessCardWizard.CoreLayer.Loggers;
using BusinessCardWizard.CoreLayer.SerializerHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCardWizard.ApplicationLayer.Services
{
    public abstract class DataService<T> : IDataService<T> where T : class, new()
    {
        public Logger logger;
        public SerializerHelper serializerHelper;
        public List<T> repository;

        public DataService(SerializerHelper serializerHelper, Logger logger)//SerializerBase serializer, Logger logger
        {
            this.serializerHelper = serializerHelper;
            this.logger = logger; 

            //this.serializer = serializer;
            //this.collection = collection;
            //this.repository = null;
        }

        public abstract void Save(T entity);
        public abstract void Delete(T entity);
        public abstract List<T> FindAll();
        public abstract List<T> Find(string LookupName);
        public abstract void Serialize();
        public abstract void Deserialize();
    }
}
