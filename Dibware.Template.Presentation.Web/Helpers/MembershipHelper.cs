using Dibware.Template.Presentation.Web.Resources;
using System;
using System.Web.Security;

namespace Dibware.Template.Presentation.Web.Helpers
{
    public class MembershipHelper
    {
        /// <summary>
        /// converts MembershipCreateStatus errors codes to a string.
        /// </summary>
        /// <param name="createStatus">The create status.</param>
        /// <returns></returns>
        public static String ConvertErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return MembershipCreateStatusErrorMessages.DuplicateUserName;

                case MembershipCreateStatus.DuplicateEmail:
                    return MembershipCreateStatusErrorMessages.DuplicateEmail;

                case MembershipCreateStatus.InvalidPassword:
                    return MembershipCreateStatusErrorMessages.InvalidPassword;

                case MembershipCreateStatus.InvalidEmail:
                    return MembershipCreateStatusErrorMessages.InvalidEmail;

                case MembershipCreateStatus.InvalidAnswer:
                    return MembershipCreateStatusErrorMessages.InvalidAnswer;

                case MembershipCreateStatus.InvalidQuestion:
                    return MembershipCreateStatusErrorMessages.InvalidQuestion;

                case MembershipCreateStatus.InvalidUserName:
                    return MembershipCreateStatusErrorMessages.InvalidUserName;

                case MembershipCreateStatus.ProviderError:
                    return MembershipCreateStatusErrorMessages.ProviderError;

                case MembershipCreateStatus.UserRejected:
                    return MembershipCreateStatusErrorMessages.UserRejected;

                default:
                    return MembershipCreateStatusErrorMessages.Default;
            }
        }
    }
}