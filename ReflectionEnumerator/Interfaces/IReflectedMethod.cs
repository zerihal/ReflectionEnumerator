namespace ReflectionEnumerator.Interfaces
{
    /// <summary>
    /// Reflected method.
    /// </summary>
    public interface IReflectedMethod : IReflectedElement
    {
        /// <summary>
        /// Method arguments.
        /// </summary>
        IList<IReflectedArg> ReflectedArgs { get; }

        /// <summary>
        /// Method return type.
        /// </summary>
        string ReturnType { get; }
    }
}
