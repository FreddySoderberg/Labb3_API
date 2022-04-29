using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Labb3_WebAPI.Models
{
    public class InterestLink
    {
        [Key]
        public int InterestLinkId { get; set; }
        [Required]
        public int InterestId { get; set; }
        public Interest Interest { get; set; }
        [Required]
        public int LinkId { get; set; }
        public Link Link { get; set; }

    }
}
