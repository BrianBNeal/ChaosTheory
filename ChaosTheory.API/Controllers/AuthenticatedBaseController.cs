using ChaosTheory.Library.Utilities.Auth;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ChaosTheory.API.Controllers
{
    public abstract class AuthenticatedBaseController : ControllerBase
    {
        protected bool LoggedIn => !string.IsNullOrWhiteSpace(UserToken);
        protected bool IsAdmin => User.IsInRole(UserRoles.Admin);
        protected bool IsUser => User.IsInRole(UserRoles.User);
        protected bool IsGuest => User.IsInRole(UserRoles.Guest);
        protected string? UserToken => User.FindFirstValue("jti");
    }
}
