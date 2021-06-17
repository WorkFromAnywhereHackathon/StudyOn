using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyOn.Server.Entities
{
    public class MasterClass : Meeting
    {
        public Guid ExpertId { get; set; }

        public Expert Expert { get; set; }
    }
}
