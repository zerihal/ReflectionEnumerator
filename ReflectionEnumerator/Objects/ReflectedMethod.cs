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

        public ReflectedMethod(MethodInfo methodInfo) : base(methodInfo)
        {
            ReflectedArgs = new List<IReflectedArg>();
            PopulateMethodInfo(methodInfo);
        }

        private void PopulateMethodInfo(MethodInfo methodInfo)
        {
            ReturnType = InterrogatorHelper.GetTypeName(methodInfo.ReturnType);
            NonPublic = !methodInfo.IsPublic;

            foreach (var arg in methodInfo.GetParameters())
                ReflectedArgs.Add(new ReflectedArg(arg));
        }
    }
}
