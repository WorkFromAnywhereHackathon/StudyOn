using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyOn.Server.Entities
{
    public class Customer:BaseEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<EducationEvent> Events { get; set; }
    }
}
