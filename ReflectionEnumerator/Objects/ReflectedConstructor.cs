using System.Reflection;
using ReflectionEnumerator.Interfaces;

namespace ReflectionEnumerator.Objects
{
    /// <inheritdoc/>
    public class ReflectedConstructor : ReflectedElement, IReflectedConstructor
    {
        private ConstructorInfo _constructorInfo;
        private bool _hasDeclaringType;

        /// <inheritdoc/>
        public override ReflectedElementType ElementType => ReflectedElementType.Constructor;

        /// <inheritdoc/>
        public IList<IReflectedArg> ReflectedArgs { get; }

        /// <inheritdoc/>
        public string ObjectType { get; private set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="ctrInfo">Constructor info.</param>
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

        /// <inheritdoc/>
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

        private void PopulateConstructorInfo()
        {
            if (_constructorInfo.ReflectedType == null && _hasDeclaringType)
                ObjectType = Name;
            else
                ObjectType = GetType(_constructorInfo);

            NonPublic = !_constructorInfo.IsPublic;

            foreach (var arg in _constructorInfo.GetParameters())
                ReflectedArgs.Add(new ReflectedArg(arg));
        }
    }
}
