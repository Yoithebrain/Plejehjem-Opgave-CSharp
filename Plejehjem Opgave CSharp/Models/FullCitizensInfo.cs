using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plejehjem_Opgave_CSharp.Models
{
    public class FullCitizensInfo
    {
        public string CPRNumber { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string bloodtype { get; set; }

        public string sicknesses { get; set; }

        public string intolerentTo { get; set; }
        public string mentalDisorders { get; set; }
        public string remarks { get; set; }

    }
}