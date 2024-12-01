using ReflectionEnumerator.Objects;

namespace ReflectionEnumerator.Interfaces
{
    /// <summary>
    /// Reflected constructor.
    /// </summary>
    public interface IReflectedConstructor : IReflectedElement
    {
        /// <summary>
        /// Constructor arguments.
        /// </summary>
        IList<IReflectedArg> ReflectedArgs { get; }

        /// <summary>
        /// Constructor object type as string.
        /// </summary>
        string ObjectType { get; }

        /// <summary>
        /// Creates an instance of the object associated with this constructor.
        /// </summary>
        /// <param name="parameters">Constructor parameters.</param>
        /// <param name="creationError">Outputs any applicable error with instance creation.</param>
        /// <returns>Instance of the constructor object.</returns>
        object? CreateInstance(object[]? parameters, out InstanceError creationError);
    }
}
