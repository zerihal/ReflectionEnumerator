namespace ReflectionEnumerator.Exceptions
{
    /// <summary>
    /// Generic interrogator exception.
    /// </summary>
    public class InterrogatorException : Exception
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public InterrogatorException(string message) : base(message) { }
    }
}
