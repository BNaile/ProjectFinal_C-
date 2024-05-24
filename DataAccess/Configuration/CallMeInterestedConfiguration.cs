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
    public class CallMeInterestedConfiguration : IEntityTypeConfiguration<CallMeInterested>
    {
        public void Configure(EntityTypeBuilder<CallMeInterested> builder)
        {
            builder.ToTable("CallMeInteresteds");

            builder.Property(x => x.Id)
            .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_INCREMENT_VALUE, increment: 1);

            builder.Property(x => x.Details)
            .HasMaxLength(350)
            .IsRequired();

            builder.HasOne(x => x.CallMe)
             .WithMany(x => x.CallMeInterested)
             .HasForeignKey(x => x.CallMeId);
        }
    }
}
