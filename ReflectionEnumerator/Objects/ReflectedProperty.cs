using ReflectionEnumerator.Interfaces;
using System.Diagnostics;
using System.Reflection;

namespace ReflectionEnumerator.Objects
{
    /// <inheritdoc/>
    public class ReflectedProperty : ReflectedElement, IReflectedProperty
    {
        /// <inheritdoc/>
        public override ReflectedElementType ElementType => ReflectedElementType.Property;

        /// <inheritdoc/>
        public bool HasSetter { get; private set; }

        /// <inheritdoc/>
        public bool PublicSetter { get; private set; }

        /// <inheritdoc/>
        public string PropertyType { get; private set; }

        /// <inheritdoc/>
        public object? DefaultValue { get; private set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="propertyInfo">Property info.</param>
        public ReflectedProperty(PropertyInfo propertyInfo) : base(propertyInfo)
        {
            PopulatePropertyInfo(propertyInfo);
        }

        private void PopulatePropertyInfo(PropertyInfo propertyInfo)
        {
            if (propertyInfo.GetMethod is MethodInfo getter)
                NonPublic = !getter.IsPublic;
            else
                Debug.WriteLine("Warning: Property does not have a get method");

            PropertyType = GetType(propertyInfo);

            if (propertyInfo.SetMethod is MethodInfo setter)
            {
                HasSetter = true;
                PublicSetter = setter.IsPublic;
            }

            try
            {
                if (propertyInfo.CanRead && propertyInfo.DeclaringType is Type propType)
                {
                    var instance = Activator.CreateInstance(propType);
                    DefaultValue = propertyInfo.GetValue(instance);
                }
            }
            catch
            {
                // Just swallow - default value null.
            }
        }
    }
}
