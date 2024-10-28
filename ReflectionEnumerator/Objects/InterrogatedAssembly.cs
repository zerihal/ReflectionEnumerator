using ReflectionEnumerator.EventArguments;
using ReflectionEnumerator.Interfaces;
using ReflectionEnumerator.Settings;
using System.Reflection;

namespace ReflectionEnumerator.Objects
{
    public class InterrogatedAssembly : IInterrogatedAssembly
    {
        private ReflectorModifiers _modifiers;

        public event EventHandler<ReflectionCompleteEventArgs> ReflectionComplete;

        public string Name { get; }

        public Version Version { get; }

        public IList<IAssemblyObject> AssemblyObjects { get; }

        public InterrogatedAssembly(Assembly assembly, ReflectorModifiers modifiers)
        {
            _modifiers = modifiers;
            AssemblyObjects = new List<IAssemblyObject>();
            Name = assembly.FullName ?? string.Empty;
            Version = assembly.GetName().Version ?? new Version(0, 0, 0, 0);

            foreach (var aType in assembly.GetTypes())
                AssemblyObjects.Add(new AssemblyObject(aType));
        }

        public async void GetAssemblyObjectElementsAsync()
        {
            foreach (var assemblyObject in AssemblyObjects)
            {
                await assemblyObject.PopulateReflectedElements(_modifiers);
            }

            OnReflectionComplete(new ReflectionCompleteEventArgs(AssemblyObjects.Count));
        }

        public T GenerateDocumentation<T>()
        {
            throw new NotImplementedException();
        }

        private void OnReflectionComplete(ReflectionCompleteEventArgs e) => ReflectionComplete?.Invoke(this, e);
    }
}
