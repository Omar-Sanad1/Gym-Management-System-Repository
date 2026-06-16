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
    public class MembershipPlanConfiguration : IEntityTypeConfiguration<MembershipPlan>
    {
        public void Configure(EntityTypeBuilder<MembershipPlan> builder)
        {
            builder.Property(m => m.PlanName)
                   .IsRequired()
                   .HasMaxLength(250);

            builder.Property(m => m.Benefits)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(m => m.AccessLevel)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(m => m.Fee)
                   .IsRequired()
                   .HasColumnType("decimal(16,2)");



        }
    }
}
