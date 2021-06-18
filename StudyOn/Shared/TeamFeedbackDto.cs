using System;
using System.Collections.Generic;
using System.Text;

namespace StudyOn.Shared
{
    public class TeamFeedbackDto
    {
        public Guid Id { get; set; }

        public Guid TeamId { get; set; }

        public ExpertDto Expert { get; set; }

        public string Problems { get; set; }

        public string Ideas { get; set; }

        public string Support { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool ShareAnswers { get; set; }
    }
}
