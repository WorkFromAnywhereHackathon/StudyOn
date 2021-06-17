using System;
using System.Collections.Generic;
using System.Text;

namespace StudyOn.Shared
{
    public class TeamDto
    {
        public Guid Id { get; set; }

        public Guid EventId { get; set; }     

        public string Name { get; set; }

        public string Idea { get; set; }

        public string Description { get; set; }

        public string PassportLink { get; set; }
    }
}
