namespace ApiEscala.Enum;

public static class Roles
{
    public const string Boss = "boss";
    public const string Admin = "admin";
    public const string User = "user";

    public static int GetLevel(string role) =>
        role.ToLower() switch
        {
            Boss => 3,
            Admin => 2,
            User => 1,
            _ => 0,
        };
}
