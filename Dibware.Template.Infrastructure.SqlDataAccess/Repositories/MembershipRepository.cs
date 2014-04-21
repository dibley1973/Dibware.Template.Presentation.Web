using Dibware.Helpers.Validation;
using Dibware.Template.Core.Domain.Contracts.Repositories;
using Dibware.Template.Core.Domain.Contracts.UnitOfWork;
using Dibware.Template.Core.Domain.Entities.Security;
using Dibware.Template.Core.Domain.Exceptions;
using Dibware.Template.Infrastructure.SqlDataAccess.Base;
using Dibware.Template.Infrastructure.SqlDataAccess.Resources;
using Dibware.Template.Infrastructure.SqlDataAccess.StoredProcedures.Membership;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dibware.Template.Infrastructure.SqlDataAccess.Repositories
{
    public class MembershipRepository : Repository<User>, IMembershipRepository
    {
        #region Construct

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleRepository"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public MembershipRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork) { }

        #endregion

        #region IUserRepository Members

        #endregion

        #region Repository<User> Members

        #endregion

        #region IRepositoryMembershipProviderRepository Members

        public String CreateUserAndAccount(String username, String password,
            Boolean requireConfirmation, IDictionary<String, Object> values)
        {
            // Ensure we have a UnitOfWork
            Guard.InvalidOperation((UnitOfWork == null), ExceptionMessages.UnitOfWorkIsNull);

            // Get the user's name if set
            String name =
                (values.ContainsKey(DictionaryKeys.Name)) ?
                (String)values[DictionaryKeys.Name] :
                username;

            // Get the emailAddress token if set
            String emailAddress =
                (values.ContainsKey(DictionaryKeys.EmailAddress)) ?
                (String)values[DictionaryKeys.EmailAddress] :
                String.Empty;

            // Get the confirmation token if set
            String confirmationToken =
                (values.ContainsKey(DictionaryKeys.ConfirmationToken) && requireConfirmation) ?
                (String)values[DictionaryKeys.ConfirmationToken] :
                String.Empty;

            // Apply any validation
            if(String.IsNullOrEmpty(emailAddress))
            {
                throw new ValidationException(ExceptionMessages.EmailAddressMustBeSupplied);
            }

            // Create the stored precedure we will use
            var procedure = new CreateUserMembershipAndAccountStoredProcedure(
                username,
                name,
                password,
                emailAddress,
                confirmationToken
            );
            var results = UnitOfWork.ExecuteStoredProcedure<String>(procedure);
            var userGuid = results.SingleOrDefault();
            return confirmationToken;
        }

        /// <summary>
        /// Gets the hashed password for the specified username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public String GetHashedPasswordForUser(string username)
        {
            // Ensure we have a UnitOfWork
            Guard.InvalidOperation((UnitOfWork == null), ExceptionMessages.UnitOfWorkIsNull);

            var procedure = new GetPasswordStoredProcedure(username);
            var results = UnitOfWork.ExecuteStoredProcedure<String>(procedure);
            var returnValue = results.SingleOrDefault();
            return returnValue;
        }

        ///// <summary>
        ///// Validates the user.
        ///// </summary>
        ///// <param name="username">The username.</param>
        ///// <param name="password">The password.</param>
        ///// <returns></returns>
        ///// <exception cref="System.NotImplementedException"></exception>
        //bool IRepositoryMembershipProviderRepository.ValidateUser(String username, String password)
        //{
        //    throw new NotImplementedException();

        //    // Ensure we have a UnitOfWork
        //    //Guard.InvalidOperation((UnitOfWork == null), ExceptionMessages.UnitOfWorkIsNull);

        //    //var procedure = new ValidateUserStoredProcedure(username, password);
        //    //var returnValue = UnitOfWork.ExecuteStoredProcedure<Boolean>(procedure).SingleOrDefault();
        //    //return returnValue.HasValue();
        //}

        #endregion

        // Ref:
        //  http://www.lucbos.net/2012/03/calling-stored-procedure-with-entity.html
        //  https://github.com/LucBos/GenericExtensionsEFCF



    }
}