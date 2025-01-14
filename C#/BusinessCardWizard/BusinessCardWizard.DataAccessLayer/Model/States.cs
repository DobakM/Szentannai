using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCardWizard.DataAccessLayer.Model
{
    public static class States
    {
        private static List<string> states { get; set; }
        static States()
        {
            states = new List<string>()
            {
                "Alabama",
                "Alaska",
                "Arizona",
                "Arcansas",
                "California"

                //todo

            };
        }

        public static IEnumerable<string> GetStates()
        {
            return states;
        }
    }
}
