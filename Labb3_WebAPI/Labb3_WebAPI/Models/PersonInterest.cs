using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Labb3_WebAPI.Models
{
    public class PersonInterest
    {
        [Key]
        public int PersonInterestId { get; set; }
        [Required]
        public int PersonId { get; set; }
        public Person Person { get; set; }
        [Required]
        public int InterestId { get; set; }
        public Interest Interest { get; set; }

    }
}
