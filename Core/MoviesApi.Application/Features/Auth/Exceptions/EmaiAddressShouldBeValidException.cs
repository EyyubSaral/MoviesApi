using MoviesApi.Application.Bases;

namespace MoviesApi.Application.Features.Auth.Exceptions
{
    public class EmaiAddressShouldBeValidException : BaseException
    {
        public EmaiAddressShouldBeValidException() : base("Böyle bir Email adresi bulunmamaktadır.") { }
    }
}

