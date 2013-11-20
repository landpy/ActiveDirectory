using System;

namespace Landpy.ActiveDirectory.ADException
{
    /// <summary>
    /// User login name does not according with [DomainName]\[UserName] format exception.
    /// </summary>
    public class UserLoginNameBadFormatException : Exception
    {
        /// <summary>
        /// Init the exception message.
        /// </summary>
        public UserLoginNameBadFormatException()
            : base("The user login name is bad format!")
        {
        }
    }
}
