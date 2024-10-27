using ReflectionEnumerator.Interfaces;

namespace ReflectionEnumerator.Settings
{
    public class ReflectorSettings : IReflectorSettings
    {
        public bool IncludePublic { get; set; }
        public bool IncludeNonPublic { get; set; }

        public bool IncludeAll
        {
            get => IncludePublic && IncludeNonPublic;
            set => IncludePublic = IncludeNonPublic = value;
        }

        public ReflectorSettings() { }

        public ReflectorSettings(ReflectorModifiers modifiers)
        {
            IncludePublic = (modifiers & ReflectorModifiers.Public) == ReflectorModifiers.Public;
            IncludeNonPublic = (modifiers & ReflectorModifiers.Private) == ReflectorModifiers.Private;
        }
    }
}
