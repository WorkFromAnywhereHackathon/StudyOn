using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyOn.Server.Entities
{
    public class TeamFeedback:BaseEntity
    {
        public Guid Id { get; set; }

        public Guid TeamId { get; set; }

        public Team Team { get; set; }

        public Guid ExpertId { get; set; }

        public Expert Expert { get; set; }

        public string Problems { get; set; }

        public string Ideas { get; set; }

        public string Support { get; set; }
    }
}
