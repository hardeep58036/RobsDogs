using System.Collections.Generic;
using Ui.Data;
using Ui.Entities;

namespace Ui.Services
{
    public interface IDogOwnerService
    {
        List<DogOwner> GetAllDogOwners();
    }

    public class DogOwnerService : IDogOwnerService
    {
        private readonly IDogOwnerRepository _dogOwnerRepository;

        public DogOwnerService(IDogOwnerRepository dogOwnerRepository)
        {
            _dogOwnerRepository = dogOwnerRepository;
        }

        public List<DogOwner> GetAllDogOwners()
		{
            return _dogOwnerRepository.GetAllDogOwners();
        }
	}
}