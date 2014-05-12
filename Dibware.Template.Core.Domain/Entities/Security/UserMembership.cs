using Dibware.Template.Core.Domain.Entities.Base;
using System;

namespace Dibware.Template.Core.Domain.Entities.Security
{
    /// <summary>
    /// Represents a membership record in the system
    /// </summary>
    public class UserMembership : BaseGuidEntity
    {
        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        /// <value>
        /// The user name.
        /// </value>
        public String Username { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public String Password { get; set; }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>
        /// The email address.
        /// </value>
        public String EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the membership is approved.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the membership is approved; otherwise, <c>false</c>.
        /// </value>
        public Boolean IsApproved { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the membership is confirmed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the membership is confirmed; otherwise, <c>false</c>.
        /// </value>
        public Boolean IsConfirmed { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the membership is online.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the membership is online; otherwise, <c>false</c>.
        /// </value>
        public Boolean IsOnline { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the membership is locked out.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the membership is locked out; otherwise, <c>false</c>.
        /// </value>
        public Boolean IsLockedOut { get; set; }

        /// <summary>
        /// Gets or sets the confirmation token.
        /// </summary>
        /// <value>
        /// The confirmation token.
        /// </value>
        public String ConfirmationToken { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>
        /// The creation date.
        /// </value>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the last activity date.
        /// </summary>
        /// <value>
        /// The last activity date.
        /// </value>
        public DateTime LastActivityDate { get; set; }

        /// <summary>
        /// Gets or sets the last login date.
        /// </summary>
        /// <value>
        /// The last login date.
        /// </value>
        public DateTime LastLoginDate { get; set; }

        /// <summary>
        /// Gets or sets the last locked out date.
        /// </summary>
        /// <value>
        /// The last locked out date.
        /// </value>
        public DateTime LastLockedOutDate { get; set; }

        /// <summary>
        /// Gets or sets the last password success date.
        /// </summary>
        /// <value>
        /// The last password success date.
        /// </value>
        public DateTime? LastPasswordSuccessDate { get; set; }

        /// <summary>
        /// Gets or sets the last password failure date.
        /// </summary>
        /// <value>
        /// The last password failure date.
        /// </value>
        public DateTime LastPasswordFailureDate { get; set; }

        /// <summary>
        /// Gets or sets the last password changed date.
        /// </summary>
        /// <value>
        /// The last password changed date.
        /// </value>
        public DateTime LastPasswordChangedDate { get; set; }

        /// <summary>
        /// Gets or sets the password verification token expiration date.
        /// </summary>
        /// <value>
        /// The password verification token expiration date.
        /// </value>
        public DateTime? PasswordVerificationTokenExpirationDate { get; set; }

        /// <summary>
        /// Gets or sets the password verification token.
        /// </summary>
        /// <value>
        /// The password verification token.
        /// </value>
        public String PasswordVerificationToken { get; set; }

        /// <summary>
        /// Gets or sets the number of password failures since last success.
        /// </summary>
        /// <value>
        /// The number of password failures since last success.
        /// </value>
        public Int32 PasswordFailuresSinceLastSuccess { get; set; }

        /// <summary>
        /// Gets or sets the password answer.
        /// </summary>
        /// <value>
        /// The password answer.
        /// </value>
        public String PasswordAnswer { get; set; }

        /// <summary>
        /// Gets or sets the password question.
        /// </summary>
        /// <value>
        /// The password question.
        /// </value>
        public String PasswordQuestion { get; set; }

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>
        /// The comment.
        /// </value>
        public String Comment { get; set; }

    }
}