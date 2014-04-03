using Dibware.Template.Core.Application.Services;
using Dibware.Template.Core.Domain.Contracts.Services;
using Dibware.Template.Core.Domain.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dibware.Template.Core.Domain.Tests.Entities.Base
{
    [TestClass]
    public class BaseEntityTests
    {
        #region Tests

        // Delete and SaveChanges deletes an item
        [TestMethod]
        public void Test_CloneBaseEntity_ResultsIn_AllPropertiesClonedCorrectly()
        {
            // Arrange
            var originalEntity = new MockBaseEntity
            {
                Id = 1,
                Name = "Soup Slurper"
            };
            var cloneService = (ICloneService)new DeepCopyCloneService();

            // Act
            var clonedEntity = originalEntity.Clone<MockBaseEntity>(cloneService);

            // Assert            
            Assert.AreEqual(originalEntity.Id, clonedEntity.Id);
            Assert.AreEqual(originalEntity.Name, clonedEntity.Name);
        }

        #endregion
    }
}