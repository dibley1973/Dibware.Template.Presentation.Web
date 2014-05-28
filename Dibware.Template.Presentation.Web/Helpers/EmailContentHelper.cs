﻿using Dibware.Template.Presentation.Web.Resources.Emailing;
using System;

namespace Dibware.Template.Presentation.Web.Helpers
{
    /// <summary>
    /// encapsualtes functionality for creating emails
    /// </summary>
    public static class EmailContentHelper
    {
        #region Account Confirmation Email

        /// <summary>
        /// Creates the confirmation email body text.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="applicationName">Name of the application.</param>
        /// <param name="confirmationToken">The confirmation token.</param>
        /// <param name="returnLink">The return link.</param>
        /// <returns></returns>
        public static String CreateConfirmationEmailBodyText(
            String userName,
            String applicationName,
            String confirmationToken,
            String returnLink)
        {
            var body = String.Format(
                BodyTextHtml.AccountConfirmation,
                Environment.NewLine,
                userName,
                applicationName,
                confirmationToken,
                returnLink
            );
            return body;
        }

        /// <summary>
        /// Creates the confirmation email subject text.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="applicationName">Name of the application.</param>
        /// <returns></returns>
        public static String CreateConfirmationEmailSubjectText(
            String userName,
            String applicationName)
        {
            var subject = String.Format(
                SubjectText.AccountConfirmation,
                userName,
                applicationName
            );
            return subject;
        }

        #endregion

        #region Password Recovery Email

        /// <summary>
        /// Creates the password recovery email body text.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="applicationName">Name of the application.</param>
        /// <param name="passwordRecoveryToken">The password recovery token.</param>
        /// <param name="returnLink">The return link.</param>
        /// <returns></returns>
        internal static String CreatePasswordRecoveryEmailBodyText(
            String username, 
            String applicationName, 
            String passwordRecoveryToken, 
            String returnLink)
        {
            var body = String.Format(
                BodyTextHtml.PasswordRecovery,
                Environment.NewLine,
                username,
                applicationName,
                passwordRecoveryToken,
                returnLink
            );
            return body;
        }

        /// <summary>
        /// Creates the assword recovery email subject text.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="applicationName">Name of the application.</param>
        /// <returns></returns>
        internal static String CreatePasswordRecoveryEmailSubjectText(
            String userName,
            String applicationName)
        {
            var subject = String.Format(
                SubjectText.PasswordRecovery,
                userName,
                applicationName
            );
            return subject;
        }

        #endregion
    }
}