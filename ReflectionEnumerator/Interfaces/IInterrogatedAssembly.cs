namespace ReflectionEnumerator.Interfaces
{
    public interface IInterrogatedAssembly
    {
        string Name { get; }
        Version Version { get; }
        IEnumerable <IAssemblyObject> AssemblyObjects { get; }
        T GenerateDocumentation<T>();
    }
}
