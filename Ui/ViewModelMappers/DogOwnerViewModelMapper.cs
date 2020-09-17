using System;
using System.Collections.Generic;
using System.Linq;
using Ui.Entities;
using Ui.Models;

/*
 * 1) I have removed service dependancy from mapper so  mapper simply take data (model) and map it to viewmodel
 */
namespace Ui.ViewModelMappers
{
    public interface IDogOwnerViewModelMapper
    {
        DogOwnerListViewModel MapDogOwners(List<DogOwner> dogOwners);
    }

    public class DogOwnerViewModelMapper : IDogOwnerViewModelMapper
    {
        public DogOwnerListViewModel MapDogOwners(List<DogOwner> dogOwners)
        {
            if (dogOwners == null) return new DogOwnerListViewModel{ DogOwnerViewModels=new List<DogOwnerViewModel>()};

            //Solution: if don't change db model then grouping can be done as below
            //var dogOwnerListViewModel = new DogOwnerListViewModel
            //{
            //    DogOwnerViewModels = dogOwners.GroupBy(item => item.OwnerName).ToList().Select(e => new DogOwnerViewModel
            //    {
            //        OwnerName = e.Key,
            //        DogNames = e.ToList().Select(x => x.DogName).ToList()
            //    }).ToList()
            //};
            //return dogOwnerListViewModel;

            return new DogOwnerListViewModel
            {
                DogOwnerViewModels = dogOwners.Select(e => new DogOwnerViewModel
                {
                    OwnerName = e.OwnerName,
                    DogNames = MapDogNames(e.Dogs) 
                }).ToList()
            };
            
        }

        private List<string> MapDogNames(List<Dog> dogs)
        {
            if (dogs == null || !dogs.Any()) return new List<string>();
            return dogs?.Select(x => x.DogName).ToList();
        }
    }
}