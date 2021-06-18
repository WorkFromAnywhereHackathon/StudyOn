using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyOn.Server.Entities
{
    public class Team
    {
        public Guid Id { get; set; }

        public Guid EventId { get; set; }

        public EducationEvent Event { get; set; }

        public string Name { get; set; }

        public string Idea { get; set; }
     
        public string Description { get; set; }

        public string PassportLink { get; set; }

        public ICollection<TeamActivity> Activities { get; set; }

        public ICollection<TeamFeedback> Feedbacks { get; set; }
    }
}
