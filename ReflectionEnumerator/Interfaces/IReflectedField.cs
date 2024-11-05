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
    }
}
