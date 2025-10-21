using ApiEscala.Database;
using Microsoft.EntityFrameworkCore;

namespace ApiEscala.Modules.Member;

public class MemberService(AppDbContext context) : BaseService(context)
{
    public async Task Create(SaveMemberDto dto)
    {
        context.Members.Add(dto.ToModel());
        await SaveAsync();
    }

    public async Task<MemberModel?> Member(Guid id) =>
        await context.Members.Where(m => m.Id == id && m.Active).FirstAsync();

    public async Task Edit(EditMemberDto dto)
    {
        MemberModel member = await Member(dto.Id) ?? throw new MemberNotFoundException(dto.Id);
        dto.ApplyTo(member);
        await SaveAsync();
    }

    public async Task Inactive(Guid id)
    {
        MemberModel member = await Member(id) ?? throw new MemberNotFoundException(id);
        member.Active = false;
        member.UpdatedAt = DateTime.UtcNow;
        context.Update(member);
        await SaveAsync();
    }

    public async Task Remove(Guid id)
    {
        MemberModel member = await Member(id) ?? throw new MemberNotFoundException(id);
        context.Remove(member);
        await SaveAsync();
    }
}
