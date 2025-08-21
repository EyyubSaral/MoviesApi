using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApi.Application.Features.Auth.Command.RefreshToken
{
    public class RefreshTokenCommanRequest : IRequest<RefreshTokenCommanResponse>
    {
        public string AccessToken{ get; set; }

        public string RefreshToken{ get; set; }
    }
}
