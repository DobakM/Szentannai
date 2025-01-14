using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCardWizard.DataAccessLayer.Model
{
    [Serializable]
    public class Address : Notifier
    {
        private string city;
        private string country;
        private string state;
        private string line1;
        private string line2;
        private string zip;

        [JsonProperty("zip")]
        public string Zip
        {
            get { return zip; }
            set
            {
                zip = value;
                OnPropertyChanged("Zip");
            }
        }

        [JsonProperty("city")]
        public string City
        {
            get { return city; }
            set
            {
                city = value;
                OnPropertyChanged("City");
            }
        }

        [JsonProperty("country")]
        public string Country
        {
            get { return country; }
            set
            {
                country = value;
                OnPropertyChanged("country");
            }
        }

        [JsonProperty("state")]
        public string State
        {
            get { return state; }
            set
            {
                state = value;
                OnPropertyChanged("State");
            }
        }

        [JsonProperty("line1")]
        public string Line1
        {
            get { return line1; }
            set
            {
                line1 = value;
                OnPropertyChanged("Line1");
            }
        }

        [JsonProperty("line2")]
        public string Line2
        {
            get { return line2; }
            set
            {
                line2 = value;
                OnPropertyChanged("Line2");
            }
        }
    }
    
}