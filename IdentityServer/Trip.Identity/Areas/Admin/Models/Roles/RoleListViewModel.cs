using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trip.Identity.Areas.Admin.Models.Roles
{
    public class RoleListViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
    }

    public class CreateRoleViewModel
    {
        public string Name { get; set; }
    }
}
