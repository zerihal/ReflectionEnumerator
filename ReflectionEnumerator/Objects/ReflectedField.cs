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

        /// <inheritdoc/>
        public object? DefaultValue { get; private set; }

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

            try
            {
                if (fieldInfo.IsLiteral && !fieldInfo.IsInitOnly)
                {
                    DefaultValue = fieldInfo.GetRawConstantValue();
                }
                else
                {
                    if (fieldInfo.DeclaringType is Type fieldType)
                    {
                        var instance = Activator.CreateInstance(fieldType);
                        DefaultValue = fieldInfo.GetValue(instance);
                    }
                }
            }
            catch
            {
                // Just swallow - default value null.
            }
        }
    }
}
