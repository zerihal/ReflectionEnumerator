using ReflectionEnumerator.EventArguments;
using ReflectionEnumerator.Objects;
using System.Data;

namespace ReflectionEnumerator.Interfaces
{
    public interface IInterrogatedAssembly
    {
        event EventHandler<ReflectionCompleteEventArgs> ReflectionComplete;
        string Name { get; }
        Version Version { get; }
        IList<IAssemblyObject> AssemblyObjects { get; }
        Task GetAssemblyObjectElementsAsync();
        string Serialize(SerializationType format);
    }
}
