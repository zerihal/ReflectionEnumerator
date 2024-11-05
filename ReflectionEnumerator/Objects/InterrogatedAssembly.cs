using ReflectionEnumerator.EventArguments;
using ReflectionEnumerator.Interfaces;
using ReflectionEnumerator.Settings;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Xml;

namespace ReflectionEnumerator.Objects
{
    /// <inheritdoc/>
    public class InterrogatedAssembly : IInterrogatedAssembly
    {
        private ReflectorModifiers _modifiers;
        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions() { WriteIndented = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping };
        private readonly XmlWriterSettings _xmlOptions = new XmlWriterSettings() { Indent = true };

        /// <inheritdoc/>
        public event EventHandler<ReflectionCompleteEventArgs> ReflectionComplete;

        /// <inheritdoc/>
        public string Name { get; }

        /// <inheritdoc/>
        public Version Version { get; }

        /// <inheritdoc/>
        public IList<IAssemblyObject> AssemblyObjects { get; }

        public InterrogatedAssembly(Assembly assembly, ReflectorModifiers modifiers)
        {
            _modifiers = modifiers;
            AssemblyObjects = new List<IAssemblyObject>();
            Name = assembly.GetName()?.Name ?? string.Empty;
            Version = assembly.GetName()?.Version ?? new Version(0, 0, 0, 0);

            foreach (var aType in assembly.GetTypes())
                AssemblyObjects.Add(new AssemblyObject(aType));
        }

        /// <inheritdoc/>
        public async Task GetAssemblyObjectElementsAsync()
        {
            foreach (var assemblyObject in AssemblyObjects)
            {
                await assemblyObject.PopulateReflectedElements(_modifiers);
            }

            OnReflectionComplete(new ReflectionCompleteEventArgs(AssemblyObjects.Count));
        }

        /// <inheritdoc/>
        public string Serialize(SerializationType format)
        {
            switch (format)
            {
                case SerializationType.JSON:
                    return JsonSerializer.Serialize(this, _jsonOptions);

                case SerializationType.XML: // Not yet implemented (may remove)
                    throw new NotImplementedException();

                default:
                    return string.Empty;
            }
        }

        private void OnReflectionComplete(ReflectionCompleteEventArgs e) => ReflectionComplete?.Invoke(this, e);
    }
}
