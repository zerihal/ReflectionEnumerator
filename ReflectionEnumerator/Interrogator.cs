using ReflectionEnumerator.Interfaces;
using ReflectionEnumerator.Objects;
using ReflectionEnumerator.Settings;
using System.Reflection;

namespace ReflectionEnumerator
{
    /// <summary>
    /// Assembly interrogator.
    /// </summary>
    public class Interrogator
    {
        /// <summary>
        /// Reflector settings.
        /// </summary>
        public IReflectorSettings Settings { get; set; }

        /// <summary>
        /// Constructor with settings.
        /// </summary>
        /// <param name="settings">Reflector settings.</param>
        public Interrogator(IReflectorSettings settings)
        {
            Settings = settings;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Interrogator() 
        {
            Settings = new ReflectorSettings(ReflectorModifiers.Public);
        }

        /// <summary>
        /// Interrogates an assembly (.dll file).
        /// </summary>
        /// <param name="file">The DLL file.</param>
        /// <returns>Interrogated assembly object with basic assembly information that can be further queried.</returns>
        public IInterrogatedAssembly? InterrogateAssembly(string file)
        {
            if (Path.GetExtension(file)?.ToLower() == ".dll" && Assembly.LoadFile(file) is Assembly assembly)
            {
                return InterrogatedAssembly(assembly);
            }

            return null;
        }

        /// <summary>
        /// Interrogates an assembly (.dll file).
        /// </summary>
        /// <param name="assembly">The DLL file.</param>
        /// <returns>Interrogated assembly object with basic assembly information that can be further queried.</returns>
        public IInterrogatedAssembly? InterrogatedAssembly(Assembly assembly)
        {
            if (assembly != null)
            {
                return new InterrogatedAssembly(assembly, Settings.Modifiers);
            }

            return null;
        }
    }
}
