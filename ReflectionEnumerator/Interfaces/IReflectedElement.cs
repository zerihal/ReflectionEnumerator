using ReflectionEnumerator.Objects;

namespace ReflectionEnumerator.Interfaces
{
    /// <summary>
    /// Reflected element.
    /// </summary>
    public interface IReflectedElement
    {
        /// <summary>
        /// Element type, such as a property or method.
        /// </summary>
        ReflectedElementType ElementType { get; }

        /// <summary>
        /// Element name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Indicates whether the element is non-public.
        /// </summary>
        bool NonPublic { get; }
    }
}
