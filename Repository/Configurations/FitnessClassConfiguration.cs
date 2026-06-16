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
    public class FitnessClassConfiguration : IEntityTypeConfiguration<FitnessClass>
    {
        public void Configure(EntityTypeBuilder<FitnessClass> builder)
        {
            builder.Property(f => f.ClassName)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(f => f.Description)
                   .IsRequired()
                   .HasMaxLength(250);

            builder.Property(f => f.Category)
                   .IsRequired()
                   .HasMaxLength(100);

           
        }
    }
}
