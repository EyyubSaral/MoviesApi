using MediatR;
using MoviesApi.Application.Interfaces.AutoMapper;
using MoviesApi.Application.Interfaces.UnitOfWorks;
using MoviesApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApi.Application.Features.Products.Command.UpdateProduct
{
    public class UpdateProductCommanHandler : IRequestHandler<UpdateProductCommanRequest>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UpdateProductCommanHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task Handle(UpdateProductCommanRequest request, CancellationToken cancellationToken)
        {
            var product = await unitOfWork
                .GetReadRepository<Product>()
                .GetAsync(x => x.Id == request.Id && !x.isDeleted);

            var map=mapper.Map<Product,UpdateProductCommanRequest>(request);

            var productCategories = await unitOfWork
                .GetReadRepository<ProductCategory>()
                .GetAllAsync(x => x.ProductId == product.Id);

            await unitOfWork.GetWriteRepository<ProductCategory>()
                .HardDeleteRangeAsync(productCategories);

            foreach (var categoryId in request.CategoryIds ) 
            {
                await unitOfWork.GetWriteRepository<ProductCategory>()
                       .AddAsync(new()
                       {
                           CategoryId = categoryId,
                           ProductId=product.Id
                       });

                await unitOfWork.GetWriteRepository<Product>().UpdateAsync(product);
                await unitOfWork.SaveAsync();
            
            }
        }
    }
}
