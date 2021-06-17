using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace StudyOn.Shared
{
    public class AddEventModel
    {
        public AddEventModel()
        {
            Experts = new ObservableCollection<ExpertDto>();
            Meetings = new ObservableCollection<MeetingDto>();
            Tags = new List<string>();
            StartDate = DateTime.Now;
            EndDate = DateTime.Now.AddDays(2);
        }

        public Guid Id { get; set; }

        public Guid CustomerId { get; set; }

        public string Name { get; set; }

        public string Theme { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Description { get; set; }

        public IEnumerable<string> Tags { get; set; }

        public ObservableCollection<ExpertDto> Experts { get; set; }

        public ObservableCollection<MeetingDto> Meetings { get; set; }
    }
}
