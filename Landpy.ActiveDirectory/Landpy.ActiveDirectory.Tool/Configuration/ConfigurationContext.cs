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
            OperatorConfiguration operatorConfiguration = new OperatorConfiguration();
            operationSecurity = new OperatorSecurity(operatorConfiguration.Path,
                operatorConfiguration.UserName,
                operatorConfiguration.Password);
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
