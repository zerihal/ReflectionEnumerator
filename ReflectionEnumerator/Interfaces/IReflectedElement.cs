using ReflectionEnumerator.Objects;
using System.Reflection;

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
        /// Namespace for the element.
        /// </summary>
        string Namespace { get; }

        /// <summary>
        /// Indicates whether the element is non-public.
        /// </summary>
        bool NonPublic { get; }

        /// <summary>
        /// Indicates that the object or return type could not be determined (i.e. type load exception) and therefore 
        /// will just be generic type of object.
        /// </summary>
        bool UndeterminedType { get; }

        /// <summary>
        /// Gets the type of this member (as string), which may be return type depending on the type of member.
        /// </summary>
        /// <param name="member">Member info.</param>
        /// <returns>String representation of the member type.</returns>
        string GetType(MemberInfo member);
    }
}
