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

        public ReflectedProperty(PropertyInfo propertyInfo) : base(propertyInfo)
        {
            PopulatePropertyInfo(propertyInfo);
        }

        private void PopulatePropertyInfo(PropertyInfo propertyInfo)
        {
            if (propertyInfo.GetMethod is MethodInfo getter)
            {
                PropertyType = InterrogatorHelper.GetTypeName(getter.ReturnType);
                NonPublic = !getter.IsPublic;
            }
            else
            {
                Debug.WriteLine("Warning: Property does not have a get method");
                PropertyType = InterrogatorHelper.GetTypeName(propertyInfo.PropertyType);
            }

            if (propertyInfo.SetMethod is MethodInfo setter)
            {
                HasSetter = true;
                PublicSetter = setter.IsPublic;
            }
        }
    }
}
