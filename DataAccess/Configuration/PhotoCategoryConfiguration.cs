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
    public class PhotoCategoryConfiguration : IEntityTypeConfiguration<PhotoCategory>
    {
        public void Configure(EntityTypeBuilder<PhotoCategory> builder)
        {
            builder.ToTable("PhotoCategories");

            builder.Property(x => x.Id)
            .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_INCREMENT_VALUE, increment: 1);

            builder.Property(x => x.CategoryName)
                .IsRequired()
                .HasMaxLength(100);


            builder.HasMany(x => x.Photo)
             .WithOne(x => x.PhotoCategory)
             .HasForeignKey(x => x.PhotoCategoryId);
        }
    }
}
