namespace ReflectionEnumerator.Interfaces
{ 
    /// <summary>
    /// Reflected field.
    /// </summary>
    public interface IReflectedField : IReflectedElement
    {
        /// <summary>
        /// Field type as string.
        /// </summary>
        string FieldType { get; }

        /// <summary>
        /// Default value of the field (if present and can be determined), otherwise null.
        /// </summary>
        object? DefaultValue { get; }
    }
}
