
namespace Dibware.Template.Core.Domain.Enumerations
{
    /// <summary>
    /// Defines the available account types
    /// </summary>
    public enum AccountType : int
    {
        /// <summary>
        /// The account for rivate individuals
        /// </summary>
        PrivateIndividual,
        /// <summary>
        /// The account for an organisation
        /// </summary>
        Organisation,
        /// <summary>
        /// The account for a business
        /// </summary>
        Business,
        /// <summary>
        /// The account for an admin
        /// </summary>
        Admin,
        /// <summary>
        /// The account for a system admin
        /// </summary>
        SystemAdmin
    }
}