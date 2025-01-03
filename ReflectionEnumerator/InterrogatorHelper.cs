﻿using ReflectionEnumerator.Exceptions;
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

        /// <summary>
        /// Gets the assembly object type, including access modifier.
        /// </summary>
        /// <param name="type">Object type.</param>
        /// <param name="modifier">Access modifier.</param>
        /// <returns>Assembly object type.</returns>
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

        /// <summary>
        /// Gets the type name for the member
        /// </summary>
        /// <param name="memberInfo"></param>
        /// <param name="typeLoadException"></param>
        /// <returns></returns>
        internal static string GetTypeName(MemberInfo memberInfo, out bool typeLoadException)
        {
            typeLoadException = false;

            try
            {
                switch (memberInfo)
                {
                    case FieldInfo fieldInfo:
                        return GetTypeName(fieldInfo.FieldType);

                    case PropertyInfo propertyInfo:
                        return propertyInfo.GetMethod is MethodInfo getter ? GetTypeName(getter.ReturnType) : GetTypeName(propertyInfo.PropertyType);

                    case MethodInfo methodInfo:
                        return GetTypeName(methodInfo.ReturnType);

                    case ConstructorInfo constructorInfo:
                        return GetTypeName(constructorInfo.ReflectedType ?? constructorInfo.DeclaringType ?? typeof(object));

                    default:
                        // Member type is not specifed as one recognised by this helper method so throw exception.
                        throw new UnknownMemberException(memberInfo);
                }
            }
            catch
            {
                typeLoadException = true;
                return GetTypeName(typeof(object));
            }          
        }

        /// <summary>
        /// Gets type name as a string.
        /// </summary>
        /// <param name="type">System type.</param>
        /// <returns>Type name as string.</returns>
        internal static string GetTypeName(Type type) => GetTypeName(type, out _);

        /// <summary>
        /// Gets type name as a string and whether this is a generic type.
        /// </summary>
        /// <param name="type">System type.</param>
        /// <param name="isGenericType">True if generic type, otherwise false.</param>
        /// <returns>Type name as string.</returns>
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
