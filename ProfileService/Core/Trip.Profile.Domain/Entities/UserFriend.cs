using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip.Profile.Domain.Entities
{
	public class UserFriend
	{
        public string Id { get; set; }

        public string SourceId { get; set; }

        public string TargetId { get; set; }

        public bool Accepted { get; set; }

        public string Status { get; set; }

        public string Type { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }
    }
}
