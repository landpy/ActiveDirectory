using System.Configuration;

namespace Landpy.ActiveDirectory.Tool
{
    class OperatorConfiguration
    {
        private string path;
        private string userName;
        private string password;

        public string Path
        {
            get { return this.path; }
        }

        public string UserName
        {
            get { return this.userName; }
        }

        public string Password
        {
            get { return this.password; }
        }

        public OperatorConfiguration()
        {
            this.path = ConfigurationManager.AppSettings["Path"];
            this.userName = ConfigurationManager.AppSettings["UserName"];
            this.password = ConfigurationManager.AppSettings["Password"];
        }
    }
}
