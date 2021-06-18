using System;
using System.Collections.Generic;
using System.Text;

namespace StudyOn.Shared
{
    public class AddTeamActivityModel
    {
        public Guid TeamId { get; set; }

        public DateTime Date { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string Link { get; set; }
    }
}
