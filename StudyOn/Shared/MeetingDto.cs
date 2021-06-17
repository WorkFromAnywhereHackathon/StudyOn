using System;
using System.Collections.Generic;
using System.Text;

namespace StudyOn.Shared
{
    public class MeetingDto
    {
        public MeetingDto()
        {
            StartTime = DateTime.Now;
            EndTime = DateTime.Now.AddHours(1);
        }

        public Guid Id { get; set; }

        public Guid EventId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public Guid? ExpertId { get; set; }
    }

    //public class MasterClassDto : MeetingDto
    //{
    //    public MasterClassDto()
    //    {

    //    }

    //    public MasterClassDto(MeetingDto meeting)
    //    {
    //        Id = meeting.Id;
    //        EventId = meeting.EventId;
    //        Name = meeting.Name;
    //        Description = meeting.Description;
    //        StartTime = meeting.StartTime;
    //        EndTime = meeting.EndTime;
    //    }

    //    public Guid ExpertId { get; set; }
    //}
}
