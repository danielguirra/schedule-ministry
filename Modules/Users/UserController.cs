using ApiEscala.Modules.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace ApiEscala.Modules.Users;

[ApiController]
[Route("api/user")]
[EnableRateLimiting("unauthenticatedIp")]
public class UserController(UserService service) : ControllerBase
{
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Create(UserModel newUser)
    {
        newUser.Role = "user";

        UserModel created = await service.Create(newUser);
        return Created("", new { created.Id });
    }

    [HttpPut]
    [AuthRequired]
    public async Task<IActionResult> Edit(EditUserDto user)
    {
        await service.Edit(user, User.ToAuthModel());
        return Ok(new { message = "Usuário editado." });
    }

    [HttpPost("login")]
    [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status201Created)]
    public async Task<IActionResult> Login(LoginBodyModelDto login)
    {
        string token = await service.GetTokenAsync(login);
        return StatusCode(201, new LoginResponse() { Token = token });
    }

    [HttpDelete("{id}/inactive")]
    [AuthRequired]
    public async Task<IActionResult> Inactive(Guid id)
    {
        await service.Inactivate(id);
        return Ok(new { message = "Usuário inativado." });
    }

    [HttpGet("me")]
    [AuthRequired]
    public IActionResult Me()
    {
        return Ok(User.ToAuthModel());
    }
}
