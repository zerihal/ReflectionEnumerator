namespace ReflectionEnumerator.Objects.Records
{
    /// <summary>
    /// Simple record to indicate an assembly load error, including the exception.
    /// </summary>
    /// <param name="HasLoadError">True if there was an assembly load error, otherwise false.</param>
    /// <param name="ErrorMessage">Exception message for assembly load error (if any).</param>
    public record AssemblyLoadError(bool HasLoadError, string ErrorMessage);

    /// <summary>
    /// Record to indicate assembly reflection errors.
    /// </summary>
    /// <remarks>
    /// If the error count is less than the total objects then this indicates a partial reflection
    /// error.
    /// </remarks>
    /// <param name="errorCount">Count of assembly objects that encountered reflection exception.</param>
    /// <param name="totalObjects">Total number of assembly objects.</param>
    /// <param name="ErrorMessage">Error detail.</param>
    public record ReflectionError(int errorCount, int totalObjects, string ErrorMessage);
}
