using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlowOut.Models
{
    [Table("Client")]
    public class Client
    {
        [Key]
        public int clientID { get; set; }

        [Required]
        [StringLength(30)]
        public string firstname { get; set; }

        [Required]
        [StringLength(30)]
        public string lastname { get; set; }

        [Required]
        [StringLength(50)]
        public string address { get; set; }

        [Required]
        [StringLength(30)]
        public string city { get; set; }

        [Required]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Please include two letter state abreviation")]
        public string state { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{5}$", ErrorMessage = "Please use correct, 5 digit zip code")]
        public int zip { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Required]
        [RegularExpression(@"^\([0-9]{3}\)-[0-9]{3}-[0-9]{4}$", ErrorMessage = "Please enter correct phone number including (xxx)-xxx-xxxx")]
        [StringLength(14)]
        public string phone { get; set; }
    }
}