using ReflectionEnumerator.Interfaces;

namespace ReflectionEnumerator.Settings
{
    /// <inheritdoc/>
    public class ReflectorSettings : IReflectorSettings
    {
        /// <inheritdoc/>
        public ReflectorModifiers Modifiers { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ReflectorSettings() { }

        /// <summary>
        /// Constructor with reflector modifiers specified.
        /// </summary>
        /// <param name="modifiers">Reflection modifiers.</param>
        public ReflectorSettings(ReflectorModifiers modifiers)
        {
            Modifiers = modifiers;
        }
    }
}
