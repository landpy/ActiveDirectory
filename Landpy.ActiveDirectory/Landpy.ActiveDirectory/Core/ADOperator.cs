namespace Landpy.ActiveDirectory.Core
{
    /// <summary>
    /// The ActiveDirectory operator.
    /// </summary>
    public class ADOperator : IADOperator
    {
        private string UserLoginName { get; set; }
        private string Password { get; set; }
        private string OperateDomainName { get; set; }

        /// <summary>
        /// The constructor with user login name, user password and name of domain which will be operated params.
        /// </summary>
        /// <param name="userLoginName">The user login name.</param>
        /// <param name="password">The user password.</param>
        /// <param name="operateDomainName">The name of domain which will be operated.</param>
        public ADOperator(string userLoginName, string password, string operateDomainName)
        {
            this.UserLoginName = userLoginName;
            this.Password = password;
            this.OperateDomainName = operateDomainName;
        }

        /// <summary>
        /// Get the ActiveDirectory operator info.
        /// </summary>
        /// <returns></returns>
        public ADOperatorInfo GetOperatorInfo()
        {
            return new ADOperatorInfo { UserLoginName = this.UserLoginName, OperateDomainName = this.OperateDomainName, Password = this.Password };
        }
    }
}
