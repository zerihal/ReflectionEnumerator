using ReflectionEnumerator.Interfaces;
using System.Reflection;

namespace ReflectionEnumerator.Objects
{
    public class ReflectedMethod : ReflectedElement, IReflectedMethod
    {
        public override ReflectedElementType ElementType => ReflectedElementType.Method;

        public IList<IReflectedArg> ReflectedArgs { get; }

        public ReflectedMethod(MethodInfo methodInfo)
        {
            ReflectedArgs = new List<IReflectedArg>();
            PopulateMethodProperties(methodInfo);
        }

        private void PopulateMethodProperties(MethodInfo methodInfo)
        {
            Name = methodInfo.Name;
            ReturnType = methodInfo.ReturnType;
            NonPublic = !methodInfo.IsPublic;

            foreach (var arg in methodInfo.GetParameters())
            {
                ReflectedArgs.Add(new ReflectedArg(arg));
            }
        }
    }
}
