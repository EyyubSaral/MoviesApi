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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            Category category1 = new()
            {
                Id = 1,
                Name = "Elektirik",
                Priorty=1,
                ParentID=0,
                isDeleted=false,
                CreatedDate=DateTime.Now,
            };

            Category category2 = new()
            {
                Id = 2,
                Name = "Moda",
                Priorty = 2,
                ParentID = 0,
                isDeleted = false,
                CreatedDate = DateTime.Now,
            };

            Category parent1 = new()
            {
                Id = 3,
                Name = "Bilgisayar",
                Priorty = 1,
                ParentID = 1,
                isDeleted = false,
                CreatedDate = DateTime.Now,
            };

            Category parent2 = new()
            {
                Id = 4,
                Name = "Kadın",
                Priorty = 1,
                ParentID = 2,
                isDeleted = false,
                CreatedDate = DateTime.Now,
            };

            builder.HasData(category1,category2,parent1,parent2);
        }
    }
}
