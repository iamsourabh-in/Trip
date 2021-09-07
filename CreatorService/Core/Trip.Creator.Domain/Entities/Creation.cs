using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip.Creator.Domain.Entities
{
    public class Creation
    {
        public string Id { get; set; }

        [Required]
        public string ResourceURl { get; set; }

        [Required]
        public string ResourceMime { get; set; }

        [Required]
        public string Tags { get; set; }

        [Required]
        public string Tagline { get; set; }

        public bool Delete { get; set; }

        public bool Processed { get; set; }

        public bool Acknowledged { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }
    }
}
