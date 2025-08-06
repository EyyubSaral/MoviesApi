using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApi.Persistence.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(256);

            Bogus.Faker faker = new("tr");

            Brand brand1 = new() 
            {
                Id = 2, 
                Name = faker.Commerce.Department(),
                CreatedDate= DateTime.Now,
                isDeleted = false,
            };

            Brand brand2 = new()
            {
                Id = 1,
                Name = faker.Commerce.Department(),
                CreatedDate = DateTime.Now,
                isDeleted = false,
            };

            Brand brand3 = new()
            {
                Id = 3,
                Name = faker.Commerce.Department(),
                CreatedDate = DateTime.Now,
                isDeleted = true,
            };

            builder.HasData(brand1, brand2, brand3);
        }
    }
}
