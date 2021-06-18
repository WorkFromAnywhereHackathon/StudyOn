using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyOn.Server.Entities
{
    public class Expert: BaseEntity
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Description { get; set; }

        public string Photo { get; set; }

        public ICollection<EventExpert> Events { get; set; }

        public ICollection<MasterClass> MasterClasses { get; set; }
        
        public ICollection<TeamFeedback> Feedbacks { get; set; }



    }
}
