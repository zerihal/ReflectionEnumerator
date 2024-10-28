using ReflectionEnumerator.Interfaces;
using ReflectionEnumerator.Settings;

namespace ReflectionEnumerator.Objects
{
    public class AssemblyObject : IAssemblyObject
    {
        private Type _assemblyObjectType;

        public string Name { get; }

        public AssemblyObjectType ObjectType { get; }

        public string AccessModifer { get; }

        public IList<IReflectedProperty> Properties { get; }

        public IList<IReflectedMethod> Methods { get; }

        public IList<IReflectedField> Fields { get; }

        public IList<IReflectedEvent> Events { get; }

        public AssemblyObject(Type type)
        {
            _assemblyObjectType = type;
            Properties = new List<IReflectedProperty>();
            Methods = new List<IReflectedMethod>();
            Fields = new List<IReflectedField>();
            Events = new List<IReflectedEvent>();

            Name = type.Name;
            ObjectType = InterrogatorHelper.GetAssemblyObjectType(_assemblyObjectType, out var modifier);
            AccessModifer = modifier; 
        }

        public async Task PopulateReflectedElements(ReflectorModifiers modifiers)
        {
            var flags = modifiers == ReflectorModifiers.Public ? InterrogatorHelper.PublicFlags : 
                modifiers == ReflectorModifiers.Private ? InterrogatorHelper.NonPublicFlags : InterrogatorHelper.AllFlags;

            foreach (var property in _assemblyObjectType.GetProperties(flags))
                Properties.Add(new ReflectedProperty(property));

            foreach (var method in _assemblyObjectType.GetMethods(flags))
                Methods.Add(new ReflectedMethod(method));

            foreach (var field in _assemblyObjectType.GetFields(flags))
                Fields.Add(new ReflectedField(field));

            foreach (var rEvent in _assemblyObjectType.GetEvents(flags))
                Events.Add(new ReflectedEvent(rEvent));

            await Task.CompletedTask;
        }
    }
}
