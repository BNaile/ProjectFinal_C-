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
    public class IntroConfiguration : IEntityTypeConfiguration<Intro>
    {

        public void Configure(EntityTypeBuilder<Intro> builder)
        {
            builder.ToTable("Introes");

            builder.Property(x => x.Id)
                 .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_INCREMENT_VALUE, increment: 1);
            builder.Property(x => x.Title)
             .HasMaxLength(250)
             .IsRequired();


            builder.Property(x => x.Description)
            .HasMaxLength(1000)
            .IsRequired();

            builder.Property(x => x.Name)
               .IsRequired()
               .HasMaxLength(100);

            builder.Property(x => x.Surname)
             .IsRequired()
             .HasMaxLength(100);

            builder.Property(x => x.PhotoUrl)
           .IsRequired()
           .HasMaxLength(250);

        }
    }
}
