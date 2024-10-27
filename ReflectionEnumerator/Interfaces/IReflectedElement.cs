using ReflectionEnumerator.Objects;

namespace ReflectionEnumerator.Interfaces
{
    public interface IReflectedElement
    {
        ReflectedElementType ElementType { get; }
        string Name { get; }
        Type? ReturnType { get; }
        bool NonPublic { get; }
    }
}
