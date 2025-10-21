using ApiEscala.Database;
using Microsoft.EntityFrameworkCore;

namespace ApiEscala.Modules.Ministry;

public class MinistryService(AppDbContext context) : BaseService(context)
{
    public async Task Create(SaveMinistryDto dto)
    {
        context.Ministries.Add(dto.ToModel());
        await SaveAsync();
    }

    public async Task<MinistryModel?> Ministry(Guid id) =>
        await context.Ministries.Where(m => m.Id == id && m.Active).FirstAsync();

    public async Task Edit(EditMinistryDto dto)
    {
        MinistryModel ministry =
            await Ministry(dto.Id) ?? throw new MinistryNotFoundException(dto.Id);

        dto.ApplyTo(ministry);
        await SaveAsync();
    }

    public async Task Inactive(Guid id)
    {
        MinistryModel ministry = await Ministry(id) ?? throw new MinistryNotFoundException(id);
        ministry.Active = false;
        ministry.UpdatedAt = DateTime.UtcNow;
        context.Update(ministry);
        await SaveAsync();
    }

    public async Task Remove(Guid id)
    {
        MinistryModel ministry = await Ministry(id) ?? throw new MinistryNotFoundException(id);
        context.Remove(ministry);
        await SaveAsync();
    }
}
