using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip.Domain.Common.Entities
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime Modified { get; set; } = DateTime.Now;

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }
    }
}
