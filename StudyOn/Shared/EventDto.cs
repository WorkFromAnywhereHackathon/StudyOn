using System;
using System.Collections.Generic;
using System.Text;

namespace StudyOn.Shared
{
    public class EventDto
    {
        public Guid Id { get; set; }

        public Guid CustomerId { get; set; }       
     
        public string Name { get; set; }

        public string Theme { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Description { get; set; }

        public List<string> Tags { get; set; }       
    }
}
