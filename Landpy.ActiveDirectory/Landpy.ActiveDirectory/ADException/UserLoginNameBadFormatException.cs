using System;

namespace Landpy.ActiveDirectory.ADException
{
    class UserLoginNameBadFormatException : Exception
    {
        public UserLoginNameBadFormatException()
            : base("The user login name is bad format!")
        {
        }
    }
}
