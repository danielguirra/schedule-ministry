using ApiEscala.Database;
using ApiEscala.Modules.Member;
using ApiEscala.Modules.Ministry;

namespace ApiEscala.Modules.Schedule;

public class ScheduleModel : BaseModel
{
    public DateTime Date { get; set; }
    public required string EventName { get; set; } = "Culto";
    public required Guid MinistryID { get; set; }
    public MinistryModel Ministry { get; set; } = null!;
    public required Guid AuthorID { get; set; }

    public MemberModel CreatedBy { get; set; } = null!;
    public string? Notes { get; set; }

    public ICollection<ScheduleMember> Members { get; set; } = [];
}
