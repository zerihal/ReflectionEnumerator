using ReflectionEnumerator.Objects;
using System.Reflection;

namespace ReflectionEnumerator
{
    internal static class InterrogatorHelper
    {
        internal static BindingFlags BaseFlags => BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
        internal static BindingFlags PublicFlags => BindingFlags.Public | BaseFlags;
        internal static BindingFlags NonPublicFlags => BindingFlags.NonPublic | BaseFlags;
        internal static BindingFlags AllFlags => BindingFlags.Public | BindingFlags.NonPublic | BaseFlags;

        internal static AssemblyObjectType GetAssemblyObjectType(Type type, out string modifier)
        {
            if (type.IsPublic)
                modifier = "Public";
            else
                modifier = "Non-Public";

            if (type.IsClass)
            {
                if (type.IsAbstract && type.IsSealed)
                {
                    modifier += " Static";
                }
                else
                {
                    if (type.IsAbstract)
                        modifier += " Abstract";
                    else if (type.IsSealed)
                        modifier += " Sealed";
                }
            }

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
