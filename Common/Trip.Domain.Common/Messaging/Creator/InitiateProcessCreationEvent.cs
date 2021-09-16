using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip.Domain.Common.Messaging.Creator
{
    public  class InitiateProcessCreationEvent : BaseCompletedEvent
    {
        public string CreationId { get; set; }
    }
}
