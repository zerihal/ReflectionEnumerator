using System.Reflection;
using ReflectionEnumerator.Interfaces;

namespace ReflectionEnumerator.Objects
{
    public class ReflectedConstructor : ReflectedElement, IReflectedConstructor
    {
        private ConstructorInfo _constructorInfo;
        private bool _hasDeclaringType;

        public override ReflectedElementType ElementType => ReflectedElementType.Constructor;

        public IList<IReflectedArg> ReflectedArgs { get; }

        public string ObjectType { get; private set; }

        public ReflectedConstructor(ConstructorInfo ctrInfo) : base()
        {
            _constructorInfo = ctrInfo;

            if (_constructorInfo.DeclaringType is Type t)
            {
                Name = t.Name;
                _hasDeclaringType = true;
            }
            else
            {
                Name = _constructorInfo.Name;
            }

            ReflectedArgs = new List<IReflectedArg>();
            PopulateConstructorInfo();
        }

        private void PopulateConstructorInfo()
        {
            if (_constructorInfo.ReflectedType is Type type)
                ObjectType = InterrogatorHelper.GetTypeName(type);
            else
                ObjectType = _hasDeclaringType ? Name : InterrogatorHelper.GetTypeName(_constructorInfo.GetType()); 

            NonPublic = !_constructorInfo.IsPublic;

            foreach (var arg in _constructorInfo.GetParameters())
                ReflectedArgs.Add(new ReflectedArg(arg));
        }

        public object? CreateInstance(object[]? parameters, out InstanceError creationError)
        {
            object? rtnObj = null;

            try
            {
                if (_constructorInfo != null)
                    rtnObj = _constructorInfo.Invoke(parameters);

                creationError = new(false, string.Empty);
            }
            catch (Exception e)
            {
                creationError = new(true, e.Message);
            }

            return rtnObj;
        }
    }
}
