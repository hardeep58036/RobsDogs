using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ui.Controllers;
using Ui.Entities;
using Ui.Models;
using Ui.Services;
using Ui.ViewModelMappers;

namespace Ui.Tests.Controllers
{
    [TestClass]
	public class RobsDogsControllerTest
	{
        Mock<IDogOwnerViewModelMapper> mapper = new Mock<IDogOwnerViewModelMapper>();
        Mock<IDogOwnerService> service = new Mock<IDogOwnerService>();

        List<DogOwner> model;
        DogOwnerListViewModel viewModel;

        [TestInitialize]
        public void Setup()
        {
            model = new List<DogOwner> { new DogOwner {  OwnerName = "anyowner", Dogs=new List<Dog> { new Dog { DogName="adog"} } } };
            viewModel = GetViewModel();
        }

        [TestMethod]
		public void Index()
		{
            // Arrange
            service.Setup(c => c.GetAllDogOwners()).Returns(model);
            mapper.Setup(c => c.MapDogOwners(It.IsAny<List<DogOwner>>())).Returns(viewModel);

            RobsDogsController controller = new RobsDogsController(mapper.Object, service.Object);

			// Act
			ViewResult result = controller.Index() as ViewResult;
            

            // Assert
            Assert.IsNotNull(result);
            var mappedviewmodel = result.Model as DogOwnerListViewModel;
            Assert.AreSame(viewModel, mappedviewmodel);
            // Should be testing/verifying call to GetAllDogOwners and subsequent methods down the stack.
            service.Verify(x => x.GetAllDogOwners(), Times.Once);
            mapper.Verify(x => x.MapDogOwners(model), Times.Once);
            // Moq is installed to help you.
        }

        private DogOwnerListViewModel GetViewModel()
        {
            return new DogOwnerListViewModel
            {
                DogOwnerViewModels = new List<DogOwnerViewModel>
                {
                    new DogOwnerViewModel{OwnerName="anyowner", DogNames=new List<string>{ "a", "b"}}
                }
            };
        }
    }
}