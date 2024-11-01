using ReflectionEnumerator.Objects;

namespace ReflectionEnumerator.Interfaces
{
    public interface IReflectedConstructor : IReflectedElement
    {
        IList<IReflectedArg> ReflectedArgs { get; }
        string ObjectType { get; }
        object? CreateInstance(object[]? parameters, out InstanceError creationError);
    }
}
