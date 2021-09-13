using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trip.Creator.Domain.Entities
{
    public class Creation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string Tags { get; set; }

        [Required]
        public string Tagline { get; set; }

        public bool Delete { get; set; } = false;

        public bool Processed { get; set; } = false;

        public bool Acknowledged { get; set; } = false;

        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime Modified { get; set; } = DateTime.Now;

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public List<CreationResource> Resources { get; set; }
    }
}
