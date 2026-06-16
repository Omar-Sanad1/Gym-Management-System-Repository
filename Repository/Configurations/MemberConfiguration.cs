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
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.Property(m => m.FullName)
                  .IsRequired()
                  .HasMaxLength(250);

            builder.Property(m => m.PhoneNumber)
                  .IsRequired()
                  .HasMaxLength(250);

            builder.Property(m => m.EmailAddress)
                  .IsRequired()
                  .HasMaxLength(250);

            builder.Property(m => m.PaswordHash)
                  .IsRequired()
                  .HasMaxLength(250);
        }
    }
}
