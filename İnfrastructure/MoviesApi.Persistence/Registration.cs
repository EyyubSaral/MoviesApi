using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoviesApi.Application.Interfaces.Repositories;
using MoviesApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApi.Persistence
{
    public static class Registration
    {
        public static void AddPersistance(this IServiceCollection services,IConfiguration configuration) 
        {
            services.AddDbContext<AppDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped(typeof(IReadRepository<>),typeof(IReadRepository<>));
        }
    }
}
