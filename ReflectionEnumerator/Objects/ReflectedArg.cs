using ReflectionEnumerator.Interfaces;
using System.Reflection;

namespace ReflectionEnumerator.Objects
{
    /// <inheritdoc/>
    public class ReflectedArg : IReflectedArg
    {
        /// <inheritdoc/>
        public string ArgName { get; }

        /// <inheritdoc/>
        public string ArgType { get; }

        /// <inheritdoc/>
        public object? DefaultValue { get; }

        /// <inheritdoc/>
        public bool IsOptional { get; }

        /// <inheritdoc/>
        public bool IsNullable { get; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="arg">Parameter info.</param>
        public ReflectedArg(ParameterInfo arg)
        {
            ArgName = arg.Name ?? string.Empty;

            try
            {
                ArgType = InterrogatorHelper.GetTypeName(arg.ParameterType);
            }
            catch
            {
                ArgType = "Object (undetermined)";
            }
            
            DefaultValue = arg.HasDefaultValue ? arg.DefaultValue : null;
            IsOptional = arg.IsOptional;
            IsNullable = Nullable.GetUnderlyingType(arg.ParameterType) != null;           
        }
    }
}
