using Microsoft.EntityFrameworkCore;
using Proletarians.Data.Models;
using System;
using System.Collections.Generic;
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
            modelBuilder.Entity<Assign>().HasKey(sc => new { sc.ManagerId, sc.ResponsrbleFieldId });
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("Data Source=./../Proletarians.Data/Prometheus.db");
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite(@"Data Source=C:\Temp\Prometheus.db");
    }
}
