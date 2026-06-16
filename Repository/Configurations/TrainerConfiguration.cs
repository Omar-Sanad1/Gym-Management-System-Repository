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
    public class TrainerConfiguration : IEntityTypeConfiguration<Trainer>
    {
        public void Configure(EntityTypeBuilder<Trainer> builder)
        {
            builder.Property(t => t.FullName)
                   .IsRequired()
                   .HasMaxLength(250);

            builder.Property(t => t.Specialization)
                   .IsRequired()
                   .HasMaxLength(75);

            builder.Property(t => t.Certifications)
                   .IsRequired()
                   .HasMaxLength(250);

            builder.Property(t => t.PhoneNumber)
                   .IsRequired()
                   .HasMaxLength(250);

            builder.Property(t => t.EmailAddress)
                   .IsRequired()
                   .HasMaxLength(250);

            builder.Property(t => t.PasswordHash)
                   .IsRequired()
                   .HasMaxLength(250);

            //////////////////////////////////////////////////////////////////
            builder.HasMany(t => t.FitnessClasses)
                   .WithOne(t => t.Trainer)
                   .HasForeignKey(t => t.TrainerID)
                   .OnDelete(DeleteBehavior.NoAction);
            

            builder.HasMany(t => t.Members)
                  .WithOne(t => t.Trainer)
                  .HasForeignKey(t => t.TrainerID)
                  .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
