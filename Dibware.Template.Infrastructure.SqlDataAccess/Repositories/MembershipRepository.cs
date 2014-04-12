using Dibware.Helpers.Validation;
using Dibware.Template.Core.Domain.Contracts.Repositories;
using Dibware.Template.Core.Domain.Contracts.UnitOfWork;
using Dibware.Template.Core.Domain.Entities.Security;
using Dibware.Template.Infrastructure.SqlDataAccess.Base;
using Dibware.Template.Infrastructure.SqlDataAccess.Resources;
using Dibware.Template.Infrastructure.SqlDataAccess.StoredProcedures.Membership;
using Dibware.Web.Security.Providers.Contracts;
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

        public string CreateUserAndAccount(String userName, String password,
            Boolean requireConfirmation, IDictionary<String, Object> values)
        {
            // Ensure we have a UnitOfWork
            Guard.InvalidOperation((UnitOfWork == null), ExceptionMessages.UnitOfWorkIsNull);


            throw new NotImplementedException();
        }


        /// <summary>
        /// Gets the hashed password.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public String GetHashedPassword(string username)
        {
            // Ensure we have a UnitOfWork
            Guard.InvalidOperation((UnitOfWork == null), ExceptionMessages.UnitOfWorkIsNull);

            var procedure = new GetHashedPasswordStoredProcedure(username);
            var returnValue = UnitOfWork.ExecuteStoredProcedure<String>(procedure).SingleOrDefault();
            return returnValue;
        }

        /// <summary>
        /// Validates the user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        bool IRepositoryMembershipProviderRepository.ValidateUser(String username, String password)
        {
            throw new NotImplementedException();

            // Ensure we have a UnitOfWork
            //Guard.InvalidOperation((UnitOfWork == null), ExceptionMessages.UnitOfWorkIsNull);

            //var procedure = new ValidateUserStoredProcedure(username, password);
            //var returnValue = UnitOfWork.ExecuteStoredProcedure<Boolean>(procedure).SingleOrDefault();
            //return returnValue.HasValue();
        }

        #endregion

        // Ref:
        //  http://www.lucbos.net/2012/03/calling-stored-procedure-with-entity.html
        //  https://github.com/LucBos/GenericExtensionsEFCF



    }
}