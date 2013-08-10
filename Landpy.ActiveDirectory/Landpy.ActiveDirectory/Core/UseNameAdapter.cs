using Landpy.ActiveDirectory.ADException;

namespace Landpy.ActiveDirectory.Core
{
    class UseNameAdapter
    {
        public string UserName { get; private set; }
        public string UserDomainName { get; private set; }

        public UseNameAdapter(string userLoginName)
        {
            string[] userSegments = userLoginName.Split('\\');
            if (userSegments.Length == 2)
            {
                this.UserDomainName = userSegments[0];
                this.UserName = userSegments[1];
            }
            else
            {
                throw new UserLoginNameBadFormatException();
            }
        }
    }
}
