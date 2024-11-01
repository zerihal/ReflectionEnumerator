using ReflectionEnumerator.Interfaces;
using System.Reflection;

namespace ReflectionEnumerator.Objects
{
    public class ReflectedField : ReflectedElement, IReflectedField
    {
        public override ReflectedElementType ElementType => ReflectedElementType.Field;

        public string FieldType { get; private set; }

        public ReflectedField(FieldInfo fieldInfo) : base(fieldInfo)
        {
            PopulateFieldInfo(fieldInfo);
        }

        private void PopulateFieldInfo(FieldInfo fieldInfo)
        {
            FieldType = InterrogatorHelper.GetTypeName(fieldInfo.FieldType);
            NonPublic = !fieldInfo.IsPublic;
        }
    }
}
