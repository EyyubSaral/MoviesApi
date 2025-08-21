using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MoviesApi.Application.Bases;
using MoviesApi.Application.Features.Auth.Rules;
using MoviesApi.Application.Interfaces.AutoMapper;
using MoviesApi.Application.Interfaces.Tokens;
using MoviesApi.Application.Interfaces.UnitOfWorks;
using MoviesApi.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace MoviesApi.Application.Features.Auth.Command.RefreshToken
{
    public class RefreshTokenCommanHandler :BaseHandler, IRequestHandler<RefreshTokenCommanRequest, RefreshTokenCommanResponse>
    {
        private readonly AuthRules authRules;
        private readonly UserManager<User> userManager;
        private readonly ITokenService tokenService;
        public RefreshTokenCommanHandler(IMapper mapper,AuthRules authRules ,IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, ITokenService tokenService) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.authRules = authRules;
            this.userManager = userManager;
            this.tokenService = tokenService;
        }

        public async Task<RefreshTokenCommanResponse> Handle(RefreshTokenCommanRequest request, CancellationToken cancellationToken)
        {
            ClaimsPrincipal? principal = tokenService.GetPrincipalFromExpiredToken(request.AccessToken);
            string email = principal.FindFirstValue(ClaimTypes.Email);

            User? user = await userManager.FindByEmailAsync(email);
            IList<string> roles = await userManager.GetRolesAsync(user);

           
           await authRules.RefreshTokenShouldNotBeExpired(user.RefreshTokenExpiryTime);

            JwtSecurityToken newAccesToken = await tokenService.CreateToken(user , roles);
            string newRefreshToken = tokenService.GenerateRefreshToken();


            user.RefreshToken = newRefreshToken;
            await userManager.UpdateAsync(user);

            return new()
            {
                AccessToken=new JwtSecurityTokenHandler().WriteToken(newAccesToken),
                RefreshToken = newRefreshToken,
            };
        }
    }
}
