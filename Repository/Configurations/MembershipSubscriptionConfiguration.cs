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
    public class MembershipSubscriptionConfiguration : IEntityTypeConfiguration<MembershipSubscription>
    {
        public void Configure(EntityTypeBuilder<MembershipSubscription> builder)
        {
            builder.Property(m => m.Status)
                   .IsRequired()
                   .HasMaxLength(75);


            ////////////////////////////////////////////////////////////////////
            builder.HasOne(m => m.Member)
                   .WithMany(m => m.MembershipSubscriptions)
                   .HasForeignKey(m => m.MemberID)
                   .OnDelete(DeleteBehavior.NoAction);


            builder.HasOne(m => m.MembershipPlan)
                   .WithMany(m => m.MembershipSubscriptions)
                   .HasForeignKey(m => m.MembershipPlanID)
                   .OnDelete(DeleteBehavior.NoAction);


            builder.HasMany(m => m.Payments)
                   .WithOne(m => m.MembershipSubscription)
                   .HasForeignKey(m => m.MembershipSubscriptionID)
                   .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
