using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Application.Features.Products.Command.CreateProduct;
using MoviesApi.Application.Features.Products.Command.UpdateProduct;
using MoviesApi.Application.Features.Products.Queries.GetAllProducts;

namespace MoviesApi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts(GetAllProductsQueryRequest request) 
        {
            var response = await mediator.Send(request);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProducts(DeleteProductCommandRequest request)
        {
             await mediator.Send(request);

            return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> UpdateProducts(UpdateProductCommanRequest request)
        {
            await mediator.Send(request);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProducts(DeleteProductCommandRequest request)
        {
            await mediator.Send(request);

            return Ok();
        }


    }
}
