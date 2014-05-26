using Dibware.Template.Core.Domain.Entities.Base;
using System;

namespace Dibware.Template.Core.Domain.Entities.Application
{
    /// <summary>
    /// Represents an error of the system
    /// </summary>
    public class TermAndCondition : BaseIdEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the evective from date.
        /// </summary>
        /// <value>
        /// The eeffective from date.
        /// </value>
        public DateTime EffectiveFrom { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public String Description { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TermAndCondition"/> class.
        /// </summary>
        public TermAndCondition() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TermAndCondition"/> class.
        /// </summary>
        /// <param name="effectiveFrom">The effective from.</param>
        /// <param name="description">The description.</param>
        public TermAndCondition(DateTime effectiveFrom, String description)
            : this(Constants.INITIAL_ID, effectiveFrom, description) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TermAndCondition"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="effectiveFrom">The effective from.</param>
        /// <param name="description">The description.</param>
        public TermAndCondition(Int32 id, DateTime effectiveFrom, String description)
            : this()
        {
            Id = id;
            EffectiveFrom = effectiveFrom;
            Description = description;
        }

        #endregion
    }
}