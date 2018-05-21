using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Plejehjem_Opgave_CSharp.Models
{
    public class GoogleMapsInformation
    {
        //this is related to "fullcitizensinfo" because we need to know the address to generate the LAT and LONG of the position

        [Key]
        public int AddressID { get; set; }

        public double Latitude { get; set; }

        public double Longtitude { get; set; }

        //foreign key to see what citizens this specific contact is related to.
        [ForeignKey("FullCitizensInfo")]
        public int citizensRefId { get; set; }
        public FullCitizensInfo FullCitizensInfo { get; set; }


    }
}