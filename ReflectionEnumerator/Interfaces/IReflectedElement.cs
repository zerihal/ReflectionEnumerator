using ReflectionEnumerator.Objects;

namespace ReflectionEnumerator.Interfaces
{
    public interface IReflectedElement
    {
        ReflectedElementType ElementType { get; }
        string Name { get; }
        bool NonPublic { get; }
    }
}
