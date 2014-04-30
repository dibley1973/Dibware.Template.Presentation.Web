using Dibware.Extensions.System.Collections;
using Dibware.Template.Core.Domain.Contracts.Repositories;
using Dibware.Template.Core.Domain.Contracts.UnitOfWork;
using Dibware.Template.Core.Domain.Entities.Security;
using Dibware.Template.Infrastructure.SqlDataAccess.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dibware.Template.Infrastructure.SqlDataAccess.Repositories
{
    public class PasswordStrengthRuleRepository : Repository<PasswordStrengthRule>, IPasswordStrengthRuleRepository
    {
        #region Construct

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleRepository"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public PasswordStrengthRuleRepository(IUnitOfWorkInApplicationScope unitOfWork)
            : base(unitOfWork) { }

        #endregion

        #region IPasswordStrengthRuleRepository Members

        /// <summary>
        /// Gets all rules as a regular expression.
        /// </summary>
        /// <returns></returns>
        public String GetAllRulesAsRegularExpression()
        {
            var rules = GetAllRuleRegularExpressions();
            var expression = rules.AppendAll();
            return expression;
        }

        /// <summary>
        /// Gets all of the individual password rule regular expressions.
        /// </summary>
        /// <returns></returns>
        public List<String> GetAllRuleRegularExpressions()
        {
            //var rules = GetAll();
            //var rules = UnitOfWork.CreateSet<PasswordStrengthRule>();
            //var rulesRegularExpressions = rules.Select(r => r.RegularExpression);
            var rulesRegularExpressions = GetAll().Select(r => r.RegularExpression).ToList();
            //var rulesRegularExpressions = UnitOfWork.CreateSet<PasswordStrengthRule>()
            //    /*.OrderBy(expression => expression.Sequence)*/
            //    .Select(rule => rule.RegularExpression)
            //    .ToList();
            return rulesRegularExpressions;
        }

        #endregion
    }
}