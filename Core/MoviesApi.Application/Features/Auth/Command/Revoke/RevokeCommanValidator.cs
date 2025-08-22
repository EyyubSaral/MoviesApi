using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApi.Application.Features.Auth.Command.Revoke
{
    public class RevokeCommanValidator: AbstractValidator<RevokeCommanRequest>
    {
        public RevokeCommanValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress()
                .NotEmpty();
        }
    }
}
