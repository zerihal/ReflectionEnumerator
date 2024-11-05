using ReflectionEnumerator.Settings;

namespace ReflectionEnumerator.Interfaces
{
    /// <summary>
    /// Reflector settings.
    /// </summary>
    public interface IReflectorSettings
    {
        /// <summary>
        /// Modifiers to use for reflection (i.e. public, private/non-public, or all).
        /// </summary>
        ReflectorModifiers Modifiers { get; set; }    
    }
}
