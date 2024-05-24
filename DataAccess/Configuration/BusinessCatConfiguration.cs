using Core.DefaultValues;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configuration
{
    public class BusinessCatConfiguration : IEntityTypeConfiguration<BusinessCat>
    {
        public void Configure(EntityTypeBuilder<BusinessCat> builder)
        {
            builder.ToTable("Businesses");

            builder.Property(x => x.Id)
              .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_INCREMENT_VALUE, increment: 1);

            builder.Property(x => x.Description)
                 .IsRequired()
                 .HasMaxLength(1000);
            builder.Property(x => x.Title)
                 .IsRequired()
                 .HasMaxLength(100);
            builder.Property(x => x.Points)
                .IsRequired()
                .HasMaxLength(1000);
        }
    }
}
