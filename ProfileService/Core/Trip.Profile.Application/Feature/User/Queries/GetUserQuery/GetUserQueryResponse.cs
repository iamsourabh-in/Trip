using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip.Profile.Application.Feature.User.Queries.GetUserQuery
{
    public class GetUserQueryResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public bool Active { get; set; }
        public bool Approved { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
