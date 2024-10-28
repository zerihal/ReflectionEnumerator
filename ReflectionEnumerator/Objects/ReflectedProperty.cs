using ReflectionEnumerator.Interfaces;
using System.Reflection;

namespace ReflectionEnumerator.Objects
{
    public class ReflectedProperty : ReflectedElement, IReflectedProperty
    {
        public override ReflectedElementType ElementType => ReflectedElementType.Property;

        public bool HasSetter { get; private set; }

        public bool PublicSetter { get; private set; }

        public ReflectedProperty(PropertyInfo propertyInfo) : base(propertyInfo)
        {
            PopulatePropertyInfo(propertyInfo);
        }

        private void PopulatePropertyInfo(PropertyInfo propertyInfo)
        {
            if (propertyInfo.GetMethod is MethodInfo getter)
            {
                ReturnType = getter.ReturnType;
                NonPublic = !getter.IsPublic;
            }
            else
            {
                ReturnType = propertyInfo.PropertyType;
            }

            if (propertyInfo.SetMethod is MethodInfo setter)
            {
                HasSetter = true;
                PublicSetter = setter.IsPublic;
            }
        }
    }
}
