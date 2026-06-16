
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
    public class Member_FitnessClass_EnrollConfiguration : IEntityTypeConfiguration<Member_FitnessClass_Enroll>
    {
        public void Configure(EntityTypeBuilder<Member_FitnessClass_Enroll> builder)
        {
            builder.HasKey(mf => new
            {
                mf.MemberID,
                mf.FitnessClassID
            });

            builder.HasOne(mf => mf.Member)
                   .WithMany(mf => mf.Member_FitnessClasses)
                   .HasForeignKey(mf => mf.MemberID)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(mf => mf.FitnessClass)
                   .WithMany(mf => mf.Member_FitnessClasses)
                   .HasForeignKey(mf => mf.FitnessClassID)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
