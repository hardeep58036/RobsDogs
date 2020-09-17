using System.Collections.Generic;

/*
 * 1) Added a new entity for Dog 
 
     */
namespace Ui.Entities
{
	public class DogOwner
	{
        public string OwnerName { get; set; }
        public List<Dog> Dogs { get; set; }
	}


    public class Dog
    {
        public string DogName { get; set; }
    }
}