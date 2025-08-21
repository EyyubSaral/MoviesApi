using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApi.Application.Features.Auth.Command.RefreshToken
{
    public class RefreshTokenCommanValidator: AbstractValidator<RefreshTokenCommanRequest>
    {
        public RefreshTokenCommanValidator()
        {
            RuleFor(x => x.AccessToken).NotEmpty();

            RuleFor(x => x.RefreshToken).NotEmpty(); 
        }
    }
}
