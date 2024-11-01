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

        internal static string GetTypeName(Type type) => GetTypeName(type, out _);

        internal static string GetTypeName(Type type, out bool isGenericType)
        {
            var typeName = type.Name;

            if (type.IsGenericType)
            {
                isGenericType = true;

                try
                {
                    var fieldName = type.Name.Split('`')[0];
                    var fieldArgs = type.GetGenericArguments().Select(a => a.Name);
                    var argsConcat = string.Empty;

                    if (fieldArgs.Any())
                    {
                        argsConcat = string.Join(", ", fieldArgs);
                        argsConcat = $"<{argsConcat}>";
                    }

                    typeName = $"{fieldName}{argsConcat}";
                }
                catch
                {
                    // Unable to parse generic type - default type name will be used.
                }
            }
            else
            {
                isGenericType = false;
            }

            // Remove system type chars
            typeName = typeName.Replace("&", "");

            return typeName;
        }
    }
}
