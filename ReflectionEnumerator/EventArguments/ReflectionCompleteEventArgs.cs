namespace ReflectionEnumerator.EventArguments
{
    /// <summary>
    /// Reflection completed event arguments.
    /// </summary>
    public class ReflectionCompleteEventArgs : EventArgs
    {
        /// <summary>
        /// Count of reflected assembly objects.
        /// </summary>
        public int ReflectedAssemblyObjects { get; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="reflectedAssemblyObjects">Number of reflected assembly objects found.</param>
        public ReflectionCompleteEventArgs(int reflectedAssemblyObjects)
        {
            ReflectedAssemblyObjects = reflectedAssemblyObjects;
        }
    }
}
