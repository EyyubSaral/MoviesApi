using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MoviesApi.Application.Bases;
using MoviesApi.Application.Features.Auth.Rules;
using MoviesApi.Application.Interfaces.AutoMapper;
using MoviesApi.Application.Interfaces.UnitOfWorks;
using MoviesApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApi.Application.Features.Auth.Command.Revoke
{
    public class RevokeCommanHandler : BaseHandler, IRequestHandler<RevokeCommanRequest,Unit>
    {
        private readonly UserManager<User> userManager;
        private readonly AuthRules authRules;

        public RevokeCommanHandler(UserManager<User> userManager,AuthRules authRules,IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.userManager = userManager;
            this.authRules = authRules;
        }

        public async Task<Unit> Handle(RevokeCommanRequest request, CancellationToken cancellationToken)
        {
            User user=await userManager.FindByEmailAsync(request.Email);
            await authRules.EmaiAddressShouldBeValid(user);

            user.RefreshToken = null;
            await userManager.UpdateAsync(user);

            return Unit.Value;
        }
    }
}
