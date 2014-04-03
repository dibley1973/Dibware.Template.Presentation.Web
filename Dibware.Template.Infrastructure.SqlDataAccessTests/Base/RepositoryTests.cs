using Dibware.Template.Core.Domain.Entities.Security;
using Dibware.Template.Infrastructure.SqlDataAccess.UnitOfWork;
using Dibware.Template.Infrastructure.SqlDataAccessTests.Helpers;
using Dibware.Template.Infrastructure.SqlDataAccessTests.Initialisers;
using Dibware.Template.Infrastructure.SqlDataAccessTests.MockData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.Entity;
using System.Linq;

namespace Dibware.Template.Infrastructure.SqlDataAccessTests.Base
{
    [TestClass]
    public class RepositoryTests
    {
        #region Declarations

        private WebsiteDbContext _unitOfWork;

        #endregion

        #region Test Initialise

        [TestInitialize]
        public void TestInit()
        {
            // Initialise unit of work
            _unitOfWork = UnitOfWorkHelper.GetUnitOfWork();

            // Set db initialiser to create an empty database
            var initialiser = new WebsiteDbContextInitialiser();
            Database.SetInitializer(initialiser);
            initialiser.InitializeDatabase(_unitOfWork);
        }

        #endregion

        #region Tests

        // Get for GUID returns expected item when GUID exists
        [TestMethod]
        public void Test_GetForGuid_ReturnsExpectedGuidBasedItemWhenGuidExists()
        {
            // Arrange
            var expectedResult = _unitOfWork.CreateSet<User>().First();
            var repository = new MockRepository<User>(_unitOfWork);

            // Act
            var actualResult = repository.GetForGuid(expectedResult.Guid);

            // Assert
            Assert.IsNotNull(actualResult);
            Assert.AreEqual(actualResult.Guid, expectedResult.Guid);
            Assert.AreEqual(actualResult.Name, expectedResult.Name);
        }

        // Get for ID returns expected item when ID exists
        [Ignore] // need to reinstate this once a suitable entity can be used.
        [TestMethod]
        public void Test_GetForId_ReturnsExpectedIdBasedItemWhenIdExists()
        {
            //// Arrange
            //var expectedResult = _unitOfWork.CreateSet<MockIdEntity>().First();
            //var repository = new MockRepository<MockIdEntity>(_unitOfWork);

            //// Act
            //var actualResult = repository.GetForId(expectedResult.Id);

            //// Assert
            //Assert.IsNotNull(actualResult);
            //Assert.AreEqual(actualResult.Id, expectedResult.Id);
            //Assert.AreEqual(actualResult.Name, expectedResult.Name);
        }

        // Get for KEY returns expected item when KEY exists
        [TestMethod]
        public void Test_GetForKey_ReturnsExpectedKeyBasedItemWhenKeyExists()
        {
            // Arrange
            var expectedResult = _unitOfWork.CreateSet<Role>().First();
            var repository = new MockRepository<Role>(_unitOfWork);

            // Act
            var actualResult = repository.GetForKey(expectedResult.Key);

            // Assert
            Assert.IsNotNull(actualResult);
            Assert.AreEqual(actualResult.Key, expectedResult.Key);
            Assert.AreEqual(actualResult.Name, expectedResult.Name);
        }

        // Get for GUID returns null when expected GUID does not exist
        [Ignore] // need to reinstate this once a suitable entity can be used.
        [TestMethod]
        public void Test_GetForId_ReturnsNullWhenGuidDoesNotExist()
        {
            //// Arrange
            //var repository = new MockRepository<MockIdEntity>(_unitOfWork);

            //// Act
            //var actualResult = repository.GetForId(123456789); // Id will not exist..

            //// Assert
            //Assert.IsNull(actualResult);
        }

        // Get for ID returns null when expected id does not exist
        [Ignore] // need to reinstate this once a suitable entity can be used.
        [TestMethod]
        public void Test_GetForId_ReturnsNullWhenIdDoesNotExist()
        {
            //// Arrange
            //var repository = new MockRepository<MockIdEntity>(_unitOfWork);

            //// Act
            //var actualResult = repository.GetForId(123456789); // Id will not exist..

            //// Assert
            //Assert.IsNull(actualResult);
        }

        // Get for ID returns null when expected id does not exist
        [TestMethod]
        public void Test_GetForId_ReturnsNullWhenKeyDoesNotExist()
        {
            // Arrange
            const string key = "spongbob"; // Key will not exist..
            var repository = new MockRepository<Role>(_unitOfWork);

            // Act
            var actualResult = repository.GetForKey(key);

            // Assert
            Assert.IsNull(actualResult);
        }

        // Get all returns all expected items when items exist
        [Ignore] // need to reinstate this once a suitable entity can be used.
        [TestMethod]
        public void Test_GetAll_ReturnsAllExpectedIdBasedItemsWhenItemsExist()
        {
            //// Arrange
            //var expectedEntities = _unitOfWork.CreateSet<MockIdEntity>().ToList();
            //var repository = new MockRepository<MockIdEntity>(_unitOfWork);

            //// Act
            //var results = repository.GetAll();

            //// Assert
            //Assert.IsNotNull(results);
            //Assert.AreEqual(results.Count, expectedEntities.Count);

            //// Verify first exclusionCategory is equal to expected
            //Assert.AreEqual(results.First().Id, expectedEntities.First().Id);
            //Assert.AreEqual(results.First().Name, expectedEntities.First().Name);

            //// Verify last exclusionCategory is equal to expected
            //Assert.AreEqual(results.Last().Id, expectedEntities.Last().Id);
            //Assert.AreEqual(results.Last().Name, expectedEntities.Last().Name);
        }

        // Get all returns all expected key-base items when items exist
        [TestMethod]
        public void Test_GetAll_ReturnsAllExpectedKeyBasedItemsWhenItemsExist()
        {
            // Arrange
            var expectedEntities = _unitOfWork.CreateSet<Role>().ToList();
            var repository = new MockRepository<Role>(_unitOfWork);

            // Act
            var results = repository.GetAll();

            // Assert
            Assert.IsNotNull(results);
            Assert.AreEqual(results.Count, expectedEntities.Count);

            // Verify first exclusionCategory is equal to expected
            Assert.AreEqual(results.First().Key, expectedEntities.First().Key);
            Assert.AreEqual(results.First().Name, expectedEntities.First().Name);

            // Verify last exclusionCategory is equal to expected
            Assert.AreEqual(results.Last().Key, expectedEntities.Last().Key);
            Assert.AreEqual(results.Last().Name, expectedEntities.Last().Name);
        }

        // Get all returns empty list when no items exist
        [TestMethod]
        public void Test_GetAll_ReturnsEmptyListWhenNoItemsExist()
        {
            // Set db initialiser to create an empty database
            var initialiser = new WebsiteDbContextInitialiser_Empty();
            Database.SetInitializer(initialiser);
            var unitOfWork = UnitOfWorkHelper.GetUnitOfWorkEmpty();
            initialiser.InitializeDatabase(unitOfWork);

            // Arrange            
            unitOfWork.CreateSet<Role>();
            var repository = new MockRepository<Role>(unitOfWork);

            // Act
            var results = repository.GetAll();

            // Assert
            Assert.IsNotNull(results);
            Assert.AreEqual(results.Count, 0);
        }

        // Create and SaveChanges creates a new item
        [TestMethod]
        public void Test_CreateAndSaving_CreatesANewItem()
        {
            // Arrange
            const String newKey = "elephant";
            const String newName = "Terrence";
            var existingEntities = _unitOfWork.CreateSet<Role>().ToList();
            var repository = new MockRepository<Role>(_unitOfWork);

            // Create new exclusion
            var newEntity = new Role
            {
                Key = newKey,
                Name = newName
            };

            // Act
            var createdEntity = repository.Create(newEntity);
            repository.SaveChanges();

            // Assert            
            Assert.AreEqual(_unitOfWork.CreateSet<Role>().ToList().Count, existingEntities.Count + 1);
            Assert.IsTrue(createdEntity.Key == newKey);
            Assert.IsTrue(createdEntity.Name == newName);
        }

        // Create 3 items and SaveChanges creates 3 items
        [TestMethod]
        public void Test_Create3ItemsAndSaving_Creates3NewItems()
        {
            // Arrange      
            const String newKey1 = "banana";
            const String newName1 = "Banana";
            const String newKey2 = "apple";
            const String newName2 = "Apple";
            const String newKey3 = "doughnut";
            const String newName3 = "Doughnut";
            var existingEntities = _unitOfWork.CreateSet<Role>().ToList();
            var repository = new MockRepository<Role>(_unitOfWork);

            // Create 3 new exclusions
            var newEntity1 = new Role
            {
                Key = newKey1,
                Name = newName1
            };
            var newEntity2 = new Role
            {
                Key = newKey2,
                Name = newName2
            };
            var newEntity3 = new Role
            {
                Key = newKey3,
                Name = newName3
            };

            // Act
            var createdEntity1 = repository.Create(newEntity1);
            var createdEntity2 = repository.Create(newEntity2);
            var createdEntity3 = repository.Create(newEntity3);
            repository.SaveChanges();

            // Assert            
            Assert.AreEqual(_unitOfWork.CreateSet<Role>().ToList().Count, existingEntities.Count + 3);
            Assert.IsTrue(createdEntity1.Key == newKey1);
            Assert.IsTrue(createdEntity2.Key == newKey2);
            Assert.IsTrue(createdEntity3.Key == newKey3);
        }

        // Update and SaveChanges updates an item
        [TestMethod]
        public void Test_UpdateAndSaving_UpdatesAnItem()
        {
            // Arrange

            var repository = new MockRepository<Role>(_unitOfWork);
            var existingEntity = _unitOfWork.CreateSet<Role>().First();

            // Act
            existingEntity.Name = "Updated entity";
            repository.Update(existingEntity);
            repository.SaveChanges();
            var updatedEntity = repository.GetForKey(existingEntity.Key);

            // Assert            
            Assert.AreEqual(existingEntity.Name, updatedEntity.Name);
        }

        // Update 3 items and SaveChanges updates 3 items
        [TestMethod]
        public void Test_Update3ItemsAndSaving_Updates3Items()
        {
            // Arrange
            var repository = new MockRepository<Role>(_unitOfWork);
            var existingEntity1 = _unitOfWork.CreateSet<Role>().First();
            var existingEntity2 = _unitOfWork.CreateSet<Role>().ToList()[1];
            var existingEntity3 = _unitOfWork.CreateSet<Role>().ToList()[2];

            // Act
            existingEntity1.Name = "Updated entity 1";
            existingEntity2.Name = "Updated entity 2";
            existingEntity3.Name = "Updated entity 3";
            repository.Update(existingEntity1);
            repository.Update(existingEntity2);
            repository.Update(existingEntity3);
            repository.SaveChanges();
            var updatedEntity1 = repository.GetForKey(existingEntity1.Key);
            var updatedEntity2 = repository.GetForKey(existingEntity2.Key);
            var updatedEntity3 = repository.GetForKey(existingEntity3.Key);

            // Assert            
            Assert.AreEqual(existingEntity1.Name, updatedEntity1.Name);
            Assert.AreEqual(existingEntity2.Name, updatedEntity2.Name);
            Assert.AreEqual(existingEntity3.Name, updatedEntity3.Name);
        }

        // Delete and SaveChanges deletes an item
        [Ignore] // need to reinstate this once a suitable entity can be used.
        [TestMethod]
        public void Test_DeleteAndSaving_DeletesAnIdBasedItem()
        {
            //// Arrange
            //var repository = new MockRepository<MockIdEntity>(_unitOfWork);
            //var existingEntity = _unitOfWork.CreateSet<MockIdEntity>().First();

            //// Act
            //repository.Delete(existingEntity);
            //repository.SaveChanges();
            //var deletedEntity = repository.GetForId(existingEntity.Id);

            //// Assert            
            //Assert.IsNull(deletedEntity);
        }

        // Delete and SaveChanges deletes an item
        [TestMethod]
        public void Test_DeleteAndSaving_DeletesAKeyBasedItem()
        {
            // Arrange
            var repository = new MockRepository<Role>(_unitOfWork);
            var existingEntity = _unitOfWork.CreateSet<Role>().First();

            // Act
            repository.Delete(existingEntity);
            repository.SaveChanges();
            var deletedEntity = repository.GetForKey(existingEntity.Key);

            // Assert            
            Assert.IsNull(deletedEntity);
        }

        // Delete 3 items and SaveChanges deletes 3 items
        [Ignore] // need to reinstate this once a suitable entity can be used.
        [TestMethod]
        public void Test_Delete3ItemsAndSaving_Deletes3IdBasedItems()
        {
            //// Arrange
            //var repository = new MockRepository<MockIdEntity>(_unitOfWork);
            //var existingEntity1 = _unitOfWork.CreateSet<MockIdEntity>().First();
            //var existingEntity2 = _unitOfWork.CreateSet<MockIdEntity>().ToList()[1];
            //var existingEntity3 = _unitOfWork.CreateSet<MockIdEntity>().ToList()[2];

            //// Act
            //repository.Delete(existingEntity1);
            //repository.Delete(existingEntity2);
            //repository.Delete(existingEntity3);
            //repository.SaveChanges();
            //var deletedEntity1 = repository.GetForId(existingEntity1.Id);
            //var deletedEntity2 = repository.GetForId(existingEntity2.Id);
            //var deletedEntity3 = repository.GetForId(existingEntity3.Id);

            //// Assert            
            //Assert.IsNull(deletedEntity1);
            //Assert.IsNull(deletedEntity2);
            //Assert.IsNull(deletedEntity3);
        }

        // Delete 3 items and SaveChanges deletes 3 items
        [Ignore] // need to reinstate this once a suitable entity can be used.
        [TestMethod]
        public void Test_Delete3ItemsAndSaving_Deletes3KeyBasedItems()
        {
            // Arrange
            var repository = new MockRepository<Role>(_unitOfWork);
            var existingEntity1 = _unitOfWork.CreateSet<Role>().First();
            var existingEntity2 = _unitOfWork.CreateSet<Role>().ToList()[1];
            var existingEntity3 = _unitOfWork.CreateSet<Role>().ToList()[2];

            // Act
            repository.Delete(existingEntity1);
            repository.Delete(existingEntity2);
            repository.Delete(existingEntity3);
            repository.SaveChanges();
            var deletedEntity1 = repository.GetForKey(existingEntity1.Key);
            var deletedEntity2 = repository.GetForKey(existingEntity2.Key);
            var deletedEntity3 = repository.GetForKey(existingEntity3.Key);

            // Assert            
            Assert.IsNull(deletedEntity1);
            Assert.IsNull(deletedEntity2);
            Assert.IsNull(deletedEntity3);
        }

        // Create and rollback does not create a new item
        [Ignore] // need to reinstate this once a suitable entity can be used.
        [TestMethod]
        public void Test_CreateAndDiscarding_DoesNotCreateANewIdItem()
        {
            //// Arrange
            //Int32 id = -1;
            //const String name = "";
            //var existingEntities = _unitOfWork.CreateSet<MockIdEntity>().ToList();
            //var repository = new MockRepository<MockIdEntity>(_unitOfWork);

            //// Create new exclusion
            //var newEntity = new MockIdEntity
            //{
            //    Id = id,
            //    Name = name
            //};

            //// Act
            //repository.Create(newEntity);
            //repository.DiscardChanges();

            //// Assert            
            //Assert.AreEqual(_unitOfWork.CreateSet<MockIdEntity>().ToList().Count, existingEntities.Count);
            //Assert.IsTrue(newEntity.Id > 0);
        }

        // Create and rollback does not create a new item
        [TestMethod]
        public void Test_CreateAndDiscarding_DoesNotCreateANewKeyItem()
        {
            // Arrange
            const String newKey = "bananas";
            const String newName = "Bananas";
            var existingEntities = _unitOfWork.CreateSet<Role>().ToList();
            var repository = new MockRepository<Role>(_unitOfWork);

            // Create new exclusion
            var newEntity = new Role
            {
                Key = newKey,
                Name = newName
            };

            // Act
            repository.Create(newEntity);
            repository.DiscardChanges();

            // Assert            
            Assert.AreEqual(_unitOfWork.CreateSet<Role>().ToList().Count, existingEntities.Count);
            Assert.IsTrue(newEntity.Key == newKey);
        }

        // Update and rollback does not update an item
        [Ignore] // need to reinstate this once a suitable entity can be used.
        [TestMethod]
        public void Test_UpdateAndDiscarding_DoesNotUpdateAnIdbasedItem()
        {
            //// Arrange
            //var repository = new MockRepository<MockIdEntity>(_unitOfWork);
            //var existingEntity = _unitOfWork.CreateSet<MockIdEntity>().First();

            //// Act
            //existingEntity.Name = "Updated entity";
            //repository.Update(existingEntity);
            //repository.DiscardChanges();
            //var notUpdatedEntity = repository.GetForId(existingEntity.Id);

            //// Assert            
            //Assert.AreEqual(existingEntity.Id, notUpdatedEntity.Id);
            //Assert.AreEqual(existingEntity.Name, notUpdatedEntity.Name);
        }

        // Update and rollback does not update an item
        [TestMethod]
        public void Test_UpdateAndDiscarding_DoesNotUpdateAKeyBasedItem()
        {
            // Arrange
            var repository = new MockRepository<Role>(_unitOfWork);
            var existingEntity = _unitOfWork.CreateSet<Role>().First();

            // Act
            existingEntity.Name = "Updated entity";
            repository.Update(existingEntity);
            repository.DiscardChanges();
            var notUpdatedEntity = repository.GetForKey(existingEntity.Key);

            // Assert            
            Assert.AreEqual(existingEntity.Key, notUpdatedEntity.Key);
            Assert.AreEqual(existingEntity.Name, notUpdatedEntity.Name);
        }

        // Delete and rollback does not delete an item
        [Ignore] // need to reinstate this once a suitable entity can be used.
        [TestMethod]
        public void Test_DeleteAndDiscarding_DoesNotDeleteAnBasedItem()
        {
            //// Arrange
            //var repository = new MockRepository<MockIdEntity>(_unitOfWork);
            //var existingEntity = _unitOfWork.CreateSet<MockIdEntity>().First();

            //// Act
            //repository.Delete(existingEntity);
            //repository.DiscardChanges();
            //var notDeletedEntity = repository.GetForId(existingEntity.Id);

            //// Assert            
            //Assert.IsNotNull(notDeletedEntity);
            //Assert.AreEqual(existingEntity.Id, notDeletedEntity.Id);
            //Assert.AreEqual(existingEntity.Name, notDeletedEntity.Name);
        }

        // Delete and rollback does not delete an item
        [TestMethod]
        public void Test_DeleteAndDiscarding_DoesNotDeleteAnKeyBasedItem()
        {
            // Arrange
            var repository = new MockRepository<Role>(_unitOfWork);
            var existingEntity = _unitOfWork.CreateSet<Role>().First();

            // Act
            repository.Delete(existingEntity);
            repository.DiscardChanges();
            var notDeletedEntity = repository.GetForKey(existingEntity.Key);

            // Assert            
            Assert.IsNotNull(notDeletedEntity);
            Assert.AreEqual(existingEntity.Key, notDeletedEntity.Key);
            Assert.AreEqual(existingEntity.Name, notDeletedEntity.Name);
        }

        // Create with no SaveChanges or rollback does not create an item
        [Ignore] // need to reinstate this once a suitable entity can be used.
        [TestMethod]
        public void Test_CreateWithoutSavingOrDiscarding_DoesNotCreateANewIdBAsedItem()
        {
            //// Arrange
            //var existingEntities = _unitOfWork.CreateSet<MockIdEntity>().ToList();
            //var repository = new MockRepository<MockIdEntity>(_unitOfWork);

            //// Create new exclusion
            //var newEntity = new MockIdEntity
            //{
            //    Name = "A new record"
            //};

            //// Act
            //repository.Create(newEntity);
            //// Refresh uow/repository
            //_unitOfWork = UnitOfWorkHelper.GetUnitOfWork();
            //repository = new MockRepository<MockIdEntity>(_unitOfWork);

            //// Assert            
            //Assert.AreEqual(_unitOfWork.CreateSet<MockIdEntity>().ToList().Count, existingEntities.Count);
            //Assert.IsTrue(newEntity.Id == 0);
        }

        // Create with no SaveChanges or rollback does not create an item
        [TestMethod]
        public void Test_CreateWithoutSavingOrDiscarding_DoesNotCreateANewKeyBasedItem()
        {
            // Arrange
            var existingEntities = _unitOfWork.CreateSet<Role>().ToList();
            var repository = new MockRepository<Role>(_unitOfWork);

            // Create new exclusion
            var newEntity = new Role
            {
                Key = RoleData.RoleMain.Key,
                Name = RoleData.RoleMain.Name
            };

            // Act
            repository.Create(newEntity);
            // Refresh uow/repository
            _unitOfWork = UnitOfWorkHelper.GetUnitOfWork();
            //repository = new MockRepository<Role>(_unitOfWork);

            // Assert            
            Assert.AreEqual(_unitOfWork.CreateSet<Role>().ToList().Count, existingEntities.Count);
        }

        // Update with no SaveChanges or rollback does not update an item
        [Ignore] // need to reinstate this once a suitable entity can be used.
        [TestMethod]
        public void Test_UpdateWithoutSavingOrDiscarding_DoesNotUpdateAnIdBasedItem()
        {
            //// Arrange
            //var repository = new MockRepository<MockIdEntity>(_unitOfWork);
            //var existingEntity = _unitOfWork.CreateSet<MockIdEntity>().First();

            //// Act
            //existingEntity.Name = "Updated entity";
            //repository.Update(existingEntity);
            //// Refresh uow/repository
            //_unitOfWork = UnitOfWorkHelper.GetUnitOfWork();
            //repository = new MockRepository<MockIdEntity>(_unitOfWork);
            //var notUpdatedEntity = repository.GetForId(existingEntity.Id);

            //// Assert            
            //Assert.AreEqual(existingEntity.Id, notUpdatedEntity.Id);
            //Assert.AreNotEqual(existingEntity.Name, notUpdatedEntity.Name);
        }

        // Update with no SaveChanges or rollback does not update an item
        [TestMethod]
        public void Test_UpdateWithoutSavingOrDiscarding_DoesNotUpdateAKeyBasedItem()
        {
            // Arrange

            var repository = new MockRepository<Role>(_unitOfWork);
            var existingEntity = _unitOfWork.CreateSet<Role>().First();

            // Act
            existingEntity.Name = "Updated entity";
            repository.Update(existingEntity);
            // Refresh uow/repository
            _unitOfWork = UnitOfWorkHelper.GetUnitOfWork();
            repository = new MockRepository<Role>(_unitOfWork);
            var notUpdatedEntity = repository.GetForKey(existingEntity.Key);

            // Assert            
            Assert.AreEqual(existingEntity.Key, notUpdatedEntity.Key);
            Assert.AreNotEqual(existingEntity.Name, notUpdatedEntity.Name);
        }

        // Delete with no SaveChanges or rollback does not delete an item        
        [Ignore] // need to reinstate this once a suitable entity can be used.
        [TestMethod]
        public void Test_DeleteWithoutSavingOrDiscarding_DoesNotDeleteAnIdBasedItemItem()
        {
            //// Arrange
            //var repository = new MockRepository<MockIdEntity>(_unitOfWork);
            //var existingEntity = _unitOfWork.CreateSet<MockIdEntity>().First();

            //// Act
            //repository.Delete(existingEntity);
            //// Refresh uow/repository
            //_unitOfWork = UnitOfWorkHelper.GetUnitOfWork();
            //repository = new MockRepository<MockIdEntity>(_unitOfWork);
            //var notDeletedEntity = repository.GetForId(existingEntity.Id);

            //// Assert            
            //Assert.IsNotNull(notDeletedEntity);
            //Assert.AreEqual(existingEntity.Id, notDeletedEntity.Id);
            //Assert.AreEqual(existingEntity.Name, notDeletedEntity.Name);
        }

        // Delete with no SaveChanges or rollback does not delete an item        
        [TestMethod]
        public void Test_DeleteWithoutSavingOrDiscarding_DoesNotDeleteAKeyBasedItem()
        {
            // Arrange
            var repository = new MockRepository<Role>(_unitOfWork);
            var existingEntity = _unitOfWork.CreateSet<Role>().First();

            // Act
            repository.Delete(existingEntity);
            // Refresh uow/repository
            _unitOfWork = UnitOfWorkHelper.GetUnitOfWork();
            repository = new MockRepository<Role>(_unitOfWork);
            var notDeletedEntity = repository.GetForKey(existingEntity.Key);

            // Assert            
            Assert.IsNotNull(notDeletedEntity);
            Assert.AreEqual(existingEntity.Key, notDeletedEntity.Key);
            Assert.AreEqual(existingEntity.Name, notDeletedEntity.Name);
        }

        [Ignore] // need to reinstate this once a suitable entity can be used.
        [TestMethod]
        public void Test_CreateSaveThenLoadCopyModifyNameAndMerge_ResultsIn_NewNameForPersistedIdBasedItem()
        {
            //// Arrange
            //const string newName = "BuiscuitEater";
            //var cloneService = (ICloneService)new DeepCopyCloneService();
            //var repository = new MockRepository<MockIdEntity>(_unitOfWork);
            //var newEntity = _unitOfWork.CreateSet<MockIdEntity>().First();

            //// Act
            //repository.SaveChanges();
            //var persistedEntity = repository.GetForId(newEntity.Id);
            //var modifiedEntity = persistedEntity.Clone<MockIdEntity>(cloneService);
            //modifiedEntity.Name = newName;
            //repository.Merge(persistedEntity, modifiedEntity);

            //// Assert            
            //Assert.AreEqual(newName, persistedEntity.Name);
        }


        [TestMethod]
        public void Test_CreateSaveThenLoadCopyModifyNameAndMerge_ResultsIn_NewNameForPersistedKeyBasedItem()
        {
            //// Arrange
            //const string newName = "BuiscuitEater";
            //var cloneService = (ICloneService)new DeepCopyCloneService();
            //var repository = new MockRepository<Role>(_unitOfWork);
            //var newEntity = _unitOfWork.CreateSet<Role>().First();

            //// Act
            //repository.SaveChanges();
            //var persistedEntity = repository.GetForKey(newEntity.Key);
            //var modifiedEntity = persistedEntity.Clone<Role>(cloneService);
            //modifiedEntity.Name = newName;
            //repository.Merge(persistedEntity, modifiedEntity);

            //// Assert            
            //Assert.AreEqual(newName, persistedEntity.Name);
        }

        #endregion
    }
}
