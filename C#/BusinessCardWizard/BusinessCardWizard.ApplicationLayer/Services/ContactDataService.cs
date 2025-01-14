using BusinessCardWizard.CoreLayer.Loggers;
using BusinessCardWizard.CoreLayer.SerializerHelpers;
using BusinessCardWizard.DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCardWizard.ApplicationLayer.Services
{
    public class ContactDataService : DataService<Contact>
    {
        public ObservableCollection<Contact> collection { get; set; }
        public ContactDataService(SerializerHelper serializerHelper, Logger logger) : base(serializerHelper, logger)
        {
            this.serializerHelper = serializerHelper;
            this.logger = logger;

           // Deserialize();
        }

        public override List<Contact> FindAll()
        {
            return this.repository;
        }

        public override void Delete(Contact contact)
        {
            collection.Remove(contact);

            Serialize();
        }

        public override void Save(Contact contact)
        {
            if (contact.Id == Guid.Empty)
            {
                contact.Id = Guid.NewGuid();
            }

            if (!collection.Contains(contact))
            {
                collection.Add(contact);
            }

            Serialize();
        }

        public override List<Contact> Find(string LookupName)
        {
            List<Contact> contacts = repository.FindAll(delegate (Contact contact) { return contact.FullName.StartsWith(LookupName, StringComparison.OrdinalIgnoreCase); });

            return contacts;
        }

        public override void Serialize()
        {
            serializerHelper.Serialize<Contact>(collection);
        }

        public override void Deserialize()
        {
            repository = serializerHelper.Deserialize<Contact>(null) as List<Contact>;

            //repository = null ?? new List<Contact>();

            //collection = new ObservableCollection<Contact>(repository);

            if (repository is null)
            {
                collection = new ObservableCollection<Contact>();
            }
            else
            {
                collection = new ObservableCollection<Contact>(repository);
            }

        }
    }
}
