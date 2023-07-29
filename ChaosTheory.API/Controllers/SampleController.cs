using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace ChaosTheory.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class SampleController : AuthenticatedBaseController
{
    [HttpGet("AuthorizedOnly")]
    public IActionResult AuthorizedOnly()
    {
        return Ok("you must have been logged in!");
    }

    [AllowAnonymous]
    [HttpGet("Anyone")]
    public IActionResult Anyone()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"It's not required to be logged in. You {(LoggedIn ? "are" : "aren't")}.");
        sb.AppendLine($"Token: {(UserToken) ?? "none"}");
        sb.AppendLine($"You are {(IsAdmin ? "" : "not")} an admin.");
        sb.AppendLine($"You are {(IsUser ? "" : "not")} a user.");
        sb.AppendLine($"You are {(IsGuest ? "" : "not")} a guest.");

        return Ok(sb.ToString());
    }
}
