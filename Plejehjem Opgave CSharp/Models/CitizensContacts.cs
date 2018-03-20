using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Plejehjem_Opgave_CSharp.Models
{
    public class CitizensContacts
    {
        [Key]
        public int ContactID { get; set; }

        public string JobTitle { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Firstname is required")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Lastname is required")]
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

     
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        public string otherInformation { get; set; }

        public string relationToCitizens { get; set; }


        //foreign key to see what citizens this specific contact is related to.
        [ForeignKey("FullCitizensInfo")]
        public int citizensRefId { get; set; }
        public FullCitizensInfo FullCitizensInfo { get; set; }


        //FK to CitizensInformation about who has these specific contacts
        //Job title: String
        //fullName: String <--- only one that is required
        //phone nuimber: String
        //email: String
        //other information
        //relation: string
    }
}