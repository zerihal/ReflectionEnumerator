using ReflectionEnumerator.EventArguments;
using ReflectionEnumerator.Objects;
using ReflectionEnumerator.Objects.Records;

namespace ReflectionEnumerator.Interfaces
{
    /// <summary>
    /// Iterrogated assembly object.
    /// </summary>
    public partial interface IInterrogatedAssembly
    {
        /// <summary>
        /// Event for reflection completion following call to get assembly object elements.
        /// </summary>
        event EventHandler<ReflectionCompleteEventArgs> ReflectionComplete;

        /// <summary>
        /// Assembly name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Assembly version.
        /// </summary>
        Version Version { get; }

        /// <summary>
        /// Contained assembly objects.
        /// </summary>
        IList<IAssemblyObject> AssemblyObjects { get; }

        /// <summary>
        /// Gets assembly load error (if no error then this will be indicated in the record).
        /// </summary>
        /// <returns>Assembly load error record.</returns>
        AssemblyLoadError LoadError();

        /// <summary>
        /// Performs reflection on all contained assembly objects (synchronous).
        /// </summary>
        void GetAssemblyObjectElements();

        /// <summary>
        /// Performs async reflection on all contained assembly objects (reflection completion event is fired once finished).
        /// </summary>
        Task GetAssemblyObjectElementsAsync();

        /// <summary>
        /// Serializes this interrogated assembly to format such as JSON.
        /// </summary>
        /// <param name="format">Serialization format.</param>
        /// <remarks>Note: Implemented format is currently restricted to just JSON.</remarks>
        /// <returns>Serialized interrogated assembly as string.</returns>
        string Serialize(SerializationType format);
    }
}
