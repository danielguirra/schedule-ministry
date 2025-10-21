using System.ComponentModel.DataAnnotations;

namespace ApiEscala.Modules.Ministry;

public class SaveMinistryDto
{
    [Required]
    [MaxLength(255)]
    public required string Name { get; set; }

    [MaxLength(255)]
    public string? Description { get; set; }

    [Required]
    public required List<Guid> CoordinatorId { get; set; }

    public MinistryModel ToModel() =>
        new()
        {
            Name = Name,
            Description = Description,
            CoordinatorsId = CoordinatorId,
        };
}

public class EditMinistryDto
{
    [Required]
    public required Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    public List<Guid>? CoordinatorsId { get; set; }

    public MinistryModel ApplyTo(MinistryModel model)
    {
        if (Name != null)
            model.Name = Name;

        if (Description != null)
            model.Description = Description;
        if (CoordinatorsId != null)
        {
            if (CoordinatorsId.Count > 0)
            {
                model.CoordinatorsId = (List<Guid>)model.CoordinatorsId.Concat(CoordinatorsId);
            }
        }
        model.UpdatedAt = DateTime.UtcNow;
        return model;
    }
}
