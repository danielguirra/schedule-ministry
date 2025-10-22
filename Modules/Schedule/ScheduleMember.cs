using System.ComponentModel.DataAnnotations;
using ApiEscala.Database;
using ApiEscala.Modules.Member;

namespace ApiEscala.Modules.Schedule
{
    public class ScheduleMember : BaseModel
    {
        public Guid ScheduleId { get; set; }
        public ScheduleModel Schedule { get; set; } = null!;
        public required Guid MemberId { get; set; }
        public MemberModel Member { get; set; } = null!;
        public required string Function { get; set; }
        public bool Confirmed { get; set; } = false;

        [MaxLength(255)]
        public string? Observation { get; set; }
    }
}
