using Microsoft.EntityFrameworkCore;
using Proletarians.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proletarians.Data
{
    public class PrometheusContext : DbContext
    {
        public DbSet<AgeCategory> AgeCategorys { get; set; }
        public DbSet<Conferense> Conferenses { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Invitation> Invitations { get; set; }
        public DbSet<InvitationProfile> InvitationProfiles { get; set; }
        public DbSet<InvitationProfileResult> InvitationProfileResults { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Assign> Assigns { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<OrganizationProfile> OrganizationProfiles { get; set; }
        public DbSet<Outreach> Outreachs { get; set; }
        public DbSet<OutreachGroup> OutreachGroups { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<ReasonForCall> ReasonForCalls { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestResult> RequestResults { get; set; }
        public DbSet<ResponsrbleField> ResponsrbleFields { get; set; }
        public PrometheusContext()
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UsePropertyAccessMode(PropertyAccessMode.Property);
            modelBuilder.Entity<Assign>().HasKey(sc => new { sc.ManagerId, sc.ResponsrbleFieldId });
            //modelBuilder.Entity<Profile>().Property(p => p.FirstName)
            modelBuilder.Entity<Profile>().OwnsOne(p => p.Acquaintance).HasData(
                new { ProfileId = new Guid("50AE9655-27C5-456F-8F4E-4A6E949A2F44"), LocationId = new Guid("C06DEA75-2535-44CD-B0EB-B661D61A8276"), PeriodId = new Guid("9E8B1DF0-993B-47EF-9A14-99C1469D37C7") });
            modelBuilder.Entity<Profile>().HasData(
                    new
                    {
                        Id = new Guid("50AE9655-27C5-456F-8F4E-4A6E949A2F44"),
                        FirstName = "Олег",
                        LastName = "Крузенштейн",
                        MiddleName = "Леонидович",
                        SotialStatus = SotialStatus.Other,
                        Relation = Relation.Adherent,
                        OrganizationStatus = OrganizationStatus.Adherent,
                        ParticipantStatus = ParticipantStatus.Conferense
                    }
                );
            
            modelBuilder.Entity<Location>().HasData(
                    new Location { Id = new Guid("D69C5900-8F59-49DE-8CBF-F3444BF58B39"), Name = "Политех" },
                    new Location { Id = new Guid("C06DEA75-2535-44CD-B0EB-B661D61A8276"), Name = "Мужесво" },
                    new Location { Id = new Guid("C8D75D8C-A9C1-4265-910A-C395928A1682"), Name = "Девяткино" }
                );
            modelBuilder.Entity<Period>().HasData(
                    new { Id = new Guid("9E8B1DF0-993B-47EF-9A14-99C1469D37C7"), Start = DateTime.Now.AddYears(-1), Finish = DateTime.Now.AddMonths(-11) }
                );
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite(@"Data Source=.\..\Proletarians.Data\Prometheus.db");
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var path = @"C:\Database\";
            if(!Directory.Exists(path)) Directory.CreateDirectory(path);
            optionsBuilder.UseSqlite($@"Data Source={path}Prometheus.db").EnableSensitiveDataLogging();
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite(@"Data Source=C:\Temp\Prometheus.db");
    }
}
