using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Plejehjem_Opgave_CSharp.Models
{
    public class Schedule
    {

        [Key]
        public int ScheduleID { get; set; }
        
        //this is for the clock
        [Display(Name="visitingTime")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "VistingTime REQUIRED")]
        public string visitingTime { get; set; }

        //this is for the specific DATE
        [Display(Name = "DateForVisiting")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd-MM-yyyy}")]
        public DateTime DateForVisiting { get; set; }

        //FK to see what citizens to visit at that team
        [ForeignKey("FullCitizensInfo")]
        public int citizensRefId { get; set; }
   
        public FullCitizensInfo FullCitizensInfo { get; set; }

        //FK to see who needs to visit that citizen at that time.
        [ForeignKey("UserAccount")]
        public int userAccountRef { get; set; }
        public UserAccount UserAccount { get; set; }





        //visitingtime (clock)
        //DATE
        //Reference to adress from CitizenInformation
        //Reference to citizens name from CitizensInformation
        //Reference to citizensID from citizensInformation (FK)
        //Refernce to UserID from UserAccounts (To see whos schedule we're looking at)


    }
}