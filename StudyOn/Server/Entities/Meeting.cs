using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudyOn.Server.Entities
{
    public class Meeting : BaseEntity
    {
        public Guid Id { get; set; }

        public Guid EventId { get; set; }

        public EducationEvent Event { get; set; }

        [Required]
        public string Name { get; set; }

        public string Descripion { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }       
    }
}
