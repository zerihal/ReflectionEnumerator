namespace ReflectionEnumerator.Objects
{
    /// <summary>
    /// Reflected element type, such as method, property, etc.
    /// </summary>
    public enum ReflectedElementType
    {
        /// <summary>
        /// Reflected method.
        /// </summary>
        Method,
        /// <summary>
        /// Reflected property.
        /// </summary>
        Property,
        /// <summary>
        /// Reflected field.
        /// </summary>
        Field,
        /// <summary>
        /// Reflected event.
        /// </summary>
        Event,
        /// <summary>
        /// Reflected constructor.
        /// </summary>
        Constructor
    }
}
