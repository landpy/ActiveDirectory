namespace Landpy.ActiveDirectory.Core
{
    class ADOperator : IADOperator
    {
        private string UserLoginName { get; set; }
        private string Password { get; set; }
        private string OperatorDomainName { get; set; }

        public ADOperator(string userLoginName, string password, string operatorDomainName)
        {
            this.UserLoginName = userLoginName;
            this.Password = password;
            this.OperatorDomainName = operatorDomainName;
        }

        public ADOperatorInfo GetOperatorInfo()
        {
            return new ADOperatorInfo { UserLoginName = this.UserLoginName, OperateDomainName = this.OperatorDomainName, Password = this.Password };
        }
    }
}
