using ReflectionEnumerator.EventArguments;

namespace ReflectionEnumerator.Interfaces
{
    public interface IInterrogatedAssembly
    {
        event EventHandler<ReflectionCompleteEventArgs> ReflectionComplete;
        string Name { get; }
        Version Version { get; }
        IList<IAssemblyObject> AssemblyObjects { get; }
        T GenerateDocumentation<T>();
    }
}
