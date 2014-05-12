using Dibware.Template.Core.Domain.Entities.Security;
using Dibware.Web.Security.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dibware.Template.Infrastructure.SqlDataAccess.Mappings
{
    public static class MembershipMapping
    {
        public static WebMembershipUser ToWebMembershipUser(String providerName, UserMembership record)
        {
            var  result = new WebMembershipUser(
                providerName, 
                record.Username, 
                record.Guid, 
                record.EmailAddress, 
                record.PasswordQuestion, 
                record.Comment, 
                record.IsApproved, 
                record.IsLockedOut, 
                record.CreationDate, 
                record.LastLoginDate, 
                record.LastActivityDate, 
                record.LastPasswordChangedDate, 
                record.LastLockedOutDate);
            return result;
        }
    }
}
