using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Plejehjem_Opgave_CSharp.Models
{
    public class FullCitizensInfo
    {

        [Key] public int citizensID { get; set; }

        [Display(Name = "CPR Nummer")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "CPR Number is required")]
        public string CPRNumber { get; set; }

        [Display(Name = "Fornavn")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Fornavn er required")]
        public string firstName { get; set; }

        [Display(Name = "Efternavn")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Efternavn er required")]
        public string lastName { get; set; }

        [Display(Name = "Adresse")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Adresse er required")]
        public string address { get; set; }

        [Display(Name = "Blodtype")] public string bloodtype { get; set; }

        [Display(Name = "Kroniske sygdomme")] public string sicknesses { get; set; }

        [Display(Name = "Ting personen ikke kan tåle")]
        public String intolerentTo { get; set; }

        [Display(Name = "Psykiske lidelser")] public string mentalDisorders { get; set; }


        [Display(Name = "Bemærkninger")] public string remarks { get; set; }
    }


}