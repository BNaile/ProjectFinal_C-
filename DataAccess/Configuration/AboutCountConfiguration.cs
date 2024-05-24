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
    public class AboutCountConfiguration : IEntityTypeConfiguration<AboutCount>
    {
        public void Configure(EntityTypeBuilder<AboutCount> builder)
        {
           
                builder.ToTable("AboutCounts");

                builder.Property(x => x.Id)
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_INCREMENT_VALUE, increment: 1);

      
                builder.Property(x => x.Count)
                     .IsRequired()
                     .HasMaxLength(100000);
            
        }
    }
}
