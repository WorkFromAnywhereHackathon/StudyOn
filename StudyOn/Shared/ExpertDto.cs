using System;
using System.Collections.Generic;
using System.Text;

namespace StudyOn.Shared
{
    public class ExpertDto
    {

        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Description { get; set; }

        public string Photo { get; set; }

        public string Name { get { return $"{FirstName} {LastName}"; } }
    }
}
