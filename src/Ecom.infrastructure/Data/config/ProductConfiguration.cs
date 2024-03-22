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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(30);
            builder.Property(x => x.Price).HasColumnType("decimal(18,2)");
            //builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);


            builder.HasData(new Product
            {
                Id = 1,
                Name = "product one ",
                Description = "Description one ",
                Price = 1000,
                CategoryId = 1,
            },
            new Product
            {
                Id = 2,
                Name = "product two ",
                Description = "Description two ",
                Price = 2000,
                CategoryId = 2,
            }, 
            new Product
            {
                Id = 3,
                Name = "product three ",
                Description = "Description three ",
                Price = 3000,
                CategoryId = 3,
            });

        }
    }
}
