using ReflectionEnumerator.Interfaces;
using ReflectionEnumerator.Objects;
using System.Reflection;

namespace ReflectionEnumerator
{
    public static class Interrogator
    {
        private static BindingFlags BaseFlags = BindingFlags.Instance | BindingFlags.DeclaredOnly;
        private static BindingFlags PublicFlags = BindingFlags.Public | BaseFlags;
        private static BindingFlags NonPublicFlags = BindingFlags.NonPublic | BaseFlags;
        private static BindingFlags AllFlags = BindingFlags.Public | BindingFlags.NonPublic | BaseFlags;

        /// <summary>
        /// 
        /// </summary>
        public static IReflectorSettings Settings { get; set; }

        public static IEnumerable<IReflectedMethod> GetMethods(object sourceObj)
        {
            var methods = new List<IReflectedMethod>();
            var methodInfos = sourceObj.GetType().GetMethods(GetFlags());

            foreach (var methodInfo in methodInfos)
            {
                methods.Add(new ReflectedMethod(methodInfo));
            }

            return methods;
        }

        private static BindingFlags GetFlags()
        {
            if (Settings == null || Settings.IncludePublic && !Settings.IncludeNonPublic)
                return PublicFlags;

            if (Settings.IncludeNonPublic && !Settings.IncludePublic)
                return NonPublicFlags;

            if (Settings.IncludeAll)
                return AllFlags;

            throw new Exception("Invalid settings");
        }
    }
}
