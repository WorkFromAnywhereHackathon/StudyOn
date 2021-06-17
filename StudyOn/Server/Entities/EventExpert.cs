using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyOn.Server.Entities
{
    public class EventExpert
    {
        public Guid EventId { get; set; }

        public Guid ExpertId { get; set; }

        public EducationEvent Event { get; set; }

        public Expert Expert { get; set; }
    }
}
