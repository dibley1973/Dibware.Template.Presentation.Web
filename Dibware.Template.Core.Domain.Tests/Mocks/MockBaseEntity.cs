using Dibware.Template.Core.Domain.Entities.Base;

namespace Dibware.Template.Core.Domain.Tests.Mocks
{
    /// <summary>
    /// Used as we cannot create an instance of
    /// the abstract BaseEntity class for testing
    /// </summary>
    public class MockBaseEntity : BaseIdNameEntity { }
}