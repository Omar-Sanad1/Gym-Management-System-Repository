using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configurations
{
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.Property(b => b.BranchName)
                   .IsRequired()
                   .HasMaxLength(250);

            builder.Property(b => b.Location)
                  .IsRequired()
                  .HasMaxLength(100);

            builder.Property(b => b.ContactInformation)
                 .IsRequired()
                 .HasMaxLength(75);

            builder.Property(b => b.CurrentOperationalStatus)
                 .IsRequired()
                 .HasMaxLength(75);


            /////////////////////////////////////////////////////////////
            builder.HasMany(b => b.FitnessClasses)
                   .WithOne(b => b.Branch)
                   .HasForeignKey(b => b.BranchID)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(b => b.Members)
                   .WithOne(b => b.Branch)
                   .HasForeignKey(b => b.BranchID)
                   .OnDelete(DeleteBehavior.NoAction);
            

            builder.HasMany(b => b.Trainers)
                   .WithOne(b => b.Branch)
                   .HasForeignKey(b => b.BranchID)
                   .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
