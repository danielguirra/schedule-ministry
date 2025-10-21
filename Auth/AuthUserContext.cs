using System.Security.Claims;
using ApiEscala.Modules.Users;
using Microsoft.AspNetCore.Mvc;

namespace ApiEscala.Modules.Auth;

public static class HttpContextUserExtensions
{
    public static AuthModel? GetAuthenticatedUserModel(this ControllerBase controller)
    {
        return controller.User.ToAuthModel();
    }

    public static AuthModel ToAuthModel(this ClaimsPrincipal principal)
    {
        string? userIdClaim = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        string? userNameClaim = principal.FindFirst(ClaimTypes.Name)?.Value;
        string? userRoleClaim = principal.FindFirst(ClaimTypes.Role)?.Value;

        if (
            userIdClaim == null
            || !Guid.TryParse(userIdClaim, out Guid userId)
            || userNameClaim == null
            || userRoleClaim == null
        )
        {
            throw new InvalidUserTokenException();
        }

        return new AuthModel
        {
            Id = userId,
            Name = userNameClaim,
            Role = userRoleClaim,
        };
    }

    public static Guid GetUserId(this ClaimsPrincipal principal)
    {
        string? userIdClaim =
            (principal.FindFirst(ClaimTypes.NameIdentifier)?.Value)
            ?? throw new UserNotFoundException(null);

        if (Guid.TryParse(userIdClaim, out Guid id))
        {
            return id;
        }
        throw new InternalUserException();
    }
}
