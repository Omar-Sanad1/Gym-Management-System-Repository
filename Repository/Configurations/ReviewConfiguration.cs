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
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.Property(r => r.Comment)
                   .IsRequired()
                   .HasMaxLength(150);

            ////////////////////////////////////////////////////////////////////
            builder.HasOne(r => r.Member)
                   .WithMany(r => r.Reviews)
                   .HasForeignKey(r => r.MemberID)
                   .OnDelete(DeleteBehavior.NoAction);


            builder.HasOne(r => r.Trainer)
                   .WithMany(r => r.Reviews)
                   .HasForeignKey(r => r.TrainerID)
                   .OnDelete(DeleteBehavior.NoAction);


            builder.HasOne(r => r.FitnessClass)
                 .WithMany(r => r.Reviews)
                 .HasForeignKey(r => r.FitnessClassID)
                 .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
