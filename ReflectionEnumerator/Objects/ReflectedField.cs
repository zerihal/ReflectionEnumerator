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
            if (IsGenericFieldType(fieldInfo.FieldType, out var genericType))
                FieldType = genericType;
            else
                FieldType = fieldInfo.FieldType.Name;

            NonPublic = !fieldInfo.IsPublic;
        }

        // The method below may need to be used elsewhere too - this should get the name and arguments for a
        // generic type such as a dictionary and output a formatted string for the type name
        private bool IsGenericFieldType(Type fieldType, out string genericFieldType)
        {
            genericFieldType = string.Empty;

            if (!fieldType.IsGenericType)
                return false;

            try
            {
                var fieldName = fieldType.Name.Split('`')[0];
                var fieldArgs = fieldType.GetGenericArguments().Select(a => a.Name);
                var argsConcat = string.Empty;

                if (fieldArgs.Any())
                {
                    argsConcat = string.Join(", ", fieldArgs);
                    argsConcat = $"<{argsConcat}>";
                }
                
                genericFieldType = $"{fieldName}{argsConcat}";
            }
            catch
            {
                genericFieldType = fieldType.Name;
            }

            return true;
        }
    }
}
