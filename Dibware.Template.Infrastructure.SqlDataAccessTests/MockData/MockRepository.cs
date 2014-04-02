using Dibware.Template.Core.Domain.Contracts.UnitOfWork;
using Dibware.Template.Infrastructure.SqlDataAccess.Base;

namespace Dibware.Template.Infrastructure.SqlDataAccessTests.MockData
{
    public class MockRepository<TEntity> : Repository<TEntity> where TEntity : class
    {
        #region Construct

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity}"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public MockRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        #endregion
    }
}