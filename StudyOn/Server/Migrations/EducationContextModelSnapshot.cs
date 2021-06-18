﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudyOn.Server.Data;

namespace StudyOn.Server.Migrations
{
    [DbContext(typeof(EducationContext))]
    partial class EducationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StudyOn.Server.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("StudyOn.Server.Entities.EducationEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Theme")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("StudyOn.Server.Entities.EventExpert", b =>
                {
                    b.Property<Guid>("EventId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ExpertId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EventId", "ExpertId");

                    b.HasIndex("ExpertId");

                    b.ToTable("EventExperts");
                });

            modelBuilder.Entity("StudyOn.Server.Entities.Expert", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Experts");
                });

            modelBuilder.Entity("StudyOn.Server.Entities.Meeting", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descripion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EventId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Meetings");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Meeting");
                });

            modelBuilder.Entity("StudyOn.Server.Entities.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("EventId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Idea")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassportLink")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("StudyOn.Server.Entities.TeamActivity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("StudyOn.Server.Entities.TeamFeedback", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ExpertId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ideas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Problems")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Support")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ExpertId");

                    b.HasIndex("TeamId");

                    b.ToTable("TeamFeedbacks");
                });

            modelBuilder.Entity("StudyOn.Server.Entities.MasterClass", b =>
                {
                    b.HasBaseType("StudyOn.Server.Entities.Meeting");

                    b.Property<Guid>("ExpertId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("ExpertId");

                    b.HasDiscriminator().HasValue("MasterClass");
                });

            modelBuilder.Entity("StudyOn.Server.Entities.EducationEvent", b =>
                {
                    b.HasOne("StudyOn.Server.Entities.Customer", "Customer")
                        .WithMany("Events")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("StudyOn.Server.Entities.EventExpert", b =>
                {
                    b.HasOne("StudyOn.Server.Entities.EducationEvent", "Event")
                        .WithMany("Experts")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudyOn.Server.Entities.Expert", "Expert")
                        .WithMany("Events")
                        .HasForeignKey("ExpertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Expert");
                });

            modelBuilder.Entity("StudyOn.Server.Entities.Meeting", b =>
                {
                    b.HasOne("StudyOn.Server.Entities.EducationEvent", "Event")
                        .WithMany("Meetings")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("StudyOn.Server.Entities.Team", b =>
                {
                    b.HasOne("StudyOn.Server.Entities.EducationEvent", "Event")
                        .WithMany("Teams")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("StudyOn.Server.Entities.TeamActivity", b =>
                {
                    b.HasOne("StudyOn.Server.Entities.Team", "Team")
                        .WithMany("Activities")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("StudyOn.Server.Entities.TeamFeedback", b =>
                {
                    b.HasOne("StudyOn.Server.Entities.Expert", "Expert")
                        .WithMany("Feedbacks")
                        .HasForeignKey("ExpertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudyOn.Server.Entities.Team", "Team")
                        .WithMany("Feedbacks")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Expert");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("StudyOn.Server.Entities.MasterClass", b =>
                {
                    b.HasOne("StudyOn.Server.Entities.Expert", "Expert")
                        .WithMany("MasterClasses")
                        .HasForeignKey("ExpertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Expert");
                });

            modelBuilder.Entity("StudyOn.Server.Entities.Customer", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("StudyOn.Server.Entities.EducationEvent", b =>
                {
                    b.Navigation("Experts");

                    b.Navigation("Meetings");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("StudyOn.Server.Entities.Expert", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("Feedbacks");

                    b.Navigation("MasterClasses");
                });

            modelBuilder.Entity("StudyOn.Server.Entities.Team", b =>
                {
                    b.Navigation("Activities");

                    b.Navigation("Feedbacks");
                });
#pragma warning restore 612, 618
        }
    }
}
