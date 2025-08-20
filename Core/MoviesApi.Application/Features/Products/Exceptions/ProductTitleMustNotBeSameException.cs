using MoviesApi.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApi.Application.Features.Products.Exceptions
{
    public class ProductTitleMustNotBeSameException: BaseExceptions
    {
        public ProductTitleMustNotBeSameException():base("Ürün Başlığı zaten var") { }
        
    }
}
