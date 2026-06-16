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
    public class AttendenceRecordConfiguration : IEntityTypeConfiguration<AttendenceRecord>
    {
        public void Configure(EntityTypeBuilder<AttendenceRecord> builder)
        {
            builder.Property(a => a.AttendanceType)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(a => a.Category)
                  .IsRequired()
                  .HasMaxLength(100);

            ///////////////////////////////////////////////////////////////
            builder.HasOne(a => a.FitnessClass)
                   .WithMany(a => a.AttendenceRecords)
                   .HasForeignKey(a => a.FitnessClassID)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(a => a.Member)
                   .WithMany(a => a.AttendenceRecords)
                   .HasForeignKey(a => a.MemberID)
                   .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
