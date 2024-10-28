using ReflectionEnumerator.Interfaces;
using ReflectionEnumerator.Objects;
using System.Reflection;

namespace ReflectionEnumerator
{
    public class Interrogator
    {
        /// <summary>
        /// 
        /// </summary>
        public IReflectorSettings? Settings { get; set; }

        // ToDos: Add methods to get interrogated assembly (IInterrogatedAssembly) as raw object and output stream (i.e. JSON / XML)
        // Move the below into InterrogatedAssembly along with new methods for getting properties, fields, and events

        private IEnumerable<IReflectedMethod> GetMethodsInternal(object sourceObj)
        {
            var methods = new List<IReflectedMethod>();
            var methodInfos = sourceObj.GetType().GetMethods(GetFlags());

            foreach (var methodInfo in methodInfos)
            {
                methods.Add(new ReflectedMethod(methodInfo));
            }

            return methods;
        }

        private BindingFlags GetFlags()
        {
            if (Settings == null || Settings.IncludePublic && !Settings.IncludeNonPublic)
                return InterrogatorHelper.PublicFlags;

            if (Settings.IncludeNonPublic && !Settings.IncludePublic)
                return InterrogatorHelper.NonPublicFlags;

            if (Settings.IncludeAll)
                return InterrogatorHelper.AllFlags;

            throw new InterrogatorException("Invalid settings");
        }
    }
}
