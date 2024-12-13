using ReflectionEnumerator.Interfaces;
using ReflectionEnumerator.Settings;

namespace ReflectionEnumerator.Objects
{
    /// <inheritdoc/>
    public class AssemblyObject : IAssemblyObject
    {
        /// <inheritdoc/>
        private Type _assemblyObjectType;

        /// <inheritdoc/>
        public string Name { get; }

        /// <inheritdoc/>
        public AssemblyObjectType ObjectType { get; }

        /// <inheritdoc/>
        public string AccessModifer { get; }

        /// <inheritdoc/>
        public IList<IReflectedProperty> Properties { get; }

        /// <inheritdoc/>
        public IList<IReflectedMethod> Methods { get; }

        /// <inheritdoc/>
        public IList<IReflectedField> Fields { get; }

        /// <inheritdoc/>
        public IList<IReflectedEvent> Events { get; }

        /// <inheritdoc/>
        public IList<IReflectedConstructor> Constructors { get; }

        /// <inheritdoc/>
        public bool IsReflected { get; private set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="type">Assembly object type (e.g. class, interface, etc).</param>
        public AssemblyObject(Type type)
        {
            _assemblyObjectType = type;
            Properties = new List<IReflectedProperty>();
            Methods = new List<IReflectedMethod>();
            Fields = new List<IReflectedField>();
            Events = new List<IReflectedEvent>();
            Constructors = new List<IReflectedConstructor>();

            Name = type.Name;
            ObjectType = InterrogatorHelper.GetAssemblyObjectType(_assemblyObjectType, out var modifier);
            AccessModifer = modifier; 
        }

        /// <inheritdoc/>
        public async Task PopulateReflectedElements(ReflectorModifiers modifiers)
        {
            var flags = modifiers == ReflectorModifiers.Public ? InterrogatorHelper.PublicFlags : 
                modifiers == ReflectorModifiers.Private ? InterrogatorHelper.NonPublicFlags : InterrogatorHelper.AllFlags;

            foreach (var property in _assemblyObjectType.GetProperties(flags))
                Properties.Add(new ReflectedProperty(property));

            foreach (var method in _assemblyObjectType.GetMethods(flags))
            {
                if (method.IsSpecialName)
                    continue;

                Methods.Add(new ReflectedMethod(method));
            }

            foreach (var field in _assemblyObjectType.GetFields(flags))
            {
                if (field.IsSpecialName || field.Name.Contains(">k__BackingField"))
                    continue;

                Fields.Add(new ReflectedField(field));
            }

            foreach (var rEvent in _assemblyObjectType.GetEvents(flags))
                Events.Add(new ReflectedEvent(rEvent));

            if (ObjectType == AssemblyObjectType.Class)
            {
                foreach (var ctr in _assemblyObjectType.GetConstructors(flags))
                    Constructors.Add(new ReflectedConstructor(ctr));

                // ToDo - If there are no declared constructors then we can assume it is a default ctr
            }

            IsReflected = true;
            await Task.CompletedTask;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>Name of the current object.</returns>
        public override string ToString() => Name;
    }
}
