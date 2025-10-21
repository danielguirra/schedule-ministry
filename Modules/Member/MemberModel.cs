using ApiEscala.Database;

namespace ApiEscala.Modules.Member
{
    public class MemberModel : BaseModel
    {
        public required string Name { get; set; }
        public string? Role { get; set; }
        public string? MinistryRole { get; set; }
        public string? Phone { get; set; }
    }
}
