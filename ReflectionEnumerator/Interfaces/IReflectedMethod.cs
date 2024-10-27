namespace ReflectionEnumerator.Interfaces
{
    public interface IReflectedMethod : IReflectedElement
    {
        IList<IReflectedArg> ReflectedArgs { get; }
    }
}
