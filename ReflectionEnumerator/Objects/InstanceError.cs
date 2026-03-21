namespace ReflectionEnumerator.Objects
{
    /// <summary>
    /// Object instance creation error record.
    /// </summary>
    /// <param name="CreationError">Has creation error</param>
    /// <param name="Exception">Exception message (if any).</param>
    public record InstanceError(bool CreationError, string Exception);
}
