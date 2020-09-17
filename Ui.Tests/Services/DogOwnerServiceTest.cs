using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ui.Data;
using Ui.Entities;
using Ui.Services;

namespace Ui.Tests.Services
{
    [TestClass]
    public class DogOwnerServiceTest
    {
        Mock<IDogOwnerRepository> repo = new Mock<IDogOwnerRepository>();
        DogOwnerService _testObject;

        [TestInitialize]
        public void Setup()
        {
            _testObject = new DogOwnerService(repo.Object);
        }

        [TestMethod]
        public void get_all_dog_owners()
        {
            // Arrange
            List<DogOwner> list = new List<DogOwner>()
            {
                new DogOwner{ OwnerName="Owner1", Dogs=new List<Dog>{ new Dog { DogName="DogA" } } },
                new DogOwner{ OwnerName="Owner2", Dogs=new List<Dog>{ new Dog { DogName="DogB" } } }
            };
            repo.Setup(c => c.GetAllDogOwners()).Returns(list);

            // Act
            var result = _testObject.GetAllDogOwners();

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.AreSame(list, result);
            repo.Verify(x => x.GetAllDogOwners(), Times.Once);
        }
    }
}