using ReflectionEnumerator.Interfaces;
using System.Reflection;

namespace ReflectionEnumerator.Objects
{
    /// <inheritdoc/>
    public class ReflectedMethod : ReflectedElement, IReflectedMethod
    {
        /// <inheritdoc/>
        public override ReflectedElementType ElementType => ReflectedElementType.Method;

        /// <inheritdoc/>
        public IList<IReflectedArg> ReflectedArgs { get; }

        /// <inheritdoc/>
        public string ReturnType { get; private set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="methodInfo">Method info.</param>
        public ReflectedMethod(MethodInfo methodInfo) : base(methodInfo)
        {
            ReflectedArgs = new List<IReflectedArg>();
            PopulateMethodInfo(methodInfo);
        }

        private void PopulateMethodInfo(MethodInfo methodInfo)
        {
            ReturnType = GetType(methodInfo);
            NonPublic = !methodInfo.IsPublic;

            foreach (var arg in methodInfo.GetParameters())
                ReflectedArgs.Add(new ReflectedArg(arg));
        }
    }
}
