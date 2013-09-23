using System;

namespace Landpy.ActiveDirectory.Entity.Object
{
    /// <summary>
    /// The user account control type.
    /// </summary>
    [Flags]
    public enum UserAccountControlType
    {
        /// <summary>
        /// Unkonw.
        /// </summary>
        Unknow = 0,
        /// <summary>
        /// Scirpt.
        /// </summary>
        Script = 1,
        /// <summary>
        /// Account is disabled.
        /// </summary>
        AccountDisabled = 2,
        /// <summary>
        /// Home directory is required.
        /// </summary>
        HomeDirectoryRequired = 8,
        /// <summary>
        /// Account locked out.
        /// </summary>
        AccountLockedOut_DEPRECATED = 16,
        /// <summary>
        /// Password is not required.
        /// </summary>
        PasswordNotRequired = 32,
        /// <summary>
        /// Password can not be changed.
        /// </summary>
        PasswordCannotChange_DEPRECATED = 64,
        /// <summary>
        /// Password is encrypted.
        /// </summary>
        EncryptedTextPasswordAllowed = 128,
        /// <summary>
        /// Temp duplicate account.
        /// </summary>
        TempDuplicateAccount = 256,
        /// <summary>
        /// Normal account.
        /// </summary>
        NormalAccount = 512,
        /// <summary>
        /// Inter domain trust account.
        /// </summary>
        InterDomainTrustAccount = 2048,
        /// <summary>
        /// Work station trust account.
        /// </summary>
        WorkstationTrustAccount = 4096,
        /// <summary>
        /// Server trust account.
        /// </summary>
        ServerTrustAccount = 8192,
        /// <summary>
        /// Password will not expired ever.
        /// </summary>
        PasswordDoesNotExpire = 65536,
        /// <summary>
        /// Mns logon account.
        /// </summary>
        MnsLogonAccount = 131072,
        /// <summary>
        /// Need smart card.
        /// </summary>
        SmartCardRequired = 262144,
        /// <summary>
        /// Trusted for delegation.
        /// </summary>
        TrustedForDelegation = 524288,
        /// <summary>
        /// Account can not delegated.
        /// </summary>
        AccountNotDelegated = 1048576,
        /// <summary>
        /// Use Des key only.
        /// </summary>
        UseDesKeyOnly = 2097152,
        /// <summary>
        /// Do not require preauth.
        /// </summary>
        DontRequirePreauth = 4194304,
        /// <summary>
        /// Password expired.
        /// </summary>
        PasswordExpired_DEPRECATED = 8388608,
        /// <summary>
        /// Trusted to authenticate for delegation.
        /// </summary>
        TrustedToAuthenticateForDelegation = 16777216,
        /// <summary>
        /// No auth data is required.
        /// </summary>
        NoAuthDataRequired = 33554432
    }
}
