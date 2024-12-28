using ReflectionEnumerator.Interfaces;
using System.Reflection;

namespace ReflectionEnumerator.Objects
{
    /// <summary>
    /// A reflected element, such as a property, method, field, etc.
    /// </summary>
    public abstract class ReflectedElement : IReflectedElement
    {
        /// <inheritdoc/>
        public abstract ReflectedElementType ElementType { get; }

        /// <inheritdoc/>
        public string Name { get; protected set; }

        /// <inheritdoc/>
        public bool NonPublic { get; protected set; }

        /// <inheritdoc/>
        public bool UndeterminedType { get; protected set; } = false;

        /// <summary>
        /// Constructor to populate basic member info (name).
        /// </summary>
        /// <param name="member">Member name.</param>
        public ReflectedElement(MemberInfo member)
        {
            Name = member.Name;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ReflectedElement() { }

        /// <inheritdoc/>
        public virtual string GetType(MemberInfo member)
        {
            var typeName = InterrogatorHelper.GetTypeName(member, out var typeLoadEx);
            if (typeLoadEx)
                UndeterminedType = typeLoadEx;

            return typeName;
        }
    }
}
