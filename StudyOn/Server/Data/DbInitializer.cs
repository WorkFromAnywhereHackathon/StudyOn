using StudyOn.Server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyOn.Server.Data
{
    public static class DbInitializer
    {
        public static void Initialize(EducationContext context)
        {
            if (context.Customers.Any())
                return;

            var customer = new Customer()
            {
                Id=Guid.Parse("544c9ade-15fd-42e1-960e-41cbb963fedc"),
                Name = "Startup.by",
            };

            //customer.Events = new List<EducationEvent>();
            //customer.Events.Add(new EducationEvent()
            //{
            //    Name = "Экология",
            //    StartDate = DateTime.Today,
            //    EndDate = DateTime.Today.AddDays(2),
            //    Meetings = new List<Meeting>()
            //    {
            //        new Meeting()
            //        {
            //            Name = "Открытие Civic–Tech Hackathons. Экология.",
            //            Descripion = "Озвучиваются правила проведения хакатона. Предоставляется слово организаторам, экспертам и партнёрам",
            //            StartTime = DateTime.Now.AddMinutes(40),
            //            EndTime = DateTime.Now.AddMinutes(100)
            //        },
            //         new Meeting()
            //        {
            //            Name = " Питчинг участников / команд.",
            //            Descripion = "Представление идеи для хакатона и формирование команд",
            //            StartTime = DateTime.Now.AddMinutes(100),
            //            EndTime = DateTime.Now.AddMinutes(200)
            //        }
            //    }
            //}); ;

            context.Customers.Add(customer);
            context.SaveChanges();
        }
    }
}
