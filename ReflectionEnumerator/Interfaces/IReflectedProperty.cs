namespace ReflectionEnumerator.Interfaces
{
    /// <summary>
    /// Reflected property.
    /// </summary>
    public interface IReflectedProperty : IReflectedElement
    {
        /// <summary>
        /// Indicates whether the property has a setter.
        /// </summary>
        bool HasSetter { get; }

        /// <summary>
        /// Indicates whether the property setter (if present) is public.
        /// </summary>
        bool PublicSetter { get; }

        /// <summary>
        /// Property type as string.
        /// </summary>
        string PropertyType { get; }
    }
}
