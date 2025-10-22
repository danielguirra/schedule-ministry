using ApiEscala.Modules.Auth;
using Microsoft.AspNetCore.Mvc;

namespace ApiEscala.Modules.Schedule;

[ApiController]
[Route("schedule")]
public class ScheduleController(ScheduleService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] DateTime date)
    {
        return Ok(await service.GetScheduleOnDate(date));
    }

    [HttpPost("/schedule")]
    [AuthRequired("user")]
    public async Task<IActionResult> PostSchedule([FromBody] SaveScheduleDto dto)
    {
        await service.CreateSchedule(dto, User.ToAuthModel().Id);

        return Created();
    }

    [HttpPost("/schedule-member")]
    [AuthRequired("user")]
    public async Task<IActionResult> PostScheduleMember([FromBody] SaveScheduleMemberDto dto)
    {
        await service.CreateScheduleMember(dto);
        return Created();
    }

    [HttpDelete("/schedule-member")]
    [AuthRequired("user")]
    public async Task<IActionResult> DeleteScheduleMember(
        [FromQuery] Guid scheduleId,
        [FromQuery] Guid memberId
    )
    {
        await service.RemoveScheduleMember(scheduleId, memberId);
        return Ok();
    }

    [HttpDelete("/schedule")]
    [AuthRequired("admin")]
    public async Task<IActionResult> InactiveSchedule([FromQuery] Guid scheduleId)
    {
        await service.InactiveSchedule(scheduleId);
        return Ok();
    }

    [HttpPut("/schedule")]
    [AuthRequired("admin")]
    public async Task<IActionResult> EditSchedule([FromBody] EditScheduleDto dto)
    {
        await service.EditSchedule(dto);
        return Ok();
    }

    [HttpPut("/schedule-member")]
    [AuthRequired("admin")]
    public async Task<IActionResult> EditScheduleMember([FromBody] EditScheduleMemberDto dto)
    {
        await service.EditScheduleMember(dto);
        return Ok();
    }
}
