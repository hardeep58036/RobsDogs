using System.Collections.Generic;

/*
 * 1) Added a new entity for Dog 
 
     */
namespace Ui.Entities
{
	public class DogOwner
	{
        //Assumption is that owner name is unique. Probably a good idea to add owner address (id) and then group based on unique address. or some owner id.
        public string OwnerName { get; set; }
		//public string DogName { get; set; }
        public List<Dog> Dogs { get; set; }
	}


    public class Dog
    {
        public string DogName { get; set; }
    }
}