using Mapster;
using Microsoft.EntityFrameworkCore;
using StudyOn.Server.Data;
using StudyOn.Server.Entities;
using StudyOn.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyOn.Server.Services
{
    public class EventService : IEventService
    {
        private readonly EducationContext context;

        public EventService(EducationContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<EducationEvent> AddAsync(AddEventModel model)
        {
            var educationEvent = model.Adapt<EducationEvent>();

            //move to map config
            if (model.Experts != null && model.Experts.Any())
            {
                educationEvent.Experts = new List<EventExpert>();
                foreach (var expert in model.Experts)
                {
                    educationEvent.Experts.Add(new EventExpert()
                    {
                        Expert = expert.Adapt<Expert>()
                    });
                }
            }

            context.Events.Add(educationEvent);
            await context.SaveChangesAsync();
            return educationEvent;
        }

        public Task<EventDto> GetByIdAsync(Guid eventId)
        {
            return context.Events
                 .ProjectToType<EventDto>()
                 .FirstOrDefaultAsync(x => x.Id == eventId);
        }

        public Task<List<EventDto>> GetAsync(Guid customerId)
        {
            return context.Events.Where(x => x.CustomerId == customerId)
                 .ProjectToType<EventDto>()
                 .ToListAsync();
        }

        public async Task<EducationEvent> UpdateAsync(AddEventModel model)
        {
            var educationEvent = await context.Events.FirstOrDefaultAsync(x => x.Id == model.Id);
            model.Adapt(educationEvent);
            await context.SaveChangesAsync();
            return educationEvent;
        }

        public async Task DeleteAsync(Guid eventId)
        {
            var educationEvent = await context.Events.FindAsync(eventId);
            context.Events.Remove(educationEvent);
            await context.SaveChangesAsync();
        }
    }
}
