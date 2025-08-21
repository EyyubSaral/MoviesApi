using MediatR;
using System.ComponentModel;

namespace MoviesApi.Application.Features.Auth.Command.Login
{
    public class LoginCommandRequest: IRequest<LoginCommandResponse>
    {

        [DefaultValue("rexsar588@gmail.com")]
        public string Email { get; set; }

        [DefaultValue("123456")]
        public string Password { get; set; } 
    }
}
