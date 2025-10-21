namespace ApiEscala.Utils
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class UniqueAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class MultipleAttribute : Attribute { }
}
