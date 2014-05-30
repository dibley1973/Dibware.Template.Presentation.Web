using Dibware.Template.Core.Domain.Entities.Base;
using System;

namespace Dibware.Template.Core.Domain.Entities.Application
{
    /// <summary>
    /// Represents a notifcation in the system
    /// </summary>
    public class Notification : BaseIdEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public String Description { get; set; }

        /// <summary>
        /// Gets or sets the date this instance is efective FROM.
        /// </summary>
        /// <value>
        /// The effective FROM date.
        /// </value>
        public DateTime EffectiveFrom { get; set; }

        /// <summary>
        /// Gets or sets the date this instance is efective TO.
        /// </summary>
        /// <value>
        /// The effective TO date.
        /// </value>
        public DateTime EffectiveTo { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Notification"/> class.
        /// </summary>
        public Notification() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Notification" /> class.
        /// </summary>
        /// <param name="effectiveFrom">The effective from date.</param>
        /// <param name="effectiveTo">The effective to date.</param>
        /// <param name="description">The description.</param>
        public Notification(
            DateTime effectiveFrom,
            DateTime effectiveTo,
            String description)
            : this(
                Constants.INITIAL_ID,
                effectiveFrom,
                effectiveTo,
                description
            ) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Notification" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="effectiveFrom">The effective from date.</param>
        /// <param name="effectiveTo">The effective to date.</param>
        /// <param name="description">The description.</param>
        public Notification(
            Int32 id,
            DateTime effectiveFrom,
            DateTime effectiveTo,
            String description)
            : this()
        {
            Id = id;
            EffectiveFrom = effectiveFrom;
            EffectiveTo = effectiveTo;
            Description = description;
        }

        #endregion
    }
}
