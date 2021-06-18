using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyOn.Server.Entities
{
    public class TeamActivity : BaseEntity
    {
        public Guid Id { get; set; }

        public Guid TeamId { get; set; }

        public Team Team { get; set; }

        public DateTime Date { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public string Link { get; set; }
    }
}
