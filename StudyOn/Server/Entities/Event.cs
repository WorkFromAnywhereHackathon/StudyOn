using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudyOn.Server.Entities
{
    public class EducationEvent : BaseEntity
    {
        public Guid Id { get; set; }

        public Guid CustomerId { get; set; }

        public Customer Customer { get; set; }

        [Required]
        public string Name { get; set; }

        public string Theme { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Description { get; set; }

        //public List<string> Tags { get; set; }

        public ICollection<Meeting> Meetings { get; set; }

        public ICollection<EventExpert> Experts { get; set; }

        public ICollection<Team> Teams { get; set; }
    }
}
