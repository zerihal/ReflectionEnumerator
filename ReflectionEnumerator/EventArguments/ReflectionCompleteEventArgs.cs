namespace ReflectionEnumerator.EventArguments
{
    public class ReflectionCompleteEventArgs : EventArgs
    {
        public int ReflectedAssemblyObjects { get; }

        public ReflectionCompleteEventArgs(int reflectedAssemblyObjects)
        {
            ReflectedAssemblyObjects = reflectedAssemblyObjects;
        }
    }
}
