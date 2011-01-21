using System;
using System.Security.Principal;
using System.Text;

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

        public static string ConvertGuidToGuidBinaryString(Guid guid)
        {
            byte[] guidBytes = guid.ToByteArray();
            StringBuilder guidBinary = new StringBuilder();
            foreach (byte guidByte in guidBytes)
            {
                guidBinary.AppendFormat(@"\{0}", guidByte.ToString("x2"));
            }
            return guidBinary.ToString();
        }
    }
}
