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
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.Property(p => p.PaymentMethod)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.PaymentStatus)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.PaymentAmount)
                   .IsRequired()
                   .HasColumnType("decimal(16,2)");

            builder.Property(p => p.TransactionReferenceNumber)
                  .IsRequired()
                  .HasMaxLength(250);

            builder.Property(p => p.RelatedMembershipSubscription)
                 .IsRequired()
                 .HasMaxLength(150);
        }
    }
}
