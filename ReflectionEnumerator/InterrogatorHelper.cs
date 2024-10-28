using ReflectionEnumerator.Objects;
using System.Reflection;

namespace ReflectionEnumerator
{
    internal static class InterrogatorHelper
    {
        internal static BindingFlags BaseFlags => BindingFlags.Instance | BindingFlags.DeclaredOnly;
        internal static BindingFlags PublicFlags => BindingFlags.Public | BaseFlags;
        internal static BindingFlags NonPublicFlags => BindingFlags.NonPublic | BaseFlags;
        internal static BindingFlags AllFlags => BindingFlags.Public | BindingFlags.NonPublic | BaseFlags;

        internal static AssemblyObjectType GetAssemblyObjectType(Type type, out string modifier)
        {
            if (type.IsPublic)
                modifier = "Public";
            else if (type.IsSealed)
                modifier = "Sealed";
            else
                modifier = "Non-Public";

            if (type.IsAbstract)
                modifier = $"{modifier} Abstract";

            if (type.IsInterface)
                return AssemblyObjectType.Interface;
            else if (type.IsEnum)
                return AssemblyObjectType.Enum;
            else if (type.IsClass)
                return AssemblyObjectType.Class;

            return AssemblyObjectType.Other;
        }
    }
}
