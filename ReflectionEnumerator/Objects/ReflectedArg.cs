using ReflectionEnumerator.Interfaces;
using System.Reflection;

namespace ReflectionEnumerator.Objects
{
    public class ReflectedArg : IReflectedArg
    {
        public string ArgName { get; }

        public Type ArgType { get; }

        public object? DefaultValue { get; }

        public bool IsOptional { get; }

        public bool IsNullable { get; }

        public ReflectedArg(ParameterInfo arg)
        {
            ArgName = arg.Name ?? string.Empty;
            ArgType = arg.ParameterType;
            DefaultValue = arg.DefaultValue;
            IsOptional = arg.IsOptional;
            IsNullable = Nullable.GetUnderlyingType(arg.ParameterType) != null;           
        }
    }
}
