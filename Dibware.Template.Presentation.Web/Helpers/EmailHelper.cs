using Dibware.Helpers.System;
using Dibware.Template.Presentation.Web.Resources;
using System;
using System.Configuration;
using System.Web.Helpers;

namespace Dibware.Template.Presentation.Web.Helpers
{
    /// <summary>
    /// encapsualtes functionality for sending emails
    /// </summary>
    public static class EmailHelper
    {
        /// <summary>
        /// Defines the available priorities when sending emails
        /// </summary>
        public enum EmailPriority
        {
            Low,
            Normal,
            High
        }

        /// <summary>
        /// Sends the confirmation email.
        /// </summary>
        /// <param name="userEmail">The user email.</param>
        /// <param name="username">The username.</param>
        /// <param name="confirmationToken">The confirmation token.</param>
        /// <param name="relativeUrl">The relative URL.</param>
        public static void SendConfirmationEmail(
            String userEmail,
            String username,
            String confirmationToken,
            String relativeUrl)
        {
            // Get the application name from Web.config
            var applicationName =
                ConfigurationManager.AppSettings[ConfigurationKeys.ApplicationTitle];

            // Get the application domain from Web.config
            var domain =
                ConfigurationManager.AppSettings[ConfigurationKeys.ApplicationDomain];

            // Create the return web address link
            var returnLink = LinkHelper.CreateLink(domain, relativeUrl);

            // Create the email body text
            var bodyText =
                EmailContentHelper.CreateConfirmationEmailBodyText(
                    username,
                    applicationName,
                    confirmationToken,
                    returnLink);

            // Create the email subject
            var subjectText =
                EmailContentHelper.CreateConfirmationEmailSubjectText(
                username,
                applicationName);

            // Set the email priority
            var priority = EmailHelper.EmailPriority.High;

            // Send the email
            EmailHelper.SendHtmlEmail(
                userEmail,
                subjectText,
                bodyText,
                priority);
        }

        /// <summary>
        /// Sends the contact email.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="emailAddress">The email address.</param>
        /// <param name="enquiry">The enquiry.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        internal static void SendContactEmail(
            String name,
            String emailAddress,
            String enquiry)
        {
            // Get the application name from Web.config
            var applicationName =
                ConfigurationManager.AppSettings[ConfigurationKeys.ApplicationTitle];

            // Create the email body text
            var bodyText =
                EmailContentHelper.CreateContactEmailBodyText(
                    name,
                    emailAddress,
                    applicationName,
                    enquiry);

            // Create the email subject
            var subjectText =
                EmailContentHelper.CreateContactEmailSubjectText(
                name,
                applicationName);

            // Set the email priority
            var priority = EmailHelper.EmailPriority.Normal;

            var systemContactEmailAddress =
                            ConfigurationManager.AppSettings[ConfigurationKeys.ContactEmailAddress];

            // Send the email
            EmailHelper.SendHtmlEmail(
                systemContactEmailAddress,
                emailAddress,
                subjectText,
                bodyText,
                priority);
        }

        /// <summary>
        /// Sends the password recovery email.
        /// </summary>
        /// <param name="userEmail">The user email.</param>
        /// <param name="username">The username.</param>
        /// <param name="passwordRecoveryToken">The password recovery token.</param>
        /// <param name="relativeUrl">The relative URL.</param>
        public static void SendPasswordRecoveryEmail(
            String userEmail,
            String username,
            String passwordRecoveryToken,
            String relativeUrl)
        {
            // Get the application name from Web.config
            var applicationName =
                ConfigurationManager.AppSettings[ConfigurationKeys.ApplicationTitle];

            // Get the application domain from Web.config
            var domain =
                ConfigurationManager.AppSettings[ConfigurationKeys.ApplicationDomain];

            // Create the return web address link
            var returnLink = LinkHelper.CreateLink(domain, relativeUrl);

            // Create the email body text
            var bodyText =
                EmailContentHelper.CreatePasswordRecoveryEmailBodyText(
                    username,
                    applicationName,
                    passwordRecoveryToken,
                    returnLink);

            // Create the email subject
            var subjectText =
                EmailContentHelper.CreatePasswordRecoveryEmailSubjectText(
                username,
                applicationName);

            // Set the email priority
            var priority = EmailHelper.EmailPriority.High;

            // Send the email
            EmailHelper.SendHtmlEmail(
                userEmail,
                subjectText,
                bodyText,
                priority);
        }


        /// <summary>
        /// Sends an HTML email. Wraps up WebMail.Send()
        /// </summary>
        /// <param name="toAddress">The email address to send to.</param>
        /// <param name="subjectText">The subject text.</param>
        /// <param name="bodyText">The body text.</param>
        public static void SendHtmlEmail(
            String toAddress,
            String subjectText,
            String bodyText,
            EmailPriority priority)
        {

            SendHtmlEmail(toAddress, null, subjectText, bodyText, priority);

            //try
            //{
            //    var priorityText = EnumHelper.GetName<EmailPriority>(priority);

            //    WebMail.Send(
            //        to: toAddress,
            //        body: bodyText,
            //        isBodyHtml: true,
            //        priority: priorityText,
            //        subject: subjectText
            //    );
            //}
            //catch (Exception ex)
            //{
            //    throw new ApplicationException(ExceptionMessages.ErrorSendingMail, ex);
            //}
        }

        /// <summary>
        /// Sends an HTML email. Wraps up WebMail.Send()
        /// </summary>
        /// <param name="toAddress">The email address to send to.</param>
        /// <param name="subjectText">The subject text.</param>
        /// <param name="bodyText">The body text.</param>
        public static void SendHtmlEmail(
            String toAddress,
            String fromAddress,
            String subjectText,
            String bodyText,
            EmailPriority priority)
        {
            try
            {
                var priorityText = EnumHelper.GetName<EmailPriority>(priority);

                WebMail.Send(
                    to: toAddress,
                    from: fromAddress,
                    body: bodyText,
                    isBodyHtml: true,
                    priority: priorityText,
                    subject: subjectText
                );
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ExceptionMessages.ErrorSendingMail, ex);
            }
        }
    }
}