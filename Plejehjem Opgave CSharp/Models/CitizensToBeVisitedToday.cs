using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plejehjem_Opgave_CSharp.Models
{
    public class CitizensToBeVisitedToday
    {

        public string vistingTimesToday { get; set; }
        public string dateToday { get; set; }

        public string CPRNumber { get; set; }


        public string citizensName { get; set; }

        public string address { get; set; }

        public double latitude { get; set; }

        public double longtitude { get; set; }
 
    }
}