using Dibware.Template.Core.Domain.Contracts.Repositories;
using Dibware.Template.Core.Domain.Contracts.UnitOfWork;
using Dibware.Template.Core.Domain.Entities.Security;
using Dibware.Template.Infrastructure.SqlDataAccess.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dibware.Template.Infrastructure.SqlDataAccess.Repositories
{
    public class PasswordStrengthRuleRepository : Repository<PasswordStrengthRule>, IPasswordStrengthRuleRepository
    {
        #region Construct

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleRepository"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public PasswordStrengthRuleRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork) { }

        #endregion

        #region IPasswordStrengthRuleRepository Members

        public IEnumerable<String> GetAllRuleRegularExpressions()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}