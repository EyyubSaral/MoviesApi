using MediatR;
using Microsoft.AspNetCore.Http;
using MoviesApi.Application.Bases;
using MoviesApi.Application.Features.Products.Rules;
using MoviesApi.Application.Interfaces.AutoMapper;
using MoviesApi.Application.Interfaces.UnitOfWorks;
using MoviesApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApi.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler :BaseHandler, IRequestHandler<CreateProductCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ProductRules productRules;
        public CreateProductCommandHandler(ProductRules productRules,IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor):base(mapper, unitOfWork, httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.productRules = productRules;
        }


        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            IList<Product> products = await unitOfWork.GetReadRepository<Product>().GetAllAsync();

            //   if (products.Any(x => x.Title == request.Title))
            //        throw new Exception("aynı başlıkta ürün olamaz");

            await productRules.ProductTitleMustNotBeSame(products, request.Title);

            foreach (var item in products)
            {
                if (item.Title == request.Title) { }
            }

            Product product = new(request.Title, request.Description,request.BrandId,request.Price,request.Discount);

            

            await unitOfWork.GetWriteRepository<Product>().AddAsync(product);
            if(await unitOfWork.SaveAsync() > 0)
            {
                foreach(var categoryId in request.CategoryIds)
                {
                    await unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new()
                    {
                        ProductId = product.Id,
                        CategoryId=categoryId
                    });

                    await unitOfWork.SaveAsync();
                }
            }
            return Unit.Value;
        
        }
    }
}
