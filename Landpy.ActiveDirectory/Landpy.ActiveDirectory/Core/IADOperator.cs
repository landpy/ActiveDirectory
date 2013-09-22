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
        /// <returns>The ActiveDirectory operator info.</returns>
        ADOperatorInfo GetOperatorInfo();
    }
}
