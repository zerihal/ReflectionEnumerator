using ReflectionEnumerator.Interfaces;
using System.Reflection;

namespace ReflectionEnumerator.Objects
{
    /// <inheritdoc/>
    public class ReflectedEvent : ReflectedElement, IReflectedEvent
    {
        /// <inheritdoc/>
        public override ReflectedElementType ElementType => ReflectedElementType.Event;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="eventInfo">Event info.</param>
        public ReflectedEvent(EventInfo eventInfo) : base(eventInfo) { }
    }
}
