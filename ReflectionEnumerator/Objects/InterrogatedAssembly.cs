using ReflectionEnumerator.EventArguments;
using ReflectionEnumerator.Interfaces;
using ReflectionEnumerator.Objects.Records;
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
        private AssemblyLoadError _loadError = new AssemblyLoadError(false, string.Empty);

        /// <inheritdoc/>
        public event EventHandler<ReflectionCompleteEventArgs> ReflectionComplete;

        /// <inheritdoc/>
        public string Name { get; }

        /// <inheritdoc/>
        public Version Version { get; }

        /// <inheritdoc/>
        public IList<IAssemblyObject> AssemblyObjects { get; }

        /// <inheritdoc/>
        public bool HasEntryPoint { get; }

        /// <inheritdoc/>
        public ReflectionError? AssemblyReflectionError { get; private set; } = null;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="assembly">The assembly (.dll file) to interrogate.</param>
        /// <param name="modifiers">Access modifiers.</param>
        public InterrogatedAssembly(Assembly assembly, ReflectorModifiers modifiers)
        {
            try
            {
                _modifiers = modifiers;
                AssemblyObjects = new List<IAssemblyObject>();
                Name = assembly.GetName()?.Name ?? string.Empty;
                Version = assembly.GetName()?.Version ?? new Version(0, 0, 0, 0);
                HasEntryPoint = assembly.EntryPoint != null;

                foreach (var aType in assembly.GetTypes())
                    AssemblyObjects.Add(new AssemblyObject(aType));
            }
            catch (Exception e)
            {
                _loadError = new AssemblyLoadError(true, e.Message);
            }
        }

        /// <inheritdoc/>
        public AssemblyLoadError LoadError() => _loadError;

        /// <inheritdoc/>
        public void GetAssemblyObjectElements() => GetAssemblyObjectElementsAsync().Wait();

        /// <inheritdoc/>
        public async Task GetAssemblyObjectElementsAsync()
        {
            AssemblyReflectionError = null;
            var errors = 0;

            foreach (var assemblyObject in AssemblyObjects)
            {
                try
                {
                    await assemblyObject.PopulateReflectedElements(_modifiers);
                }
                catch
                {
                    errors++;
                }
            }

            if (errors > 0)
            {
                var message = HasEntryPoint ? "Assembly may be invalid as a EXE or renamed DLL" : 
                    "Reflection errors encountered";
                AssemblyReflectionError = new ReflectionError(errors, AssemblyObjects.Count, message);
            }

            OnReflectionComplete(new ReflectionCompleteEventArgs(AssemblyObjects.Count - errors));
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
