namespace ReflectionEnumerator.Objects.Records
{
    /// <summary>
    /// Simple record to indicate an assembly load error, including the exception.
    /// </summary>
    /// <param name="HasLoadError">True if there was an assembly load error, otherwise false.</param>
    /// <param name="ErrorMessage">Exception message for assembly load error (if any).</param>
    public record AssemblyLoadError(bool HasLoadError, string ErrorMessage);
}
