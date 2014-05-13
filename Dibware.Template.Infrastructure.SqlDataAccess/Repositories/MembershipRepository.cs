using Dibware.Helpers.Validation;
using Dibware.Template.Core.Domain.Contracts.Repositories;
using Dibware.Template.Core.Domain.Contracts.UnitOfWork;
using Dibware.Template.Core.Domain.Entities.Security;
using Dibware.Template.Core.Domain.Exceptions;
using Dibware.Template.Infrastructure.SqlDataAccess.Base;
using Dibware.Template.Infrastructure.SqlDataAccess.Helpers;
using Dibware.Template.Infrastructure.SqlDataAccess.Mappings;
using Dibware.Template.Infrastructure.SqlDataAccess.Resources;
using Dibware.Template.Infrastructure.SqlDataAccess.StoredProcedures.Membership;
using Dibware.Web.Security.Membership;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Dibware.Template.Infrastructure.SqlDataAccess.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// Ref:
    ///     https://github.com/jcwmoore/athena/blob/master/Athena.Mvc/MembershipProvider.cs
    /// </remarks>
    public class MembershipRepository : Repository<UserMembership>, IMembershipRepository
    {
        #region Construct

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleRepository"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public MembershipRepository(IUnitOfWorkInApplicationScope unitOfWork)
            : base(unitOfWork) { }

        #endregion

        #region IUserRepository Members

        #endregion

        #region Repository<User> Members

        #endregion

        #region IRepositoryMembershipProviderRepository Members


        /// <summary>
        /// Activates a pending membership account.
        /// </summary>
        /// <param name="accountConfirmationToken">A confirmation token to pass to the authentication provider.</param>
        /// <returns>
        /// true if the account is confirmed; otherwise, false.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Boolean ConfirmAccount(String accountConfirmationToken)
        {
            // Ensure we have a UnitOfWork
            Guard.InvalidOperation((UnitOfWork == null), ExceptionMessages.UnitOfWorkIsNull);
            Guard.ArgumentIsNotNullOrEmpty(accountConfirmationToken, ExceptionMessages.AccountConfirmationTokenMustBeSupplied);

            return ConfirmAccountInternal(String.Empty, accountConfirmationToken);
        }

        /// <summary>
        /// Activates a pending membership account for the specified user.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <param name="accountConfirmationToken">A confirmation token to pass to the authentication provider.</param>
        /// <returns>
        /// true if the account is confirmed; otherwise, false.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Boolean ConfirmAccount(String userName, String accountConfirmationToken)
        {
            // Ensure we have a UnitOfWork
            Guard.InvalidOperation((UnitOfWork == null), ExceptionMessages.UnitOfWorkIsNull);
            Guard.ArgumentIsNotNullOrEmpty(userName, ExceptionMessages.UsernameMustBeSupplied);
            Guard.ArgumentIsNotNullOrEmpty(accountConfirmationToken, ExceptionMessages.AccountConfirmationTokenMustBeSupplied);

            return ConfirmAccountInternal(userName, accountConfirmationToken);
        }

        /// <summary>
        /// Confirms the account internal.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="accountConfirmationToken">The account confirmation token.</param>
        /// <returns></returns>
        /// <exception cref="ValidationException"></exception>
        private Boolean ConfirmAccountInternal(String userName, String accountConfirmationToken)
        {
            // Create the stored precedure we will use
            var procedure = new ConfirmAccountStoredProcedure(
                accountConfirmationToken,
                userName
            );

            try
            {
                var confirmedState = UnitOfWork.ExecuteScalarStoredProcedure<Int32>(procedure);
                return (confirmedState == 1);
            }
            catch (SqlException sqEx)
            {
                throw SqlExceptionHelper.HandledKnownSqlExceptions(sqEx);
            }
            catch (Exception ex)
            {
                //TODO: Remove this 'catch' and rethrow once all debugging is complete
                throw ex;
            }
        }

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
            if (String.IsNullOrEmpty(emailAddress))
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

            try
            {
                var userGuid = UnitOfWork.ExecuteStoredProcedure<String>(procedure);
                return confirmationToken;
            }
            catch (SqlException sqEx)
            {
                throw SqlExceptionHelper.HandledKnownSqlExceptions(sqEx);
            }
            catch (Exception ex)
            {
                //TODO: Remove this 'catch' and rethrow once all debugging is complete
                throw ex;
            }
        }

        /// <summary>
        /// Gets the hashed password for the specified username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public String GetHashedPasswordForUser(String username)
        {
            // Ensure we have a UnitOfWork
            Guard.InvalidOperation((UnitOfWork == null), ExceptionMessages.UnitOfWorkIsNull);

            var procedure = new GetPasswordStoredProcedure(username);
            var results = UnitOfWork.ExecuteStoredProcedure<String>(procedure);
            var returnValue = results.SingleOrDefault();
            return returnValue;
        }

        /// <summary>
        /// Gets the password strength regular expression.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public String GetPasswordStrengthRegularExpression()
        {
            throw new NotImplementedException();
        }

        public DateTime GetLastPasswordFailureDate(String username)
        {
            // Ensure we have a UnitOfWork
            Guard.InvalidOperation((UnitOfWork == null), ExceptionMessages.UnitOfWorkIsNull);
            Guard.ArgumentIsNotNullOrEmpty(username, ExceptionMessages.UsernameMustBeSupplied);

            var result = GetAll().FirstOrDefault(u => u.Username == username).LastPasswordFailureDate;
            return result;
        }

        public DateTime GetPasswordChangedDate(String username)
        {
            // Ensure we have a UnitOfWork
            Guard.InvalidOperation((UnitOfWork == null), ExceptionMessages.UnitOfWorkIsNull);
            Guard.ArgumentIsNotNullOrEmpty(username, ExceptionMessages.UsernameMustBeSupplied);

            var result = GetAll().FirstOrDefault(u => u.Username == username).LastPasswordChangedDate;
            return result;
        }

        public int GetPasswordFailuresSinceLastSuccess(String username)
        {
            // Ensure we have a UnitOfWork
            Guard.InvalidOperation((UnitOfWork == null), ExceptionMessages.UnitOfWorkIsNull);
            Guard.ArgumentIsNotNullOrEmpty(username, ExceptionMessages.UsernameMustBeSupplied);

            var result = GetAll().FirstOrDefault(u => u.Username == username).PasswordFailuresSinceLastSuccess;
            return result;
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="userIsOnline">if set to <c>true</c> [user is online].</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public WebMembershipUser GetUser(String providername, String username, Boolean userIsOnline)
        {
            // Ensure we have a UnitOfWork
            Guard.InvalidOperation((UnitOfWork == null), ExceptionMessages.UnitOfWorkIsNull);
            Guard.ArgumentIsNotNullOrEmpty(providername, ExceptionMessages.ProviderNameMustBeSupplied);
            Guard.ArgumentIsNotNullOrEmpty(username, ExceptionMessages.UsernameMustBeSupplied);

            var userMembership = GetAll().FirstOrDefault(u => u.Username == username);
            WebMembershipUser result = null;
            if (userMembership != null)
            {
                result = MembershipMapping.ToWebMembershipUser(providername, userMembership);
            }
            return result;
        }

        public WebMembershipUser GetUser(String providername, object providerUserKey, Boolean userIsOnline)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a value that indicates whether the user account has been confirmed by the provider.
        /// </summary>
        /// <param name="username">The user name.</param>
        /// <returns>
        /// true if the user is confirmed; otherwise, false.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Boolean IsConfirmed(String username)
        {
            // Ensure we have a UnitOfWork
            Guard.InvalidOperation((UnitOfWork == null), ExceptionMessages.UnitOfWorkIsNull);
            Guard.ArgumentIsNotNullOrEmpty(username, ExceptionMessages.UsernameMustBeSupplied);

            // Create the stored precedure we will use
            var procedure = new IsConfirmedStoredProcedure(username);

            try
            {
                var result = UnitOfWork.ExecuteScalarStoredProcedure<Boolean>(procedure);
                return result;
            }
            catch (SqlException sqEx)
            {
                throw SqlExceptionHelper.HandledKnownSqlExceptions(sqEx);
            }
            catch (Exception ex)
            {
                //TODO: Remove this 'catch' and rethrow once all debugging is complete
                throw ex;
            }
        }

        /// <summary>
        /// Updates the state of the password failure.
        /// </summary>
        /// <param name="username">The username.</param>
        public void UpdatePasswordFailureState(String username)
        {
            // Ensure we have a UnitOfWork
            Guard.InvalidOperation((UnitOfWork == null), ExceptionMessages.UnitOfWorkIsNull);
            Guard.ArgumentIsNotNullOrEmpty(username, ExceptionMessages.UsernameMustBeSupplied);

            // Create the stored precedure we will use
            var procedure = new UpdatePasswordFailureStateStoredProcedure(username);

            try
            {
                var confirmedState = UnitOfWork.ExecuteScalarStoredProcedure<Int32>(procedure);
            }
            catch (SqlException sqEx)
            {
                throw SqlExceptionHelper.HandledKnownSqlExceptions(sqEx);
            }
            catch (Exception ex)
            {
                //TODO: Remove this 'catch' and rethrow once all debugging is complete
                throw ex;
            }
        }

        /// <summary>
        /// Updates the state of the password success.
        /// </summary>
        /// <param name="username">The username.</param>
        public void UpdatePasswordSuccessState(String username)
        {
            // Ensure we have a UnitOfWork
            Guard.InvalidOperation((UnitOfWork == null), ExceptionMessages.UnitOfWorkIsNull);
            Guard.ArgumentIsNotNullOrEmpty(username, ExceptionMessages.UsernameMustBeSupplied);

            // Create the stored precedure we will use
            var procedure = new UpdatePasswordSuccessStateStoredProcedure(username);

            try
            {
                var confirmedState = UnitOfWork.ExecuteScalarStoredProcedure<Int32>(procedure);
            }
            catch (SqlException sqEx)
            {
                throw SqlExceptionHelper.HandledKnownSqlExceptions(sqEx);
            }
            catch (Exception ex)
            {
                //TODO: Remove this 'catch' and rethrow once all debugging is complete
                throw ex;
            }
        }

        #endregion

        // Ref:
        //  http://www.lucbos.net/2012/03/calling-stored-procedure-with-entity.html
        //  https://github.com/LucBos/GenericExtensionsEFCF
    }
}