using Core.DefaultValues;
using DataAccess.Concrete;
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
    public class IntroServiceConfiguration : IEntityTypeConfiguration<IntroCat>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<IntroCat> builder)
        {
            builder.ToTable("IntroServices");

            builder.Property(x => x.Id)
            .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_INCREMENT_VALUE, increment: 1);

            builder.Property(x => x.Title)
             .HasMaxLength(250)
             .IsRequired();

            builder.Property(x => x.Description)
            .HasMaxLength(1000)
            .IsRequired();

            builder.Property(x => x.Icon)
            .HasMaxLength(250)
            .IsRequired();

        }


    }

    
}
