using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCardWizard.DataAccessLayer.Model
{
    [Serializable]
    public class Contact : Notifier
    {
        private Address address = new Address();
        private Guid id = Guid.Empty;

        private string company;
        private string jobTitle;
        private string fullName;
        private string firstName;
        private string lastName;
        private string imagePath;
        private string homePhone;
        private string cellPhone;
        private string officePhone;
        private string organization;
        private string primaryEmail;
        private string secondaryEmail;

        [JsonProperty("id")]
        public Guid Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        [JsonProperty("imagePath")]
        public string ImagePath
        {
            get { return imagePath; }
            set
            {
                imagePath = value;
                OnPropertyChanged("ImagePath");
            }
        }

        [JsonProperty("company")]
        public string Company
        {
            get { return company; }
            set
            {
                company = value;
                OnPropertyChanged("Company");
            }
        }

        [JsonProperty("firstName")]
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
                OnPropertyChanged("FullName");
            }
        }

        [JsonProperty("lastName")]
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
                OnPropertyChanged("FullName");
            }
        }

        [JsonProperty("organization")]
        public string Organization
        {
            get { return organization; }
            set
            {
                organization = value;
                OnPropertyChanged("Organization");
            }
        }

        [JsonProperty("jobTitle")]
        public string JobTitle
        {
            get { return jobTitle; }
            set
            {
                jobTitle = value;
                OnPropertyChanged("JobTitle");
            }
        }

        [JsonProperty("officePhone")]
        public string OfficePhone
        {
            get { return officePhone; }
            set
            {
                officePhone = value;
                OnPropertyChanged("OfficePhone");
            }
        }

        [JsonProperty("cellPhone")]
        public string CellPhone
        {
            get { return cellPhone; }
            set
            {
                cellPhone = value;
                OnPropertyChanged("CellPhone");
            }
        }

        [JsonProperty("homePhone")]
        public string HomePhone
        {
            get { return homePhone; }
            set
            {
                homePhone = value;
                OnPropertyChanged("HomePhone");
            }
        }

        [JsonProperty("primaryEmail")]
        public string PrimaryEmail
        {
            get { return primaryEmail; }
            set
            {
                primaryEmail = value;
                OnPropertyChanged("PrimaryEmail");
            }
        }

        [JsonProperty("secondaryEmail")]
        public string SecondaryEmail
        {
            get { return secondaryEmail; }
            set
            {
                secondaryEmail = value;
                OnPropertyChanged("SecondaryEmail");
            }
        }

        [JsonProperty("address")]
        public Address Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }

        public string FullName
        {
            get { return string.Format("{0} {1}", firstName, lastName); }
            set
            {
                fullName = value;
                OnPropertyChanged("FullName");
            }
        }

        public bool Same(object obj)
        {
            Contact contact = obj as Contact;

            return contact != null && contact.Id.Equals(Id);
        }

        /*
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return FullName;
        }

        public override bool Equals(object obj)
        {
            Contact contact = obj as Contact;
            return contact != null && contact.Id == Id;
        }
        */
    }
}
