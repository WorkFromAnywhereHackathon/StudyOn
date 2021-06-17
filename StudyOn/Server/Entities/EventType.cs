using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudyOn.Server.Entities
{
    public class EventType
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<EducationEvent> Events { get; set; }
    }
}
