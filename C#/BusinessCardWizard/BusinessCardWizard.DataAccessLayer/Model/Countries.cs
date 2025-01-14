using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCardWizard.DataAccessLayer.Model
{
    public static class Countries
    {
        private static List<string> countries { get; set; }
        static Countries()
        {
            countries = new List<string>()
            {
                "Ausztria",
                "Belgium",
                "Bulgária",
                "Ciprus",
                "Csehország",
                "Dánia",
                "Észtország",
                "Finnország",
                "Franciaország",
                "Görögország",
                "Hollandia",
                "Horvátország",
                "Írország",
                "Lettország",
                "Lengyelország",
                "Litvánia",
                "Luxemburg",
                "Magyarország",
                "Málta",
                "Németország",
                "Olaszország",
                "Portugália",
                "Románia",
                "Spanyolország",
                "Svédország",
                "Szlovákia",
                "Szlovénia"
            };
        }

        public static IEnumerable<string> GetCountries()
        {
            return countries;
        }
    }
}
