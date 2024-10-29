using ReflectionEnumerator.Interfaces;
using ReflectionEnumerator.Objects;
using ReflectionEnumerator.Settings;
using System.Reflection;

namespace ReflectionEnumerator
{
    public class Interrogator
    {
        /// <summary>
        /// 
        /// </summary>
        public IReflectorSettings Settings { get; set; }

        public Interrogator(IReflectorSettings settings)
        {
            Settings = settings;
        }

        public Interrogator() 
        {
            Settings = new ReflectorSettings(ReflectorModifiers.Public);
        }

        public IInterrogatedAssembly? InterrogateAssembly(string file)
        {
            if (Path.GetExtension(file)?.ToLower() == ".dll" && Assembly.LoadFile(file) is Assembly assembly)
            {
                return new InterrogatedAssembly(assembly, Settings.Modifiers);
            }

            return null;
        }
    }
}
