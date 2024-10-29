using ReflectionEnumerator.Interfaces;
using System.Reflection;

namespace ReflectionEnumerator.Objects
{
    public class ReflectedMethod : ReflectedElement, IReflectedMethod
    {
        public override ReflectedElementType ElementType => ReflectedElementType.Method;

        public IList<IReflectedArg> ReflectedArgs { get; }

        public string ReturnType { get; private set; }

        public ReflectedMethod(MethodInfo methodInfo) : base(methodInfo)
        {
            ReflectedArgs = new List<IReflectedArg>();
            PopulateMethodInfo(methodInfo);
        }

        private void PopulateMethodInfo(MethodInfo methodInfo)
        {
            ReturnType = methodInfo.ReturnType.Name;
            NonPublic = !methodInfo.IsPublic;

            foreach (var arg in methodInfo.GetParameters())
            {
                ReflectedArgs.Add(new ReflectedArg(arg));
            }
        }
    }
}
