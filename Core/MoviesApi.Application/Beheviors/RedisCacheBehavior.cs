using MediatR;
using MoviesApi.Application.Interfaces.RedisCache;
using MoviesApi.Application.Interfaces.RedisCatche;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApi.Application.Beheviors
{
    public class RedisCacheBehavior<TREquest, TResponse> : IPipelineBehavior<TREquest, TResponse>
    {
        private readonly IRedisCacheSercice redisCacheSercice;

        public RedisCacheBehavior(IRedisCacheSercice redisCacheSercice)
        {
            this.redisCacheSercice = redisCacheSercice;
        }

        public async Task<TResponse> Handle(TREquest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {

            if(request is ICacheableQuery query)
            {
                var cacheKey=query.CacheKey;
                var cacheTime=query.CacheTime;

                var cacheData= await redisCacheSercice.GetAsync<TResponse>(cacheKey);
                if (cacheData is not null)
                    return cacheData;

                var response = await next();
                if(response is not null)
                    await redisCacheSercice.SetAsync(cacheKey, response,DateTime.Now.AddMinutes(cacheTime));


                return response;
            }

            return await next();

        }
    }
}
