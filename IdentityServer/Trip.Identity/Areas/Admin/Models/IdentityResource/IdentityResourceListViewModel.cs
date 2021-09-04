using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trip.Identity.Areas.Admin.Models.IdentityResource
{
    public class IdentityResourceListViewModel
    {
        public bool Enabled
        {
            get;
            set;
        }


        public string Name
        {
            get;
            set;
        }

        //
        // Summary:
        //     Display name of the resource.
        public string DisplayName
        {
            get;
            set;
        }

        //
        // Summary:
        //     Description of the resource.
        public string Description
        {
            get;
            set;
        }

        //
        // Summary:
        //     Specifies whether this scope is shown in the discovery document. Defaults to
        //     true.
        public bool ShowInDiscoveryDocument
        {
            get;
            set;
        }


    }
}
