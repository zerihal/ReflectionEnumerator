using ReflectionEnumerator.Objects;
using ReflectionEnumerator.Settings;

namespace ReflectionEnumerator.Interfaces
{
    /// <summary>
    /// Assembly object, such as a class, interface, or enum.
    /// </summary>
    public interface IAssemblyObject
    {
        /// <summary>
        /// Assembly object (e.g. class) name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// .NET object type.
        /// </summary>
        AssemblyObjectType ObjectType { get; }

        /// <summary>
        /// Access modifier.
        /// </summary>
        string AccessModifer { get; }

        /// <summary>
        /// Object properties.
        /// </summary>
        IList<IReflectedProperty> Properties { get; }

        /// <summary>
        /// Object methods.
        /// </summary>
        IList<IReflectedMethod> Methods { get; }

        /// <summary>
        /// Object fields.
        /// </summary>
        IList<IReflectedField> Fields { get; }

        /// <summary>
        /// Object events.
        /// </summary>
        IList<IReflectedEvent> Events { get; }

        /// <summary>
        /// Object constructor(s).
        /// </summary>
        IList<IReflectedConstructor> Constructors { get; }

        /// <summary>
        /// Flag to indicate whether the assembly has been reflected.
        /// </summary>
        bool IsReflected { get; }

        /// <summary>
        /// Populate refected elements - async method to get all reflected properties, methods, etc.
        /// </summary>
        /// <param name="modifiers">Reflector modifiers (e.g., public, private, or all).</param>
        Task PopulateReflectedElements(ReflectorModifiers modifiers);
    }
}
