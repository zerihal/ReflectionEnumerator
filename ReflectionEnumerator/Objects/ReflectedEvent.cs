using ReflectionEnumerator.Interfaces;
using System.Reflection;

namespace ReflectionEnumerator.Objects
{
    /// <inheritdoc/>
    public class ReflectedEvent : ReflectedElement, IReflectedEvent
    {
        /// <inheritdoc/>
        public override ReflectedElementType ElementType => ReflectedElementType.Event;

        public ReflectedEvent(EventInfo eventInfo) : base(eventInfo) { }
    }
}
