using ReflectionEnumerator.Interfaces;
using System.Reflection;

namespace ReflectionEnumerator.Objects
{
    /// <inheritdoc/>
    public class ReflectedField : ReflectedElement, IReflectedField
    {
        /// <inheritdoc/>
        public override ReflectedElementType ElementType => ReflectedElementType.Field;

        /// <inheritdoc/>
        public string FieldType { get; private set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="fieldInfo">Field info.</param>
        public ReflectedField(FieldInfo fieldInfo) : base(fieldInfo)
        {
            PopulateFieldInfo(fieldInfo);
        }

        private void PopulateFieldInfo(FieldInfo fieldInfo)
        {
            FieldType = GetType(fieldInfo);
            NonPublic = !fieldInfo.IsPublic;
        }
    }
}
