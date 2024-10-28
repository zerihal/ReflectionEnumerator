namespace ReflectionEnumerator.Interfaces
{
    public interface IReflectedProperty : IReflectedElement
    {
        bool HasSetter { get; }
        bool PublicSetter { get; }
    }
}
