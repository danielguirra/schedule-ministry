namespace ApiEscala.Modules.Ministry;

using ApiEscala.Modules.Auth;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/ministry")]
public class MinistryController(MinistryService service) : ControllerBase
{
    [HttpGet(":id")]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await service.Ministry(id));
    }

    [HttpPost]
    public async Task<IActionResult> Save([FromBody] SaveMinistryDto dto)
    {
        await service.Create(dto);
        return Created();
    }

    [HttpPut]
    public async Task<IActionResult> Edit([FromBody] EditMinistryDto dto)
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
