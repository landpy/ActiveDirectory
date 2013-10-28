namespace Landpy.ActiveDirectory.Core
{
    /// <summary>
    /// The ActiveDirectory operator interface.
    /// </summary>
    public interface IADOperator
    {
        /// <summary>
        /// Get the ActiveDirectory operator info.
        /// </summary>
        /// <returns>The ActiveDirectory operator info(If the UserLoginName and Password are all empty, will operate the AD with current user windows identity).</returns>
        ADOperatorInfo GetOperatorInfo();
    }
}
