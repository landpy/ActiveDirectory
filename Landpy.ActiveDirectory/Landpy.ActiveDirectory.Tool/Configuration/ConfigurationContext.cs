using Landpy.ActiveDirectory;

namespace Landpy.ActiveDirectory.Tool
{
    class ConfigurationContext
    {
        private static ConfigurationContext configurationContext;
        private static object lockObject = new object();
        private static OperatorSecurity operationSecurity;

        public OperatorSecurity Security
        {
            get { return operationSecurity; }
        }

        private ConfigurationContext()
        {
            OperatorConfiguration opeatorConfiguration = new OperatorConfiguration();
            operationSecurity = new OperatorSecurity();
            operationSecurity.LdapPath = opeatorConfiguration.Path;
            operationSecurity.UserName = opeatorConfiguration.UserName;
            operationSecurity.Password = opeatorConfiguration.Password;
        }

        public static ConfigurationContext CurrentConfigurationContext()
        {
            lock (lockObject)
            {
                if (configurationContext == null)
                {
                    configurationContext = new ConfigurationContext();
                }
            }
            return configurationContext;
        }
    }
}
