using MediatR;

namespace MoviesApi.Application.Features.Auth.Command.Revoke
{
    public class RevokeCommanRequest: IRequest<Unit>
    {
        public string Email { get; set; }
    }
}

