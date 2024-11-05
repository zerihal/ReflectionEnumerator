namespace ReflectionEnumerator.Interfaces
{
    /// <summary>
    /// Reflected argument.
    /// </summary>
    public interface IReflectedArg
    {
        /// <summary>
        /// Argument name.
        /// </summary>
        string ArgName { get; }

        /// <summary>
        /// Argument type as string.
        /// </summary>
        string ArgType { get; }

        /// <summary>
        /// Default argument value (if any).
        /// </summary>
        object? DefaultValue { get; }

        /// <summary>
        /// Indicates whether the argument is optional.
        /// </summary>
        bool IsOptional { get; }

        /// <summary>
        /// Indicates whether the argument can be null.
        /// </summary>
        bool IsNullable { get; }
    }
}
