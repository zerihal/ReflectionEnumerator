using ReflectionEnumerator.Interfaces;

namespace ReflectionEnumerator.Settings
{
    public class ReflectorSettings : IReflectorSettings
    {
        public ReflectorModifiers Modifiers { get; set; }

        public ReflectorSettings() { }

        public ReflectorSettings(ReflectorModifiers modifiers)
        {
            Modifiers = modifiers;
        }
    }
}
