using Dibware.Template.Core.Domain.Contracts.Repositories;
using Dibware.Template.Infrastructure.SqlDataAccess.Repositories;
using Dibware.Template.Infrastructure.SqlDataAccess.UnitOfWork;
using Dibware.Template.Infrastructure.SqlDataAccessTests.Helpers;
using Dibware.Template.Infrastructure.SqlDataAccessTests.Initialisers;
using Dibware.Template.Infrastructure.SqlDataAccessTests.MockData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.Entity;

namespace Dibware.Template.Infrastructure.SqlDataAccessTests.Repositories
{
    [TestClass]
    public class RoleRepositoryTests
    {
        #region Private Members

        private WebsiteDbContext _unitOfWork;

        #endregion Declarations

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

        #endregion Test Initialise

        #region Tests

        #region IRoleRepository

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_RoleRepository_GetRoleListForUserWithNullUnitOfWork_ThrowsInvalidOperationException()
        {
            // Arrange
            const String username = UserData.UserDave.Username;
            var repository = (IRoleRepository)new RoleRepository(null);

            // Act
            var actualResult = repository.GetRoleListForUser(username);

            // Assert
            // Exception Thrown
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_RoleRepository_GetRoleListForUserWithValidUnitOfWork_ThrowsNotImplementedException()
        {
            // Arrange
            const String username = UserData.UserDave.Username;
            var repository = (IRoleRepository)new RoleRepository(_unitOfWork);

            // Act
            var actualResult = repository.GetRoleListForUser(username);

            // Assert
            // Exception Thrown
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_RoleRepository_GetRoleNameListsForUserWithNullUnitOfWork_ThrowsInvalidOperationException()
        {
            // Arrange
            const String username = UserData.UserDave.Username;
            var repository = (IRoleRepository)new RoleRepository(null);

            // Act
            var actualResult = repository.GetRoleNameListsForUser(username);

            // Assert
            // Exception Thrown
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_RoleRepository_GetRoleNameListsForUseWithValidUnitOfWork_ThrowsNotImplementedException()
        {
            // Arrange
            const String username = UserData.UserDave.Username;
            var repository = (IRoleRepository)new RoleRepository(_unitOfWork);

            // Act
            var actualResult = repository.GetRoleNameListsForUser(username);

            // Assert
            // Exception Thrown
        }

        #endregion IRoleRepository

        // Get for GUID returns expected item when GUID exists
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void Test_RoleRepository_GetForGuid_ThrowsNotImplementedException()
        {
            // Arrange
            //var expectedResult = _unitOfWork.CreateSet<Role>().First();
            var repository = new RoleRepository(_unitOfWork);

            // Act
            var actualResult = repository.GetForGuid(new Guid());

            // Assert
            // Exception Thrown
        }

        //// Get for ID returns expected item when ID exists
        //[TestMethod]
        //[ExpectedException(typeof(NotImplementedException))]
        //public void Test_RoleRepository_GetForId_ThrowsNotImplementedException()
        //{
        //    // Arrange
        //    var expectedResult = _unitOfWork.CreateSet<Role>().First();
        //    var repository = new RoleRepository(_unitOfWork);

        //    // Act
        //    var actualResult = repository.GetForId(1);

        //    // Assert
        //    // Exception Thrown
        //}

        //// Get for KEY returns expected item when KEY exists
        //[TestMethod]
        //public void Test_RoleRepository_GetForKey_ReturnsExpectedItemWhenKeyExists()
        //{
        //    // Arrange
        //    var expectedResult = _unitOfWork.CreateSet<Role>().First();
        //    var repository = new RoleRepository(_unitOfWork);

        //    // Act
        //    var actualResult = repository.GetForKey(expectedResult.Key);

        //    // Assert
        //    Assert.IsNotNull(actualResult);
        //    Assert.AreEqual(actualResult. expectedResult);
        //    Assert.AreEqual(actualResult.Name, expectedResult.Name);
        //}

        //// Get for KEY returns null when expected id does not exist
        //[TestMethod]
        //public void Test_RoleRepository_GetForId_ReturnsNullWhenKeyDoesNotExist()
        //{
        //    // Arrange
        //    var repository = new RoleRepository(_unitOfWork);

        //    // Act
        //    var actualResult = repository.GetForKey("bananas"); // KEY will not exist..

        //    // Assert
        //    Assert.IsNull(actualResult);
        //}

        //// Get all returns all expected items when items exist
        //[TestMethod]
        //public void Test_RoleRepository_GetAll_ReturnsAllExpectedItemsWhenItemsExist()
        //{
        //    // Arrange
        //    var expectedEntities = _unitOfWork.CreateSet<Role>().ToList();
        //    var repository = new RoleRepository(_unitOfWork);

        //    // Act
        //    var results = repository.GetAll();

        //    // Assert
        //    Assert.IsNotNull(results);
        //    Assert.AreEqual(results.Count, expectedEntities.Count);

        //    // Verify first exclusionCategory is equal to expected
        //    Assert.AreEqual(results.First().Key, expectedEntities.First().Key);
        //    Assert.AreEqual(results.First().Name, expectedEntities.First().Name);

        //    // Verify last exclusionCategory is equal to expected
        //    Assert.AreEqual(results.Last().Key, expectedEntities.Last().Key);
        //    Assert.AreEqual(results.Last().Name, expectedEntities.Last().Name);
        //}

        //// Get all returns empty list when no items exist
        //[TestMethod]
        //public void Test_RoleRepository_GetAll_ReturnsEmptyListWhenNoItemsExist()
        //{
        //    // Set db initialiser to create an empty database
        //    var initialiser = new WebsiteDbContextInitialiser_Empty();
        //    Database.SetInitializer<WebsiteDbContext>(initialiser);
        //    var unitOfWork = UnitOfWorkHelper.GetUnitOfWorkEmpty();
        //    initialiser.InitializeDatabase(unitOfWork);

        //    // Arrange
        //    var existingEntities = unitOfWork.CreateSet<Role>().ToList();
        //    var repository = new RoleRepository(unitOfWork);

        //    // Act
        //    var results = repository.GetAll();

        //    // Assert
        //    Assert.IsNotNull(results);
        //    Assert.AreEqual(results.Count, 0);
        //}

        //[TestMethod]
        //[ExpectedException(typeof(NotImplementedException))]
        //public void Test_RoleRepository_GetRolesForUser_ThrowsNotImplementedException()
        //{
        //    // Set db initialiser to create an empty database
        //    var initialiser = new WebsiteDbContextInitialiser_Empty();
        //    Database.SetInitializer<WebsiteDbContext>(initialiser);
        //    var unitOfWork = UnitOfWorkHelper.GetUnitOfWorkEmpty();
        //    initialiser.InitializeDatabase(unitOfWork);

        //    // Arrange
        //    var existingEntities = unitOfWork.CreateSet<Role>().ToList();
        //    var repository = new RoleRepository(unitOfWork);
        //    const String username = "Bubbles";

        //    // Act
        //    var results = repository.GetRolesForUser(username);

        //    // Assert
        //    // Throws NotImplementedException
        //}

        //[TestMethod]
        //[ExpectedException(typeof(NotImplementedException))]
        //public void Test_RoleRepository_GetRoleNamessForUser_ThrowsException()
        //{
        //    // Set db initialiser to create an empty database
        //    var initialiser = new WebsiteDbContextInitialiser_Empty();
        //    Database.SetInitializer<WebsiteDbContext>(initialiser);
        //    var unitOfWork = UnitOfWorkHelper.GetUnitOfWorkEmpty();
        //    initialiser.InitializeDatabase(unitOfWork);

        //    // Arrange
        //    var existingEntities = unitOfWork.CreateSet<Role>().ToList();
        //    var repository = new RoleRepository(unitOfWork);
        //    const String username = "Bubbles";

        //    // Act
        //    var results = repository.GetRoleNamesForUser(username);

        //    // Assert
        //    // Throws NotImplementedException
        //}

        //// Create and SaveChanges creates a new item
        //[TestMethod]
        //public void Test_RoleRepository_CreateAndSaving_CreatesANewItem()
        //{
        //    // Arrange
        //    const String key = "key1";
        //    var existingEntities = _unitOfWork.CreateSet<Role>().ToList();
        //    var repository = new RoleRepository(_unitOfWork);

        //    // Create new exclusion
        //    var newEntity = new Role()
        //    {
        //        Key = key,
        //        Name = "A new record"
        //    };

        //    // Act
        //    var createdEntity = repository.Create(newEntity);
        //    repository.SaveChanges();

        //    // Assert
        //    Assert.AreEqual(_unitOfWork.CreateSet<Role>().ToList().Count, existingEntities.Count + 1);
        //    Assert.IsTrue(createdEntity.Key != String.Empty);
        //}

        //// Create 3 items and SaveChanges creates 3 items
        //[TestMethod]
        //public void Test_RoleRepository_Create3ItemsAndSaving_Creates3NewItems()
        //{
        //    // Arrange
        //    const String key1 = "key-1";
        //    const String key2 = "key-2";
        //    const String key3 = "key-3";
        //    var existingEntities = _unitOfWork.CreateSet<Role>().ToList();
        //    var repository = new RoleRepository(_unitOfWork);

        //    // Create 3 new exclusions
        //    var newEntity1 = new Role()
        //    {
        //        Key = key1,
        //        Name = "A new record 1"
        //    };
        //    var newEntity2 = new Role()
        //    {
        //        Key = key2,
        //        Name = "A new record 2"
        //    };
        //    var newEntity3 = new Role()
        //    {
        //        Key = key3,
        //        Name = "A new record 2"
        //    };

        //    // Act
        //    var createdEntity1 = repository.Create(newEntity1);
        //    var createdEntity2 = repository.Create(newEntity2);
        //    var createdEntity3 = repository.Create(newEntity3);
        //    repository.SaveChanges();

        //    // Assert
        //    Assert.AreEqual(_unitOfWork.CreateSet<Role>().ToList().Count, existingEntities.Count + 3);
        //    Assert.IsTrue(createdEntity1.Key == key1);
        //    Assert.IsTrue(createdEntity2.Key == key2);
        //    Assert.IsTrue(createdEntity3.Key == key3);
        //}

        //// Update and SaveChanges updates an item
        //[TestMethod]
        //public void Test_RoleRepository_UpdateAndSaving_UpdatesAnItem()
        //{
        //    // Arrange

        //    var repository = new RoleRepository(_unitOfWork);
        //    var existingEntity = _unitOfWork.CreateSet<Role>().First();

        //    // Act
        //    existingEntity.Name = "Updated entity";
        //    repository.Update(existingEntity);
        //    repository.SaveChanges();
        //    var updatedEntity = repository.GetForKey(existingEntity.Key);

        //    // Assert
        //    Assert.AreEqual(existingEntity.Name, updatedEntity.Name);
        //}

        //// Update 3 items and SaveChanges updates 3 items
        //[TestMethod]
        //public void Test_RoleRepository_Update3ItemsAndSaving_Updates3Items()
        //{
        //    // Arrange

        //    var repository = new RoleRepository(_unitOfWork);
        //    var existingEntity1 = _unitOfWork.CreateSet<Role>().First();
        //    var existingEntity2 = _unitOfWork.CreateSet<Role>().ToList()[1];
        //    var existingEntity3 = _unitOfWork.CreateSet<Role>().ToList()[2];

        //    // Act
        //    existingEntity1.Name = "Updated entity 1";
        //    existingEntity2.Name = "Updated entity 2";
        //    existingEntity3.Name = "Updated entity 3";
        //    repository.Update(existingEntity1);
        //    repository.Update(existingEntity2);
        //    repository.Update(existingEntity3);
        //    repository.SaveChanges();
        //    var updatedEntity1 = repository.GetForKey(existingEntity1.Key);
        //    var updatedEntity2 = repository.GetForKey(existingEntity2.Key);
        //    var updatedEntity3 = repository.GetForKey(existingEntity3.Key);

        //    // Assert
        //    Assert.AreEqual(existingEntity1.Name, updatedEntity1.Name);
        //    Assert.AreEqual(existingEntity2.Name, updatedEntity2.Name);
        //    Assert.AreEqual(existingEntity3.Name, updatedEntity3.Name);
        //}

        //// Delete and SaveChanges deletes an item
        //[TestMethod]
        //public void Test_RoleRepository_DeleteAndSaving_DeletesAnItem()
        //{
        //    // Arrange
        //    var repository = new RoleRepository(_unitOfWork);
        //    var existingEntity = _unitOfWork.CreateSet<Role>().First();

        //    // Act
        //    repository.Delete(existingEntity);
        //    repository.SaveChanges();
        //    var deletedEntity = repository.GetForKey(existingEntity.Key);

        //    // Assert
        //    Assert.IsNull(deletedEntity);
        //}

        //// Delete 3 items and SaveChanges deletes 3 items
        //[TestMethod]
        //public void Test_RoleRepository_Delete3ItemsAndSaving_Deletes3Items()
        //{
        //    // Arrange
        //    var repository = new RoleRepository(_unitOfWork);
        //    var existingEntity1 = _unitOfWork.CreateSet<Role>().First();
        //    var existingEntity2 = _unitOfWork.CreateSet<Role>().ToList()[1];
        //    var existingEntity3 = _unitOfWork.CreateSet<Role>().ToList()[2];

        //    // Act
        //    repository.Delete(existingEntity1);
        //    repository.Delete(existingEntity2);
        //    repository.Delete(existingEntity3);
        //    repository.SaveChanges();
        //    var deletedEntity1 = repository.GetForKey(existingEntity1.Key);
        //    var deletedEntity2 = repository.GetForKey(existingEntity2.Key);
        //    var deletedEntity3 = repository.GetForKey(existingEntity3.Key);

        //    // Assert
        //    Assert.IsNull(deletedEntity1);
        //    Assert.IsNull(deletedEntity2);
        //    Assert.IsNull(deletedEntity3);
        //}

        //// Create and rollback does not create a new item
        //[TestMethod]
        //public void Test_RoleRepository_CreateAndDiscarding_DoesNotCreateANewItem()
        //{
        //    // Arrange
        //    const String key1 = "key_1";
        //    var existingEntities = _unitOfWork.CreateSet<Role>().ToList();
        //    var repository = new RoleRepository(_unitOfWork);

        //    // Create new exclusion
        //    var newEntity = new Role()
        //    {
        //        Key = key1,
        //        Name = "A new record"
        //    };

        //    // Act
        //    repository.Create(newEntity);
        //    repository.DiscardChanges();

        //    // Assert
        //    Assert.AreEqual(_unitOfWork.CreateSet<Role>().ToList().Count, existingEntities.Count);
        //    Assert.IsTrue(newEntity.Key == key1);
        //}

        //// Update and rollback does not update an item
        //[TestMethod]
        //public void Test_RoleRepository_UpdateAndDiscarding_DoesNotUpdateAnItem()
        //{
        //    // Arrange
        //    var repository = new RoleRepository(_unitOfWork);
        //    var existingEntity = _unitOfWork.CreateSet<Role>().First();

        //    // Act
        //    existingEntity.Name = "Updated entity";
        //    repository.Update(existingEntity);
        //    repository.DiscardChanges();
        //    var notUpdatedEntity = repository.GetForKey(existingEntity.Key);

        //    // Assert
        //    Assert.AreEqual(existingEntity.Key, notUpdatedEntity.Key);
        //    Assert.AreEqual(existingEntity.Name, notUpdatedEntity.Name);
        //}

        //// Delete and rollback does not delete an item
        //[TestMethod]
        //public void Test_RoleRepository_DeleteAndDiscarding_DoesNotDeleteAnItem()
        //{
        //    // Arrange
        //    var repository = new RoleRepository(_unitOfWork);
        //    var existingEntity = _unitOfWork.CreateSet<Role>().First();

        //    // Act
        //    repository.Delete(existingEntity);
        //    repository.DiscardChanges();
        //    var notDeletedEntity = repository.GetForKey(existingEntity.Key);

        //    // Assert
        //    Assert.IsNotNull(notDeletedEntity);
        //    Assert.AreEqual(existingEntity.Key, notDeletedEntity.Key);
        //    Assert.AreEqual(existingEntity.Name, notDeletedEntity.Name);
        //}

        //// Create with no SaveChanges or rollback does not create an item
        //[TestMethod]
        //public void Test_RoleRepository_CreateWithoutSavingOrDiscarding_DoesNotCreateANewItem()
        //{
        //    // Arrange
        //    const String key = "key1";
        //    var existingEntities = _unitOfWork.CreateSet<Role>().ToList();
        //    var repository = new RoleRepository(_unitOfWork);

        //    // Create new exclusion
        //    var newEntity = new Role()
        //    {
        //        Key = key,
        //        Name = "A new record"
        //    };

        //    // Act
        //    repository.Create(newEntity);
        //    // Refresh uow/repository
        //    _unitOfWork = UnitOfWorkHelper.GetUnitOfWork();
        //    repository = new RoleRepository(_unitOfWork);

        //    // Assert
        //    Assert.AreEqual(_unitOfWork.CreateSet<Role>().ToList().Count, existingEntities.Count);
        //    Assert.IsTrue(newEntity.Key == key);
        //}

        //// Update with no SaveChanges or rollback does not update an item
        //[TestMethod]
        //public void Test_RoleRepository_UpdateWithoutSavingOrDiscarding_DoesNotUpdateAnItem()
        //{
        //    // Arrange

        //    var repository = new RoleRepository(_unitOfWork);
        //    var existingEntity = _unitOfWork.CreateSet<Role>().First();

        //    // Act
        //    existingEntity.Name = "Updated entity";
        //    repository.Update(existingEntity);
        //    // Refresh uow/repository
        //    _unitOfWork = UnitOfWorkHelper.GetUnitOfWork();
        //    repository = new RoleRepository(_unitOfWork);
        //    var notUpdatedEntity = repository.GetForKey(existingEntity.Key);

        //    // Assert
        //    Assert.AreEqual(existingEntity.Key, notUpdatedEntity.Key);
        //    Assert.AreNotEqual(existingEntity.Name, notUpdatedEntity.Name);
        //}

        //// Delete with no SaveChanges or rollback does not delete an item
        //[TestMethod]
        //public void Test_RoleRepository_DeleteWithoutSavingOrDiscarding_DoesNotDeleteAnItem()
        //{
        //    // Arrange

        //    var repository = new RoleRepository(_unitOfWork);
        //    var existingEntity = _unitOfWork.CreateSet<Role>().First();

        //    // Act
        //    repository.Delete(existingEntity);
        //    // Refresh uow/repository
        //    _unitOfWork = UnitOfWorkHelper.GetUnitOfWork();
        //    repository = new RoleRepository(_unitOfWork);
        //    var notDeletedEntity = repository.GetForKey(existingEntity.Key);

        //    // Assert
        //    Assert.IsNotNull(notDeletedEntity);
        //    Assert.AreEqual(existingEntity.Key, notDeletedEntity.Key);
        //    Assert.AreEqual(existingEntity.Name, notDeletedEntity.Name);
        //}

        //// Delete and SaveChanges deletes an item
        //[TestMethod]
        //public void Test_RoleRepository_CreateSaveThenLoadCopyModifyNameAndMerge_ResultsIn_NewNameForPersisted()
        //{
        //    // Arrange
        //    const string newName = "BuiscuitEater";
        //    var cloneService = (ICloneService)new DeepCopyCloneService();
        //    var repository = new RoleRepository(_unitOfWork);
        //    var newEntity = _unitOfWork.CreateSet<Role>().First();

        //    // Act
        //    repository.SaveChanges();
        //    var persistedEntity = repository.GetForKey(newEntity.Key);
        //    var modifiedEntity = persistedEntity.Clone<Role>(cloneService);
        //    modifiedEntity.Name = newName;
        //    repository.Merge(persistedEntity, modifiedEntity);

        //    // Assert
        //    Assert.AreEqual(newName, persistedEntity.Name);
        //}

        #endregion Tests
    }
}