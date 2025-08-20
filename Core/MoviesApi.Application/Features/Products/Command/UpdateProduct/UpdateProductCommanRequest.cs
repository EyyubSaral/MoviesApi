using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApi.Application.Features.Products.Command.UpdateProduct
{
    public class UpdateProductCommanRequest:IRequest<Unit>
    {

        public  int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int BrandId { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }

        public IList<int> CategoryIds { get; set; }
    }
}
