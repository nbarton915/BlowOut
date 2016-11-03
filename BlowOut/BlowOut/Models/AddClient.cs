using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlowOut.Models
{
    public class AddClient
    {
        [Key]
        [ReadOnly(true)]
        public int clientID { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string firstname { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string lastname { get; set; }

        [Required]
        [DisplayName("Address")]
        public string address { get; set; }

        [Required]
        [DisplayName("City")]
        public string city { get; set; }

        [Required]
        [StringLength(2)]
        [DisplayName("City")]
        public string state { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{5}$")]
        [DisplayName("Zip")]
        public int zip { get; set; }

        [Required]
        [EmailAddress]
        [DisplayName("Email")]
        public string email { get; set; }

        [Required]
        [RegularExpression("@^([0-9]{3})-[0-9]{3}-[0-9]{4}")]
        [DisplayName("Phone Number")]
        public string phone { get; set; }

       //[Key]
        //public int instrumentID { get; set; }
        //public string description { get; set; }
        //public string type { get; set; }
        //public double price { get; set; }
        //public int clientID { get; set; }
    }
}