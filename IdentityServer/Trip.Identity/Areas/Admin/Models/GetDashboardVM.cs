using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trip.Identity.Areas.Admin.Models
{
    public class GetDashboardVM
    {

        public int Users { get; set; }
        public int Clients { get; set; }
        public int Roles { get; set; }
        public int Resources { get; set; }
        public int IdentityResources { get; internal set; }
        public int ApiResources { get; internal set; }
        public int ApiScopes { get; internal set; }
    }
}
