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
    public class CallMeConfiguration : IEntityTypeConfiguration<CallMe>
    {
        public void Configure(EntityTypeBuilder<CallMe> builder)
        {

            builder.ToTable("CallMes");

            builder.Property(x => x.Id)
            .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_INCREMENT_VALUE, increment: 1);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x=>x.Phone)
                .IsRequired()
                .HasMaxLength(13);

            builder.Property(x => x.Description)
              .HasMaxLength(1000)
              .IsRequired();

            builder.Property(x => x.Title)
             .HasMaxLength(250)
             .IsRequired();

            builder.Property(x => x.Email)
              .HasMaxLength(100)
              .IsRequired();

            //builder.HasIndex(x => x.Email)
            //    .IsUnique();
            builder.HasIndex(x => new { x.Email, x.Deleted })
                 .IsUnique()
                  .HasDatabaseName("idx_Email_Deleted");
        }
    }
}
