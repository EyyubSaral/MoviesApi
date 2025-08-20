using MoviesApi.Application.Bases;
using MoviesApi.Application.Features.Products.Exceptions;
using MoviesApi.Domain.Entities;


namespace MoviesApi.Application.Features.Products.Rules
{
    public class ProductRules : BaseRules
    {
        public Task ProductTitleMustNotBeSame(IList<Product> products,string requestTtile) 
        {
            if (products.Any(x => x.Title == requestTtile)) throw new ProductTitleMustNotBeSameException();
            return Task.CompletedTask;
        }
    }
}
