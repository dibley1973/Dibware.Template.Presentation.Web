using Dibware.EF.Extensions.Base;
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
using Dibware.EF.Extensions;
using Dibware.System.Extensions;
using Dibware.EF.Extensions.Contracts;

namespace Dibware.Template.Infrastructure.SqlDataAccess.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        #region Construct

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleRepository"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public UserRepository(IUnitOfWork unitOfWork)
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



            throw new NotImplementedException();
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
            Guard.InvalidOperation((UnitOfWork == null), ExceptionMessages.UnitOfWorkIsNull);
            //var result = UnitOfWork.CreateSet<User>()
            //    .FirstOrDefault(u => u.UserName.ToLower() == username.ToLower() && u.Password.ToLower() == password.ToLower());
            //var users = UnitOfWork.CreateSet<User>();
            //var result = users.FirstOrDefault(u => u.UserName.ToLower() == username.ToLower());
            //return result != null;

            var procedure = new ValidateUser(username, password);
            var iReturnValue = UnitOfWork.ExecuteStoredProcedure<String>(procedure).SingleOrDefault();
            return iReturnValue.HasValue();
        }

        #endregion

        #region StoredProcedures

        public class Membership_ValidateUser_StoredProcedure : BaseStoredProcedure<String>, IStoredProcedure<Boolean>
        {
            public const String ProcedureName = "Validate";
            public const String ProcedureSchema = @"security";

            public Membership_ValidateUser_StoredProcedure(String username, String password)
                : base(ProcedureSchema, ProcedureName, new Dictionary<String, Object>()
                    {
                        { "username", username },
                        { "password", password }
                    })
            {}
        }

        #endregion

        // Ref:
        //  http://www.lucbos.net/2012/03/calling-stored-procedure-with-entity.html
        //  https://github.com/LucBos/GenericExtensionsEFCF
    }
}