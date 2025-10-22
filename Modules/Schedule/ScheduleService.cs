using ApiEscala.Database;
using Microsoft.EntityFrameworkCore;

namespace ApiEscala.Modules.Schedule;

public class ScheduleService(AppDbContext context) : BaseService(context)
{
    public async Task CreateSchedule(SaveScheduleDto dto, Guid authorId)
    {
        context.Schedules.Add(dto.ToModel(authorId));
        await SaveAsync();
    }

    public async Task CreateScheduleMember(SaveScheduleMemberDto dto)
    {
        context.ScheduleMember.AddRange(dto.MembersId.Select(dto.ToModel).ToList());
        await SaveAsync();
    }

    public async Task<List<ScheduleModel>> GetScheduleOnDate(DateTime date)
    {
        return await context
            .Schedules.Include(s => s.Members)
            .Where(s => s.Date == date && s.Active)
            .ToListAsync();
    }

    public async Task RemoveScheduleMember(Guid scheduleId, Guid memberId)
    {
        ScheduleMember? scheduleMember = await context
            .ScheduleMember.Where(s => s.ScheduleId == scheduleId && s.MemberId == memberId)
            .FirstOrDefaultAsync();

        if (scheduleMember is null)
            return;

        context.ScheduleMember.Remove(scheduleMember);
        await SaveAsync();
    }

    public async Task InactiveSchedule(Guid scheduleId)
    {
        ScheduleModel? scheduleModel = await context
            .Schedules.Where(s => s.Id == scheduleId)
            .FirstOrDefaultAsync();

        if (scheduleModel is null)
            return;

        scheduleModel.Active = false;
        context.Schedules.Update(scheduleModel);
        await SaveAsync();
    }

    public async Task RemoveSchedule(Guid scheduleId)
    {
        ScheduleModel? scheduleModel = await context
            .Schedules.Where(s => s.Id == scheduleId)
            .FirstOrDefaultAsync();

        if (scheduleModel is null)
            return;

        context.Schedules.Remove(scheduleModel);
        await SaveAsync();
    }

    public async Task EditSchedule(EditScheduleDto dto)
    {
        ScheduleModel? scheduleModel = await context
            .Schedules.Where(s => s.Id == dto.ScheduleId)
            .FirstOrDefaultAsync();

        if (scheduleModel is null)
            return;

        context.Schedules.Update(dto.ApplyTo(scheduleModel));
        await SaveAsync();
    }

    public async Task EditScheduleMember(EditScheduleMemberDto dto)
    {
        ScheduleMember? scheduleMember = await context
            .ScheduleMember.Where(s => s.Id == dto.ScheduleId)
            .FirstOrDefaultAsync();

        if (scheduleMember is null)
            return;

        context.ScheduleMember.Update(dto.ApplyTo(scheduleMember));
        await SaveAsync();
    }
}
