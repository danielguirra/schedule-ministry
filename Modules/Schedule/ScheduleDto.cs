using System.ComponentModel.DataAnnotations;

namespace ApiEscala.Modules.Schedule;

public class SaveScheduleDto
{
    [Required]
    public required DateTime Date { get; set; }

    [MinLength(4)]
    [MaxLength(30)]
    [Required]
    public required string EventName { get; set; }

    [Required]
    public Guid MinistryId { get; set; }

    [MaxLength(255)]
    public string? Notes { get; set; }

    public ScheduleModel ToModel(Guid authorId) =>
        new()
        {
            Date = Date,
            EventName = EventName,
            MinistryID = MinistryId,
            AuthorID = authorId,
            Notes = Notes,
        };
}

public class SaveScheduleMemberDto
{
    [Required]
    public required Guid ScheduleId { get; set; }

    [Required]
    [MinLength(1)]
    public required List<Guid> MembersId { get; set; }

    [Required]
    [MaxLength(30)]
    public required string Function { get; set; }

    [MaxLength(255)]
    public string? Observation { get; set; }

    public ScheduleMember ToModel(Guid memberId) =>
        new()
        {
            ScheduleId = ScheduleId,
            MemberId = memberId,
            Function = Function,
            Observation = Observation,
        };
}

public class EditScheduleDto
{
    [Required]
    public required Guid ScheduleId { get; set; }

    public DateTime? Date { get; set; }

    [MinLength(4)]
    [MaxLength(30)]
    public string? EventName { get; set; }

    public ScheduleModel ApplyTo(ScheduleModel model)
    {
        if (Date != null)
            model.Date = (DateTime)Date;

        if (EventName != null)
            model.EventName = EventName;

        model.UpdatedAt = DateTime.UtcNow;
        return model;
    }
}

public class EditScheduleMemberDto
{
    [Required]
    public required Guid ScheduleId { get; set; }

    [Required]
    public Guid MemberId { get; set; }

    [MaxLength(30)]
    public required string? Function { get; set; }

    [MaxLength(255)]
    public string? Observation { get; set; }

    public bool? Confirmed { get; set; }

    public ScheduleMember ApplyTo(ScheduleMember model)
    {
        if (Confirmed is bool v)
            model.Confirmed = v;

        if (Function != null)
            model.Function = Function;

        if (Observation != null)
            model.Observation = Observation;

        model.UpdatedAt = DateTime.UtcNow;
        return model;
    }
}
