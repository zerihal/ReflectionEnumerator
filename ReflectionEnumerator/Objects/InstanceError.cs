namespace ReflectionEnumerator.Objects
{
    /// <summary>
    /// Object instance creation error record.
    /// </summary>
    /// <param name="creationError">Has creation error</param>
    /// <param name="exception">Exception message (if any).</param>
    public record InstanceError(bool creationError, string exception);
}
