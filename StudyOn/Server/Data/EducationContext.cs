using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StudyOn.Server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StudyOn.Server.Data
{
    public class EducationContext : DbContext
    {
        public EducationContext(DbContextOptions<EducationContext> options)
       : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<EducationEvent> Events { get; set; }
         
        public DbSet<EventExpert> EventExperts { get; set; }
        public DbSet<Expert> Experts { get; set; }

        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<MasterClass> MasterClasses { get; set; }

        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamActivity> Activities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //EventExpert
            modelBuilder.Entity<EventExpert>()
                .HasKey(x => new { x.EventId, x.ExpertId });

            modelBuilder.Entity<EventExpert>()
                    .HasOne(c => c.Event)
                    .WithMany(s => s.Experts)
                    .HasForeignKey(r => r.EventId);

            modelBuilder.Entity<EventExpert>()
                  .HasOne(c => c.Expert)
                  .WithMany(s => s.Events)
                  .HasForeignKey(r => r.ExpertId);
        }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangeTracker.DetectChanges();

            //created, updated dates
            var entries = ChangeTracker
                   .Entries()
                   .Where(e => e.Entity is BaseEntity && (
                           e.State == EntityState.Added
                           || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdatedAt = DateTime.UtcNow;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
                }
            }

            return await base.SaveChangesAsync();
        }
    }
}
