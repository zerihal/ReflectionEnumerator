using System.Reflection;

namespace ReflectionEnumerator.Exceptions
{
    /// <summary>
    /// Unknown member type exception.
    /// </summary>
    public class UnknownMemberException : Exception
    {
        private const string ExceptionMessage = "Member type unrecognised or unspecified";

        /// <summary>
        /// Member info for the member that called this exception.
        /// </summary>
        public MemberInfo MemberInfo { get; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="memberInfo">Member info.</param>
        public UnknownMemberException(MemberInfo memberInfo) : base(ExceptionMessage)
        {
            MemberInfo = memberInfo;
        }
    }
}
