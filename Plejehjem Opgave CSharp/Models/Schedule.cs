using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plejehjem_Opgave_CSharp.Models
{
    public class Schedule
    {

        [Key] public int ScheduleID { get; set; }

        //this is for the clock
        [Display(Name = "Klokken hvad skal borgeren besøges?")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Klokkesæt påkrævet")]
        public string visitingTime { get; set; }

        //this is for the specific DATE
        [Display(Name = "Hvilken dato skal borgeren besøges?")]
        [Column(TypeName = "date")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Dato påkrævet")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd-MM-yyyy}")]
        public DateTime DateForVisiting { get; set; }

        //FK to see what citizens to visit at that team
        [Display(Name="Hvilken borger skal besøges?")]
        [ForeignKey("FullCitizensInfo")] public int citizensRefId { get; set; }


        public FullCitizensInfo FullCitizensInfo { get; set; }

        //FK to see who needs to visit that citizen at that time.
        [Display(Name = "Hvilken medarbejde skal besøge borgeren?")]
        [ForeignKey("UserAccount")] public int userAccountRef { get; set; }


        public UserAccount UserAccount { get; set; }




    }
}