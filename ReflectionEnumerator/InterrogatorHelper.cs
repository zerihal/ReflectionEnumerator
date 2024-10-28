using System.Reflection;

namespace ReflectionEnumerator
{
    internal static class InterrogatorHelper
    {
        internal static BindingFlags BaseFlags => BindingFlags.Instance | BindingFlags.DeclaredOnly;
        internal static BindingFlags PublicFlags => BindingFlags.Public | BaseFlags;
        internal static BindingFlags NonPublicFlags => BindingFlags.NonPublic | BaseFlags;
        internal static BindingFlags AllFlags => BindingFlags.Public | BindingFlags.NonPublic | BaseFlags;
    }
}
