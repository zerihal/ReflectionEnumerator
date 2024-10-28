using ReflectionEnumerator.Objects;

namespace ReflectionEnumerator.Interfaces
{
    public interface IAssemblyObject
    {
        string Name { get; }
        AssemblyObjectType ObjectType { get; }
        string AccessModifer { get; }
        IEnumerable<IReflectedProperty> Properties { get; }
        IEnumerable<IReflectedMethod> Methods { get; }
        
    }
}
