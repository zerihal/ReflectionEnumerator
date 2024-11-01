using ReflectionEnumerator.Interfaces;
using System.Reflection;

namespace ReflectionEnumerator.Objects
{
    public class ReflectedArg : IReflectedArg
    {
        public string ArgName { get; }

        public string ArgType { get; }

        public object? DefaultValue { get; }

        public bool IsOptional { get; }

        public bool IsNullable { get; }

        public ReflectedArg(ParameterInfo arg)
        {
            ArgName = arg.Name ?? string.Empty;
            ArgType = InterrogatorHelper.GetTypeName(arg.ParameterType);
            DefaultValue = arg.HasDefaultValue ? arg.DefaultValue : null;
            IsOptional = arg.IsOptional;
            IsNullable = Nullable.GetUnderlyingType(arg.ParameterType) != null;           
        }
    }
}
