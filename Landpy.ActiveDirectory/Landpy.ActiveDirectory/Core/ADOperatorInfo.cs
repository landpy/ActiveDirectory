namespace Landpy.ActiveDirectory.Core
{
    /// <summary>
    /// ActiveDirectory operator info.
    /// </summary>
    public struct ADOperatorInfo
    {
        /// <summary>
        /// The ActiveDirectory user login name.
        /// </summary>
        public string UserLoginName { get; set; }
        /// <summary>
        /// The ActiveDirectory user password.
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// The domain name which will be operated.
        /// </summary>
        public string OperateDomainName { get; set; }
    }
}
