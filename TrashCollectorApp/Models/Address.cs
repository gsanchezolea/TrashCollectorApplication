using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollectorApp.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [MaxLength(2)]
        public string State { get; set; }

        [Required]
        [Display(Name = "Zip Code")]
        [MaxLength(5)]
        public int ZipCode { get; set; }
    }
}
