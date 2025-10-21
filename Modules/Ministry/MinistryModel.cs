using ApiEscala.Database;
using ApiEscala.Modules.Member;
using ApiEscala.Modules.Schedule;
using ApiEscala.Utils;

namespace ApiEscala.Modules.Ministry
{
    public class MinistryModel : BaseModel
    {
        [Unique]
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required Guid CoordinatorId { get; set; }

        public MemberModel? Coordinator { get; set; }
        public ICollection<ScheduleModel> Schedules { get; set; } = [];
    }
}
