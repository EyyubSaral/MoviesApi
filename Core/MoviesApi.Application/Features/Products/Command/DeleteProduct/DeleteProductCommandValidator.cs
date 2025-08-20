using FluentValidation;
using MoviesApi.Application.Features.Products.Command.UpdateProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApi.Application.Features.Products.Command.DeleteProduct
{
    public  class DeleteProductCommandValidator : AbstractValidator<UpdateProductCommanRequest>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(x=>x.Id)
                .GreaterThan(0);
        }
    }
}
