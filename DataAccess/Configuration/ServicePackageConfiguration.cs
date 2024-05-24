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
    public class ServicePackageConfiguration : IEntityTypeConfiguration<ServicePackage>
    {
        public void Configure(EntityTypeBuilder<ServicePackage> builder)
        {

            builder.ToTable("ServicePackages");

            builder.Property(x => x.Id)
            .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_INCREMENT_VALUE, increment: 1);

            builder.Property(x => x.Description)
            .HasMaxLength(1000)
            .IsRequired();

            builder.Property(x => x.Title)
             .HasMaxLength(250)
             .IsRequired();

            builder.Property(x => x.Price)
           .HasPrecision(7, 2);

            builder.Property(x => x.PhotoUrl)
           .HasMaxLength(250)
           .IsRequired();
        }
    }
}
