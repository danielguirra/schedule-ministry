using System.ComponentModel.DataAnnotations;

namespace ApiEscala.Modules.Member;

public class MemberDto
{
    [Required]
    public required Guid Id { get; set; }

    [Required]
    [MaxLength(255)]
    public required string Name { get; set; }

    [MaxLength(40)]
    public string? Role { get; set; }

    [MaxLength(40)]
    public string? MinistryRole { get; set; }

    [MaxLength(20)]
    public string? Phone { get; set; }

    public MemberModel ToModel() =>
        new()
        {
            Name = Name,
            Role = Role,
            MinistryRole = MinistryRole,
            Phone = Phone,
        };
}

public class SaveMemberDto
{
    [Required]
    [MaxLength(255)]
    public required string Name { get; set; }

    [MaxLength(40)]
    public string? Role { get; set; }

    [MaxLength(40)]
    public string? MinistryRole { get; set; }

    [MaxLength(20)]
    public string? Phone { get; set; }

    public MemberModel ToModel() =>
        new()
        {
            Name = Name,
            Role = Role,
            MinistryRole = MinistryRole,
            Phone = Phone,
        };
}

public class EditMemberDto
{
    [Required]
    public required Guid Id { get; set; }

    [MaxLength(255)]
    public string? Name { get; set; }

    [MaxLength(40)]
    public string? Role { get; set; }

    [MaxLength(40)]
    public string? MinistryRole { get; set; }

    [MaxLength(20)]
    public string? Phone { get; set; }

    public MemberModel ApplyTo(MemberModel model)
    {
        if (Name != null)
            model.Name = Name;

        if (Role != null)
            model.Role = Role;

        if (MinistryRole != null)
            model.MinistryRole = MinistryRole;

        if (Phone != null)
            model.Phone = Phone;

        model.UpdatedAt = DateTime.UtcNow;
        return model;
    }
}
