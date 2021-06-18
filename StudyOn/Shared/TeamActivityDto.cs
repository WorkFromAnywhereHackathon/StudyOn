using System;
using System.Collections.Generic;
using System.Text;

namespace StudyOn.Shared
{
    public class TeamActivityDto
    {
        public Guid Id { get; set; }

        public Guid TeamId { get; set; }
       
        public DateTime Date { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public string Link { get; set; }
    }
}
