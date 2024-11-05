using ReflectionEnumerator.Interfaces;

namespace ReflectionEnumerator.Settings
{
    /// <inheritdoc/>
    public class ReflectorSettings : IReflectorSettings
    {
        /// <inheritdoc/>
        public ReflectorModifiers Modifiers { get; set; }

        public ReflectorSettings() { }

        public ReflectorSettings(ReflectorModifiers modifiers)
        {
            Modifiers = modifiers;
        }
    }
}
