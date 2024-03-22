using Ecom.core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.infrastructure.Data.config
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(30);

            builder.HasData(
                new Category
                {
                    Id = 1,
                    Name = "Category One ",
                    Description = "This is description related to category one "
                },
                new Category
                {
                    Id = 2,
                    Name = "Category two ",
                    Description = "This is description related to category two "
                },
                new Category
                {
                    Id = 3,
                    Name = "Category three",
                    Description = "This is description related to category three "
                }
                ); 

        }
    }
}
