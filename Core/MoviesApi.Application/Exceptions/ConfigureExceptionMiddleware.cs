using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApi.Application.Exceptions
{
    public static class ConfigureExceptionMiddleware
    {
        public static void ConfigureEcxeptionHandleMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExeceptionMiddleware>();
        }
    }
}
