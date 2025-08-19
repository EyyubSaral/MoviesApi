using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MoviesApi.Application.Interfaces.AutoMapper;


namespace MoviesApi.Mapper
{
    public static class Registration
    {
        public static void AddCustomMapper(this IServiceCollection services)
        {
            services.AddSingleton<MoviesApi.Application.Interfaces.AutoMapper.IMapper, MoviesApi.Mapper.AutoMapper.Mapper>();
        }
    }
}
