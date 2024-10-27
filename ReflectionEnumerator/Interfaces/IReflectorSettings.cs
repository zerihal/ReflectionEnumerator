namespace ReflectionEnumerator.Interfaces
{
    public interface IReflectorSettings
    {
        bool IncludePublic { get; set; }
        bool IncludeNonPublic { get; set; }
        bool IncludeAll { get; set; }       
    }
}
