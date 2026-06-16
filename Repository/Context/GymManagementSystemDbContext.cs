using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Context
{
    public class GymManagementSystemDbContext : DbContext
    {
        public GymManagementSystemDbContext(DbContextOptions<GymManagementSystemDbContext> options) : base(options) { }
        public DbSet<AttendenceRecord> AttendenceRecords { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<FitnessClass> FitnessClasses { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<MembershipPlan> MembershipPlans { get; set; }
        public DbSet<MembershipSubscription> MembershipSubscriptions { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Trainer> Trainers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
