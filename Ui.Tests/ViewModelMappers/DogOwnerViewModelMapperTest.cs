using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ui.Entities;
using Ui.ViewModelMappers;

namespace Ui.Tests.ViewModelMappers
{
    [TestClass]
    public class DogOwnerViewModelMapperTest
    {
        List<DogOwner> model;
        const string dogName = "any";
        const string otherDogname = "other";
        const string ownerName = "owner1";

        [TestInitialize]
        public void Setup()
        {
            model = new List<DogOwner> {
                new DogOwner { OwnerName = ownerName, Dogs=new List<Dog>{ new Dog { DogName=dogName}, new Dog { DogName = otherDogname } } },
            };
        }

        [TestMethod]
        public void Map_model_to_view_model()
        {
            //Arrange
            DogOwnerViewModelMapper mapper = new DogOwnerViewModelMapper();
            var expectedDogName = new List<string> { dogName, otherDogname };
            //Act
                var result = mapper.MapDogOwners(model);

            //Assert
            Assert.AreEqual(1, result.DogOwnerViewModels.Count);
            Assert.AreEqual(ownerName, result.DogOwnerViewModels[0].OwnerName);
            Assert.AreEqual(dogName, result.DogOwnerViewModels[0].DogNames[0]);
            Assert.AreEqual(otherDogname, result.DogOwnerViewModels[0].DogNames[1]);

           
        }

        [TestMethod]
        public void Map_model_to_view_model_when_multiple_owners()
        {
            //Arrange
            DogOwnerViewModelMapper mapper = new DogOwnerViewModelMapper();
            model = new List<DogOwner> { new DogOwner { OwnerName="a"}, new DogOwner { OwnerName = "b" }, new DogOwner { OwnerName = "c" } };
            //Act
            var result = mapper.MapDogOwners(model);

            //Assert
            Assert.AreEqual(3, result.DogOwnerViewModels.Count);
        }

        [TestMethod]
        public void Map_model_to_view_model_when_model_is_emptyt()
        {
            //Arrange
            DogOwnerViewModelMapper mapper = new DogOwnerViewModelMapper();
            model = new List<DogOwner>();
            //Act
            var result = mapper.MapDogOwners(model);

            //Assert
            Assert.AreEqual(0, result.DogOwnerViewModels.Count);
        }

        [TestMethod]
        public void Map_model_to_view_model_when_model_is_null()
        {
            //Arrange
            DogOwnerViewModelMapper mapper = new DogOwnerViewModelMapper();
            //Act
            var result = mapper.MapDogOwners(null);

            //Assert
            Assert.AreEqual(0, result.DogOwnerViewModels.Count);
        }
    }
}
