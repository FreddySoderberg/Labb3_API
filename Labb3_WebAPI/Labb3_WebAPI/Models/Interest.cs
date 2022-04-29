using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Labb3_WebAPI.Models
{
    public class Interest
    {
        [Key]
        public int InterestId { get; set; }
        public string InterestTitle { get; set; }
        public string InterestDescription { get; set; }

        public ICollection<InterestLink> InterestLinks { get; set; }
        public ICollection<PersonInterest> PersonInterests { get; set; }
    }
}
