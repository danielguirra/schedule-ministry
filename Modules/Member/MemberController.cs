namespace ApiEscala.Modules.Member;

using ApiEscala.Modules.Auth;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/member")]
public class MemberController(MemberService service) : ControllerBase
{
    [HttpGet(":id")]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await service.Member(id));
    }

    [HttpPost]
    public async Task<IActionResult> Save([FromBody] SaveMemberDto dto)
    {
        await service.Create(dto);
        return Created();
    }

    [HttpPut]
    public async Task<IActionResult> Edit([FromBody] EditMemberDto dto)
    {
        await service.Edit(dto);
        return Created();
    }

    [HttpDelete(":id")]
    public async Task<IActionResult> Inactive(Guid id)
    {
        await service.Inactive(id);
        return Created();
    }

    [HttpDelete("delete/:id")]
    [AuthRequired(["admin"])]
    public async Task<IActionResult> Delete(Guid id)
    {
        await service.Remove(id);
        return Created();
    }
}
