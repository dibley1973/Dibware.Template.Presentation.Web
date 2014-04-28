using Dibware.Template.Core.Domain.Contracts.Repositories.Base;
using Dibware.Template.Core.Domain.Entities.Security;
using System;
using System.Collections.Generic;

namespace Dibware.Template.Core.Domain.Contracts.Repositories
{
    public interface IPasswordStrengthRuleRepository : IRepository<PasswordStrengthRule>
    {
        /// <summary>
        /// Gets all rules as regular expression.
        /// </summary>
        /// <returns></returns>
        String GetAllRulesAsRegularExpression();

        /// <summary>
        /// Gets all of the individual password rule regular expressions.
        /// </summary>
        /// <returns></returns>
        List<String> GetAllRuleRegularExpressions();
    }
}