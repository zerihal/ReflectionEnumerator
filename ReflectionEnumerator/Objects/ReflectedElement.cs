using ReflectionEnumerator.Interfaces;
using System.Reflection;

namespace ReflectionEnumerator.Objects
{
    public abstract class ReflectedElement : IReflectedElement
    {
        /// <inheritdoc/>
        public abstract ReflectedElementType ElementType { get; }

        /// <inheritdoc/>
        public string Name { get; protected set; }

        /// <inheritdoc/>
        public bool NonPublic { get; protected set; }

        public ReflectedElement(MemberInfo member)
        {
            Name = member.Name;
        }

        public ReflectedElement() { }
    }
}
