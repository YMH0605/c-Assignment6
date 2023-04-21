using System;
using System.Net.NetworkInformation;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ApplicationCore.Entities;


namespace Infrastructure.Data
{
	public class RecruitingDbContext : DbContext
    {
        public RecruitingDbContext(DbContextOptions<RecruitingDbContext> option) : base(option)
        {
        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<JobRequirement> JobRequirements { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }
        public DbSet<EmployeeType> EmployeeTypes { get; set; }
        public DbSet<EmployeeRequirementType> EmployeeRequirementTypes { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeRequirementType>(ConfigureEmployeeRequirementType);
            modelBuilder.Entity<EmployeeType>(ConfigureEmployeeType);
        }

        private void ConfigureEmployeeRequirementType(EntityTypeBuilder<EmployeeRequirementType> builder)
        {
            builder.ToTable("EmployeeRequirementTypes");

            builder.HasKey(e => new {e.EmployeeTypeId, e.JobRequirementId});

            builder.HasOne(a => a.EmployeeType).WithMany(b => b.EmployeeRequirementTypes).HasForeignKey(b => b.EmployeeTypeId);

            builder.HasOne(a => a.JobRequirement).WithMany(b => b.EmployeeRequirementTypes).HasForeignKey(b => b.JobRequirementId);
        }

        private void ConfigureEmployeeType(EntityTypeBuilder<EmployeeType> builder)
        {
            builder.ToTable("EmployeeTypes");

            builder.HasKey(et => et.Id);

            builder.Property(n => n.TypeName).HasMaxLength(128);
        }


    }

		
}

