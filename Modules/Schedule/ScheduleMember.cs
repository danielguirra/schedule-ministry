using ApiEscala.Database;
using ApiEscala.Modules.Member;

namespace ApiEscala.Modules.Schedule
{
    public class ScheduleMember : BaseModel
    {
        public Guid ScheduleId { get; set; }
        public ScheduleModel Schedule { get; set; } = null!;
        public int MemberId { get; set; }
        public MemberModel Member { get; set; } = null!;
        public required string Function { get; set; }
        public bool Confirmed { get; set; } = false;
        public string? Observation { get; set; }
    }
}
