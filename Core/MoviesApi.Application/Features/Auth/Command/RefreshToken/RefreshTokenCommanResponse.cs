using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApi.Application.Features.Auth.Command.RefreshToken
{
    public class RefreshTokenCommanResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
