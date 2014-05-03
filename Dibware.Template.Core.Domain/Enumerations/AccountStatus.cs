namespace Dibware.Template.Core.Domain.Enumerations
{
    /// <summary>
    /// Defines the availabe statuses for an account
    /// </summary>
    public enum AccountStatus : int
    {
        /// <summary>
        /// The state when an account has been 
        /// created but has not yet been confirmed
        /// </summary>
        Created,
        /// <summary>
        /// The state when an account has been created and confirmed
        /// </summary>
        Confirmed,
        /// <summary>
        /// The state when an account is active. 
        /// This is the normal state of an account
        /// </summary>
        Active,
        /// <summary>
        /// The state when an account has become dormant 
        /// after a long period of inactivity
        /// </summary>
        Dormant,
        /// <summary>
        /// The state to be used when an account has to be 
        /// on hold due t non payment of a bill or likewise.
        /// </summary>
        OnHold,
        /// <summary>
        /// The state when an account has been suspended 
        /// for some reason normally by an admin
        /// </summary>
        Suspended,
        /// <summary>
        /// The state when an account has been 
        /// deactivated, normally by the user.
        /// </summary>
        Deactivated,
        /// <summary>
        /// The state when an accunt has been deleted.
        /// </summary>
        Deleted
    }
}