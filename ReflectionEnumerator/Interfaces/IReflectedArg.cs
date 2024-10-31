namespace ReflectionEnumerator.Interfaces
{
    public interface IReflectedArg
    {
        string ArgName { get; }
        string ArgType { get; }
        object? DefaultValue { get; }
        bool IsOptional { get; }
        bool IsNullable { get; }
    }
}
