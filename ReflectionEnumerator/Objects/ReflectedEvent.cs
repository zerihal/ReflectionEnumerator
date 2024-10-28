using ReflectionEnumerator.Interfaces;
using System.Reflection;

namespace ReflectionEnumerator.Objects
{
    public class ReflectedEvent : ReflectedElement, IReflectedEvent
    {
        public override ReflectedElementType ElementType => ReflectedElementType.Event;

        public ReflectedEvent(EventInfo eventInfo) : base(eventInfo) { }
    }
}
