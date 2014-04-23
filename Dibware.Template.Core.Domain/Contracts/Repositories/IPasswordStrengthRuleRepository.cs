using Dibware.Template.Core.Domain.Contracts.Repositories.Base;
using Dibware.Template.Core.Domain.Entities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dibware.Template.Core.Domain.Contracts.Repositories
{
    public interface IPasswordStrengthRuleRepository : IRepository<PasswordStrengthRule>
    {
    }
}