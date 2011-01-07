using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Principal;

namespace Landpy.ActiveDirectory.Core
{
    static class ConvertUtility
    {
        /// <summary>
        /// Convert byte array to sid string.
        /// </summary>
        /// <param name="sidBytes">The byte array of sid.</param>
        /// <returns></returns>
        public static string ConvertBytesToSidString(byte[] sidBytes)
        {
            string sid = String.Empty;
            sid = new SecurityIdentifier(sidBytes, 0).ToString();
            return sid;
        }
    }
}
