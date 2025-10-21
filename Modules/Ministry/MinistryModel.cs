using System.ComponentModel.DataAnnotations;
using ApiEscala.Database;
using ApiEscala.Modules.Schedule;
using ApiEscala.Utils;

namespace ApiEscala.Modules.Ministry
{
    public class MinistryModel : BaseModel
    {
        [Unique]
        [MaxLength(255)]
        public required string Name { get; set; }

        [MaxLength(255)]
        public string? Description { get; set; }
        public required List<Guid> CoordinatorsId { get; set; } = [];
        public ICollection<ScheduleModel> Schedules { get; set; } = [];
    }
}
