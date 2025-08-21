using MediatR;
using Microsoft.AspNetCore.Http;
using MoviesApi.Application.Bases;
using MoviesApi.Application.Interfaces.AutoMapper;
using MoviesApi.Application.Interfaces.UnitOfWorks;
using MoviesApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApi.Application.Features.Products.Command.DeleteProduct
{
    public class DeleteProductCommandHandler :BaseHandler, IRequestHandler<DeleteProductCommandRequest,Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
           var product = await unitOfWork
                .GetReadRepository<Product>()
                .GetAsync(x => x.Id == request.Id && !x.isDeleted);
            product.isDeleted=false;

            await unitOfWork.GetWriteRepository<Product>().UpdateAsync(product);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
