using System;
using System.Collections.Generic;
using System.Text;

namespace StudyOn.Shared
{
    public class AddFeedbackModel
    {       

        public Guid TeamId { get; set; }      

        public Guid ExpertId { get; set; }      

        public string Problems { get; set; }

        public string Ideas { get; set; }

        public string Support { get; set; }

        public bool ShareAnswers { get; set; }
    }
}
