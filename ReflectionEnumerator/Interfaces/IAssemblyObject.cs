using ReflectionEnumerator.Objects;
using ReflectionEnumerator.Settings;

namespace ReflectionEnumerator.Interfaces
{
    public interface IAssemblyObject
    {
        string Name { get; }
        AssemblyObjectType ObjectType { get; }
        string AccessModifer { get; }
        IList<IReflectedProperty> Properties { get; }
        IList<IReflectedMethod> Methods { get; }
        IList<IReflectedField> Fields { get; }
        IList<IReflectedEvent> Events { get; }
        IList<IReflectedConstructor> Constructors { get; }
        Task PopulateReflectedElements(ReflectorModifiers modifiers);
    }
}
