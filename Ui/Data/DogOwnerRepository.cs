using System.Collections.Generic;
using Ui.Entities;

/*
 * Did not added any tests to repo as with current state it is not testable
 * DB layers can be tested either with e2e tests or InMemory Database if we are using .net core
 * */
namespace Ui.Data
{
    public interface IDogOwnerRepository
    {
        List<DogOwner> GetAllDogOwners();
    }

    public class DogOwnerRepository : IDogOwnerRepository
    {
        public List<DogOwner> GetAllDogOwners()
        {
            var dogOwnerList = new List<DogOwner>
            {
                new DogOwner
                {
                    OwnerName ="Rob",
                    Dogs =new List<Dog>{
                            new Dog { DogName="Willow"},
                            new Dog { DogName="Nook"},
                            new Dog { DogName="Sox"},
                            }
                },
            new DogOwner
                {
                    OwnerName ="Hardeep",
                    Dogs=new List<Dog>
                    {
                        new Dog{ DogName="adog"}
                    }
                }


                //new DogOwner
                //{
                //    OwnerName = "Rob",
                //    DogName = "Willow"
                //},
                // new DogOwner
                //{
                //    OwnerName = "Rob",
                //    DogName = "Nook"
                //},
                //  new DogOwner
                //{
                //    OwnerName = "Rob",
                //    DogName = "Sox"
                //},
                //  new DogOwner
                //{
                //    OwnerName = "Hardeep",
                //    DogName = "A"
                //}
                //  ,
                //  new DogOwner
                //{
                //    OwnerName = "Hardeep",
                //    DogName = "B"
                //}
            };

            return dogOwnerList;
        }
    }
}