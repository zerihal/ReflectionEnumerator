using ReflectionEnumerator.Interfaces;
using System.Reflection;

namespace ReflectionEnumerator.Objects
{
    public abstract class ReflectedElement : IReflectedElement
    {
        public abstract ReflectedElementType ElementType { get; }

        public string Name { get; protected set; }

        public Type? ReturnType { get; protected set; }

        public bool NonPublic { get; protected set; }

        public ReflectedElement(MemberInfo member)
        {
            Name = member.Name;
        }
    }
}
